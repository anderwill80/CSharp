using System.Text.Json;
using System.Text.Json.Serialization;

namespace Target
{
    public class Desafio2
    {
        public class PacoteProdutos
        {
            [property: JsonPropertyName("estoque")]
            public List<Produto>? Produtos {  get; set; }
        };

        // Define a estrutura para mapear os dados do JSON
        public class Produto
        {
            [property: JsonPropertyName("codigoProduto")] 
            public int Codigo { get; set; } = 0;

            [property: JsonPropertyName("descricaoProduto")]
            public string Descricao { get; set; } = string.Empty;

            [property: JsonPropertyName("estoque")] 
            public int Estoque {  get; set; }
        };

        public static void Rodar()
        {         
            // JSON com os produtos e seus saldos
            string dadosEstoqueJson = @"
            {
	            ""estoque"":
	            [
	              {
		            ""codigoProduto"": 101,
		            ""descricaoProduto"": ""Caneta Azul"",
		            ""estoque"": 150
	              },
	              {
		            ""codigoProduto"": 102,
		            ""descricaoProduto"": ""Caderno Universitário"",
		            ""estoque"": 75
	              },
	              {
		            ""codigoProduto"": 103,
		            ""descricaoProduto"": ""Borracha Branca"",
		            ""estoque"": 200
	              },
	              {
		            ""codigoProduto"": 104,
		            ""descricaoProduto"": ""Lápis Preto HB"",
		            ""estoque"": 320
	              },
	              {
		            ""codigoProduto"": 105,
		            ""descricaoProduto"": ""Marcador de Texto Amarelo"",
		            ""estoque"": 90
	              }
	            ]
                }";

            // Desserializa o JSON para uma lista de objetos de produtos            
            var dados = JsonSerializer.Deserialize<PacoteProdutos>(dadosEstoqueJson);

            if (dados?.Produtos != null)
            {
                int IDMovimentacao = 1;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Bem-vindo ao desafio 2 - Movimentação de estoque");
                    Console.WriteLine("");
                    Console.WriteLine("");

                    Console.WriteLine("========= LISTAGEM DO CADASTRO DE PRODUTOS ===============");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine($"{"Código",-6} | {"Descrição",-30} | {"Estoque Atual",-13}");
                    Console.WriteLine("----------------------------------------------------------");

                    foreach (var prod in dados.Produtos)
                    {
                        Console.WriteLine($"{prod.Codigo,-6} | {prod.Descricao,-30} | {prod.Estoque,-13}");
                    }
                    Console.WriteLine("----------------------------------------------------------");

                    Console.Write("\nDigite o código do produto (ou 0 para sair): ");
                    if (!int.TryParse(Console.ReadLine(), out int codigo) || codigo == 0) break;

                    // Busca o produto na lista
                    var produtoSelecionado = dados.Produtos.FirstOrDefault(p => p.Codigo == codigo);

                    if (produtoSelecionado == null)
                    {
                        Console.WriteLine("X Produto não encontrado! Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        continue;
                    }

                    // Solicita o tipo de movimentação
                    Console.Write("Tipo de movimentação ([E]ntrada ou [S]aída): ");
                    char tecla = Console.ReadKey(intercept: false).KeyChar; // mostra a tecla digitada na tela
                    string tipo = tecla.ToString().ToUpper();
                    Console.WriteLine(); // Apenas pula a linha para o próximo input

                    if (tipo != "E" && tipo != "S")
                    {
                        Console.WriteLine("X Tipo inválido! Use apenas E para Entrada ou S para Saída.");
                        Console.ReadKey();
                        continue;
                    }

                    // Solicita a quantidade a movimentar
                    Console.Write("Digite a quantidade da movimentação: ");
                    if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
                    {
                        Console.WriteLine("X Quantidade inválida! Deve ser um número maior que zero.");
                        Console.ReadKey();
                        continue;
                    }
                    
                    // Processa a regra de negócio (Entrada ou Saída)
                    int idAtual = IDMovimentacao++;
                    string descricaoMov = "";

                    if (tipo == "E")
                    {
                        produtoSelecionado.Estoque += quantidade;
                        descricaoMov = "ENTRADA";
                    }
                    else if (tipo == "S")
                    {
                        if (produtoSelecionado.Estoque < quantidade)
                        {
                            Console.WriteLine($"\nX Saldo insuficiente! Estoque atual é de apenas {produtoSelecionado.Estoque} unidades.");
                            Console.ReadKey();
                            continue;
                        }
                        produtoSelecionado.Estoque -= quantidade;
                        descricaoMov = "SAÍDA";
                    }

                    // Mostra o histórico da movimentação, id e descrição do tipo de movimentação(ENTRADA ou SAIDA)
                    Console.Clear();
                    Console.WriteLine("==============================================");
                    Console.WriteLine("        MOVIMENTAÇÃO REALIZADA COM SUCESSO    ");
                    Console.WriteLine("==============================================");
                    Console.WriteLine($"ID Movimentação : {idAtual}");
                    Console.WriteLine($"Tipo            : {descricaoMov}");
                    Console.WriteLine($"Produto         : {produtoSelecionado.Descricao} (Cód: {produtoSelecionado.Codigo})");
                    Console.WriteLine($"Qtd. Movimentada: {quantidade}");
                    Console.WriteLine("----------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"SALDO FINAL EM ESTOQUE: {produtoSelecionado.Estoque} unidades");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("==============================================");

                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        } 
    }
}
