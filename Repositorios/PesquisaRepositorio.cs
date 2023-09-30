using Maui_Tabela_Fipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Maui_Tabela_Fipe.Repositorios
{
    public class PesquisaRepositorio
    {
         public static PesquisaPreco RetornaDadosCarro( string codigo, string tipoVeiculo, string codCarro, string anoCarro)
        {
            
                var url = $@"https://parallelum.com.br/fipe/api/v1/{tipoVeiculo}/marcas/{codigo}/modelos/{codCarro}/anos/{anoCarro}";
                var resposta = Util.HttpClientUtil.ConsHttpClientAsync(url);

                PesquisaPreco preco = JsonSerializer.Deserialize<PesquisaPreco>(resposta.Result);

                return preco;
            
        }
    }
    }

