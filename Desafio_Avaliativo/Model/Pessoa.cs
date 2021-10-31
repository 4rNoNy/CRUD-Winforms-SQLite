using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Desafio_Avaliativo
{
    public class Pessoa
    {
        public long? id { get; set; }
        public string pcd { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string datanascimento { get; set; }
        public string altura { get; set; }
    }
}