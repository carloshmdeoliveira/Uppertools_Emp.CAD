using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using System.Diagnostics;

namespace WebEmpCad.Entities.Services
{
    public class CnpjServices
    {
        public async Task<HandleCnpj?> Integracao(string cnpj)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://receitaws.com.br/v1/cnpj/{cnpj}");
            Console.Write(response);
            System.Diagnostics.Debug.WriteLine(response);
            var jsonString = await response.Content.ReadAsStringAsync();

            HandleCnpj? jsonObject = JsonConvert.DeserializeObject<HandleCnpj>(jsonString);

            if(jsonObject != null)
            {
                return jsonObject;
            }

            HandleCnpj emptyCNPJ = new HandleCnpj();
            emptyCNPJ.Verificacao = true;

            return emptyCNPJ;
        }
    }
}
