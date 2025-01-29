using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Linq;

namespace httpValidaCpf
{
    public static class fnvalidacpf
    {
        [FunctionName("fnvalidacpf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Iniciando a Validação do CPF.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            if (data == null) {
                return new BadRequestObjectResult("Por favor, informe o CPF.");
            }

            string cpf = data?.cpf;
            if (ValidarCpf(cpf) == false) {
                return new BadRequestObjectResult("CPF inválido.");
            };

            string responseMessage = "CPF válido";
            return new OkObjectResult(responseMessage);
        }

        public static bool ValidarCpf(string cpf)
        {
            if (cpf.Length != 11 || !cpf.All(char.IsDigit) || cpf.Distinct().Count() == 1)
                return false;

            var cpfDigitos = cpf.Select(x => int.Parse(x.ToString())).ToArray();

            for (int i = 9; i < 11; i++)
            {
                int soma = 0;
                for (int j = 0; j < i; j++)
                {
                    soma += cpfDigitos[j] * (i + 1 - j);
                }

                int digitoVerificador = soma % 11 < 2 ? 0 : 11 - (soma % 11);
                if (cpfDigitos[i] != digitoVerificador)
                    return false;
            }

            return true;
        }
    }
}
