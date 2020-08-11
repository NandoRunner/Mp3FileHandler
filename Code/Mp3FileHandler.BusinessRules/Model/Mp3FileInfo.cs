using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3FileHandler.BusinessRules.Model
{
    public class Mp3FileInfo
    {
        public string caminho { get; set; }

        public string extensao { get; set; }

        public string prefixo { get; set; }

        public string substituir { get; set; }

        public string substpor { get; set; }

        public string abreviar { get; set; }

        public long? id { get; set; }
    }
}
