using System.Net.Http.Headers;
using System.Globalization;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private DateTime horaEntrada;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.horaEntrada = DateTime.Now;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string addplaca = Console.ReadLine();

            if (addplaca != string.Empty)
            {
                Console.WriteLine(" ");
                veiculos.Add(addplaca);
                Console.WriteLine($"Veiculo {addplaca} adicionado. Hora entrada: {horaEntrada}");
            }
            else
            {
                Console.WriteLine("Veiculo não informado, por favor informe a placa do veículo");
                AdicionarVeiculo();
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            decimal valorTotal;

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                DateTime horaSaida = DateTime.Now;
                System.TimeSpan totalHora = horaSaida - horaEntrada;

                Console.WriteLine($"Hora Entrada: {horaEntrada.ToString("HH:mm:ss")} - Hora Saida: {horaSaida.ToString("HH:mm:ss")}");
                if (totalHora.Minutes > 0)
                {
                    Console.WriteLine($"O veiculo permaneceu por {totalHora} no estacionamento");
                    valorTotal = precoInicial + ((precoPorHora / 60) * totalHora.Minutes);
                }
                else
                {
                    Console.WriteLine("Você permaneceu menos de um minuto, saída liberada");
                    valorTotal = 0;
                }

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} removido e o preço total foi de: {valorTotal.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculoList in veiculos)
                {
                    Console.WriteLine(veiculoList);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
