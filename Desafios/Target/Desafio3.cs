using System.Globalization;

namespace Target
{
    public class Desafio3
    {
        public static void Rodar()
        {

            // Define a cultura para garantir o uso de vírgulas/pontos e datas no padrão brasileiro
            CultureInfo culturaBr = new("pt-BR");
            DateTime dataHoje = DateTime.Today;
            decimal taxaDiaria = 0.025m; // 2,5% ao dia            

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bem-vindo ao desafio 3 - Calculo de juros de 2.5% ao dia");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.Write("Digite o valor original R$(ou 0 para sair): ");
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Currency, culturaBr, out decimal valorOriginal) && valorOriginal == 0) break;


                Console.Write("Digite a data de vencimento (DD/MM/AAAA): ");
                if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", culturaBr, DateTimeStyles.None, out DateTime dataVencimento))
                {
                    Console.WriteLine("Data inválida! Use o formato DD/MM/AAAA (Ex: 15/10/2026).");
                }

                Console.WriteLine("\n---------------------------------------------");
                Console.WriteLine($"Valor Original: {valorOriginal.ToString("C", culturaBr)}");
                Console.WriteLine($"Data de Vencimento: {dataVencimento:dd/MM/yyyy}");
                Console.WriteLine($"Data de Hoje: {dataHoje:dd/MM/yyyy)}");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");

                // Verifica se titulo está atrasado
                if (dataHoje <= dataVencimento)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("O título está em dia ou vence hoje. Sem juros a calcular!");
                    Console.ForegroundColor = ConsoleColor.White;                    
                }
                else
                { 
                    int diasAtraso = (dataHoje - dataVencimento).Days;

                    // Realiza o cálculo de juros simples
                    decimal porcentagemTotalJuros = diasAtraso * taxaDiaria;
                    decimal valorJuros = valorOriginal * porcentagemTotalJuros;
                    decimal valorTotalAtualizado = valorOriginal + valorJuros;

                    // Exibição dos resultados
                    Console.WriteLine($"Dias em atraso: {diasAtraso} dia(s)");
                    Console.WriteLine($"Taxa acumulada: {(porcentagemTotalJuros * 100):F2}%");
                    Console.WriteLine($"Valor dos juros: {valorJuros.ToString("C", culturaBr)}");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"VALOR TOTAL A PAGAR: {valorTotalAtualizado.ToString("C", culturaBr)}");
                    Console.ResetColor();
                }                

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        } 
    }
}
