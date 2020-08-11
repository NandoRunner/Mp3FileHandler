using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HundredMilesSoftware.UltraID3Lib;
using System.IO;

namespace Mp3FileHandler.BusinessRules
{
    public class MusicTool
    {
        UltraID3 u;

        public MusicTool()
        {
            u = new UltraID3();
        }

        public int TratarInfo(string caminho)
        {
            int processed = 0;

            string[] lstArquivos = Directory.GetFiles(caminho, "*.mp3");

            bool achou;
            foreach (string arq in lstArquivos)
            {
                achou = false;
                u.Read(arq);
                if (string.IsNullOrEmpty(u.Title))
                {
                    achou = true;
                    u.Title = BuscarDados(arq);
                }

                if (string.IsNullOrEmpty(u.Artist))
                {
                    achou = true;
                    u.Artist = BuscarDados(arq, true);
                }

                if (string.IsNullOrEmpty(u.Album))
                {
                    achou = true;
                    u.Album = "[Baixados]";
                }

                if (achou)
                { 
                    u.Write();
                    processed++;
                }
            }

            return processed;
        }

        public string BuscarDados(string arquivo, bool artista = false)
        {
            string[] partesA = arquivo.Split('-');

            string[] partesB = partesA[1].Split('.');

            if (!artista)
            { 
                return partesB[0].Trim();
            }
            else
            {
                var aux = partesA[0].Split('\\');
                return aux[aux.Count() - 1].Trim();
            }
        }

    }
}
