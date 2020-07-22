using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var api = new Api();

            var login = new { email = "admin@gmail.com", password = "123" };
            dynamic tokenResult = JsonConvert.DeserializeObject<dynamic>(await api.PostData(JsonConvert.SerializeObject(login), "login"));
            string token = tokenResult.token;
            int idUser = tokenResult.idUser;
            string name = tokenResult.name;
            api.SetToken(token);

            while (true)
            {
                Console.WriteLine($"Bem vindo {name}!");
                Console.WriteLine($"token: {token}");
                Console.WriteLine($"id: {idUser}");
                Console.WriteLine("-----------------\n");

                Console.WriteLine("Digite 0 para - Sair");
                Console.WriteLine("Digite 1 para - Causar excessão");
                Console.WriteLine("Digite 2 para - Listar ambientes");
                Console.WriteLine("Digite 3 para - Listar niveis de log");
                Console.WriteLine("Digite 4 para - Listar logs");

                Console.WriteLine("");

                switch (Console.ReadLine())
                {
                    case "1":
                        var excessao = await CausarExcessao();
                        var json = new { description = excessao.Message, frequency = 1, source = excessao.Source, stackTrace = excessao.StackTrace, idUser, idEnvironment = 1, idLogLevel = 1 };
                        var response = await api.PostData(JsonConvert.SerializeObject(json), "logs");
                        break;
                    case "2":
                        var ambientes = await api.GetData("environments");
                        Console.WriteLine($"ambientes: {ambientes}");
                        break;
                    case "3":
                        var niveisLog = await api.GetData("loglevels");
                        Console.WriteLine($"logs: {niveisLog}");
                        break;
                    case "4":
                        var logs = await api.GetData("logs");
                        Console.WriteLine($"logs: {logs}");
                        break;
                    default:
                        return;
                }

                Console.WriteLine("");

                Console.WriteLine("Deseja continuar? Digite s ou n");
                if (Console.ReadLine().ToLower() == "n") return;
                Console.Clear();
            }
        }

        private static async Task<Exception> CausarExcessao()
        {
            try
            {
                var httpClient = new HttpClient();
                //Deu algo errado com alguma API
                var response = await httpClient.GetAsync("lorem");
                response.EnsureSuccessStatusCode();
                return null;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
