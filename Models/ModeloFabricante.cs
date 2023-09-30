using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Tabela_Fipe.Models
{
    public class ModeloFabricante
    {
        public List<modelos> modelos { get; set; }
    }

    public class modelos
    {
        public string nome { get; set;}
        public string codigo { get; set; }
    }
}
