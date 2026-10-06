namespace Target
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool rodando = true;

            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("=======================================");
                Console.WriteLine("            TARGET SISTEMAS            ");
                Console.WriteLine("      SELECIONE O DESAFIO DESEJADO     ");
                Console.WriteLine("=======================================");
                Console.WriteLine("1 - Desafio 1 - COMISSAO POR VENDEDOR");
                Console.WriteLine("2 - Desafio 2 - MOVIMENTACAO DE ESTOQUE");
                Console.WriteLine("3 - Desafio 3 - CALCULO DE JUROS 2.5%");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("=======================================");
                Console.Write("Digite a sua opção: ");
                

                if (!int.TryParse(Console.ReadLine(), out int opcao) || opcao == 0) break;

                Console.Clear();

                switch (opcao)
                {
                    case 1:                        
                        Desafio1.Rodar();
                        break;

                    case 2:                        
                        Desafio2.Rodar();
                        break;

                    case 3:                        
                        Desafio3.Rodar();
                        break;

                    case 0:
                        rodando = false;
                        continue;

                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para tentar novamente.");
                        break;
                }

                if (rodando)
                {
                    Console.WriteLine("\n\nPrograma finalizado. Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("===========================================================");
            Console.WriteLine("Saindo do desafio...");
            Console.WriteLine("");
            Console.WriteLine("Espero que meu perfil se encaixe para ser um Targetiano...");
            Console.WriteLine("");
            Console.WriteLine("Aguardo o agendamento da entrevista, até logo!");
            Console.WriteLine("===========================================================");
            Console.ReadKey();
        }
    }
}