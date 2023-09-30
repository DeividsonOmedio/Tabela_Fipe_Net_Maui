using Maui_Tabela_Fipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft;

namespace Maui_Tabela_Fipe.Repositorios
{
    public class ModeloRepositorio
    {
        public static List<modelos> ListarModelos(string codigo, string tipoVeiculo)
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{tipoVeiculo}/marcas/{codigo}/modelos";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url).Result;

            var Modelos = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloFabricante>(resposta);


            // JsonSerializer.Deserialize<ModeloFabricante>(resposta);
            return Modelos.modelos ;


        }
    }
}
