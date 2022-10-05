using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace WebEmpCad.Entities.Services
{
    public class CnpjServices
    {
        public async Task<HandleCnpj?> Integracao(string cnpj)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://receitaws.com.br/v1/cnpj/{cnpj}");
            var jsonString = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(jsonString);
            HandleCnpj CNPJ = new HandleCnpj();

            if ((string?)jsonResponse["nome"] != "" && (string?)jsonResponse["cnpj"] != "")
            {
                CNPJ.Nome = (string?)jsonResponse["nome"];
                CNPJ.Cnpj = (string?)jsonResponse["cnpj"];
                CNPJ.Verificacao = true;
            } else
            {
                CNPJ.Verificacao = false;
            }

            return CNPJ;
        }
    }
}
