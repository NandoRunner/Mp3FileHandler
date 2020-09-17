using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mp3FileHandler.BusinessRules.Model
{
    public class Mp3FileInfo
    {
        public string Caminho { get; set; }

        public string Extensao { get; set; }

        public string Prefixo { get; set; }

        public string Substituir { get; set; }

        public string Substpor { get; set; }

        public string Abreviar { get; set; }

        public long? Id { get; set; }
    }
}
