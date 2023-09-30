using Maui_Tabela_Fipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui_Tabela_Fipe.Repositorios
{
    public class AnoRepositorio
    {
        public static List<Ano> ListarAnos(string codigo ,string tipoVeiculo, string codCarro)
        {
            var url = $@"https://parallelum.com.br/fipe/api/v1/{tipoVeiculo}/marcas/{codigo}/modelos/{codCarro}/anos";
            var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url);

            List<Ano> ano = JsonSerializer.Deserialize<List<Ano>>(resposta.Result);

            return ano;
        }
    }
}
