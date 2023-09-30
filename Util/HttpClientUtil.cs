using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_Tabela_Fipe.Util
{
    public class HttpClientUtil
    {
        public static async Task<string> ConsHttpClientAsync(string endereco)
        {
            var client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync(endereco).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
