using Maui_Tabela_Fipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui_Tabela_Fipe.Repositorios
{
    public class FabricanteRepositorio
    {
        public static List<Fabricantes> ListarFabricantes(string tipoVeiculo)
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{tipoVeiculo}/marcas";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url);

            List<Fabricantes> fabricantes = JsonSerializer.Deserialize<List<Fabricantes>>(resposta.Result);

            return fabricantes;
        }
    }
}
