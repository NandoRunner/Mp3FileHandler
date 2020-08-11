using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FAndradeTI.Util.FileSystem;
using Mp3FileHandler.BusinessRules.Model;

namespace Mp3FileHandler.BusinessRules
{
    public class FileRenamerManager
    {
        private string _json;

        public List<Mp3FileInfo> listCommand { get; set; }

        public FileRenamerManager(string json)
        {
            _json = json;

            listCommand = new List<Mp3FileInfo>();

            if (!FS.FileExists(json))
            {
                FS.CreateEmptyFile(json);
            }
            else
            { 
                listCommand = LoadCommands();
            }
        }

        private void process(ref string destFile, Mp3FileInfo dados, ref bool mover)
        {
            if (!string.IsNullOrEmpty(dados.substpor))
            {
                if (destFile.Contains(dados.substituir))
                {
                    destFile = destFile.Replace(dados.substituir, dados.substpor);
                    mover = true;
                }
            }

            if (Convert.ToBoolean(dados.abreviar) && destFile.Contains(";"))
            {
                var aux = destFile.Split('-');
                var aux2 = aux[0].Split(';');
                destFile = destFile.Replace(";" + aux2[1], " ");
                mover = true;
            }

            if (!string.IsNullOrEmpty(dados.prefixo))
            {
                destFile = dados.prefixo + " " + destFile.Trim();
                mover = true;
            }
        }

        public int ProcessFile(Mp3FileInfo dados)
        {
          
            var myDirectory = new DirectoryInfo(dados.caminho);
            FileInfo[] myFiles = myDirectory.GetFiles(dados.extensao, SearchOption.AllDirectories);

            var processed = 0;

            string destFile = string.Empty;

            bool mover = false;

            foreach (var oriFile in myFiles)
            {
                mover = false;
                destFile = oriFile.Name;

                this.process(ref destFile, dados, ref mover);

                if (mover)
                {
                    destFile = FS.PathCombine(oriFile.DirectoryName, destFile.Trim());
                    FS.MoveFile(oriFile.FullName, destFile);
                    processed++;
                    Application.DoEvents();
                }
            }

            return processed;

        }

        public void ProcessPlaylist(string caminho, Mp3FileInfo dados)
        {
            var myDirectory = new DirectoryInfo(caminho);
            FileInfo[] myFiles = myDirectory.GetFiles(dados.extensao);
            bool mover = false;

            foreach (var oriFile in myFiles)
            {
                mover = false;

                //using (var input = File.OpenText(oriFile.FullName, Encoding.UTF7))
                using (var input = new StreamReader(oriFile.FullName, Encoding.UTF7))
                using (var output = new StreamWriter(FS.PathCombine(caminho, "output.txt"), false, Encoding.GetEncoding(28591)))
                {
                    string line;
                    while (null != (line = input.ReadLine()))
                    {

                        if (!line.Contains(dados.caminho.Substring(2)))
                            continue;
                        this.process(ref line, dados, ref mover);
                        output.WriteLine(line);
                    }
                }
                if (mover)
                {
                    FS.DeleteFile(oriFile.FullName);
                    FS.MoveFile(FS.PathCombine(caminho, "output.txt"), oriFile.FullName);
                }
                //string str = File.ReadAllText(oriFile.FullName);
                //str = str.Replace("some text", "some other text");
                //File.WriteAllText(oriFile.FullName, str);

            }
        }

        public void SaveCommand(Mp3FileInfo request)
        {
            listCommand.Add(request);
            FS.SaveJson<Mp3FileInfo>(listCommand, _json);
            listCommand = LoadCommands();
        }

        public List<Mp3FileInfo> LoadCommands()
        {
            return FS.LoadJson<Mp3FileInfo>(_json);
        }

        public void Delete(int rowIndex)
        {
           listCommand.RemoveAt(rowIndex);
           FS.SaveJson<Mp3FileInfo>(listCommand, _json);
        }

    }
}
