using System.Text.Json;
using System.Text.Json.Serialization;

namespace Target
{
    public class Desafio1
    {
        public class PacoteVendas
        {
            [property: JsonPropertyName("vendas")]
            public List<Venda>? Vendas { get; set; }
        };

        // Define a estrutura para mapear os dados do JSON
        public class Venda
        {
            [property: JsonPropertyName("vendedor")]
            public string Vendedor { get; set; } = string.Empty;

            [property: JsonPropertyName("valor")]
            public decimal Valor { get; set; }
        };

        public static void Rodar()
        {
            Console.WriteLine("Bem-vindo ao desafio 1 - Calcular comissão de cada vendedor");
            Console.WriteLine("");

            // JSON com os registros de vendas
            string dadosVendasJson = @"
            {
              ""vendas"": [
                { ""vendedor"": ""João Silva"", ""valor"": 1200.50 },
                { ""vendedor"": ""João Silva"", ""valor"": 950.75 },
                { ""vendedor"": ""João Silva"", ""valor"": 1800.00 },
                { ""vendedor"": ""João Silva"", ""valor"": 1400.30 },
                { ""vendedor"": ""João Silva"", ""valor"": 1100.90 },
                { ""vendedor"": ""João Silva"", ""valor"": 1550.00 },
                { ""vendedor"": ""João Silva"", ""valor"": 1700.80 },
                { ""vendedor"": ""João Silva"", ""valor"": 250.30 },
                { ""vendedor"": ""João Silva"", ""valor"": 480.75 },
                { ""vendedor"": ""João Silva"", ""valor"": 320.40 },
    
                { ""vendedor"": ""Maria Souza"", ""valor"": 2100.40 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1350.60 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 950.20 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1600.75 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1750.00 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 1450.90 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 400.50 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 180.20 },
                { ""vendedor"": ""Maria Souza"", ""valor"": 90.75 },
    
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 800.50 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1200.00 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1950.30 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1750.80 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 1300.60 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 300.40 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 500.00 },
                { ""vendedor"": ""Carlos Oliveira"", ""valor"": 125.75 },
    
                { ""vendedor"": ""Ana Lima"", ""valor"": 1000.00 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1100.50 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1250.75 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1400.20 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1550.90 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 1650.00 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 75.30 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 420.90 },
                { ""vendedor"": ""Ana Lima"", ""valor"": 315.40 }
              ]
            }
            ";

            // Desserializa o JSON para uma lista de objetos do tipo Venda
            //List<Vendas> vendas = JsonSerializer.Deserialize<List<Vendas>>(dadosVendasJson);
            var dados = JsonSerializer.Deserialize<PacoteVendas>(dadosVendasJson);

            // Dicionário para acumular a comissão de cada vendedor
            Dictionary<string, decimal> comissoesVendedor = [];


            if (dados?.Vendas != null)
            {
                foreach (Venda venda in dados.Vendas)
                {

                    decimal comissao = 0;

                    // Aplicação das regras de comissão
                    comissao = venda.Valor switch
                    {
                        < 100.00m => 0,
                        < 500.00m => venda.Valor * 0.01m, // 1% de comissão
                        _ => venda.Valor * 0.05m           // 5% de comissão
                    };

                    // Acumula o valor no dicionário
                    if (comissoesVendedor.ContainsKey(venda.Vendedor))
                    {
                        comissoesVendedor[venda.Vendedor] += comissao;
                    }
                    else
                    {
                        comissoesVendedor[venda.Vendedor] = comissao;
                    }
                }

                // Exibe o resultado final formatado                
                foreach (var comVen in comissoesVendedor)
                {
                    Console.WriteLine($"Vendedor: {comVen.Key} | Comissão Total: {comVen.Value:C2}");
                }
            }        
        }
    }
}
