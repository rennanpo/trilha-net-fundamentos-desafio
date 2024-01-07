using System.Globalization;
using System.Runtime.CompilerServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private string placa;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Este Veiculo já foi cadastrado!");
                Console.ResetColor();
            }
            else{
                veiculos.Add(placa);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Veículo {placa} cadastrado!");
                Console.ResetColor();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32((Console.ReadLine()));
                decimal valorTotal = precoInicial + horas * precoPorHora;


                veiculos.Remove(placa);
                Console.Write($"O veículo {placa} foi removido e o preço total foi de: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{valorTotal.ToString("C")}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Console.ResetColor();
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string veiculo in veiculos){
                    Console.WriteLine($"{veiculo}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não há veículos estacionados.");
                Console.ResetColor();
            }
        }
    }
}
