using System;

namespace SJImobiliaria
{
    public static class MenuPrincipal
    {
        public static string txtLido;
        public static void lerOpcao()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite 0 para cadastrar imóvel ");
            Console.WriteLine("Digite 1 para cadastrar cliente ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite 2 para listar todos os imóveis ");
            Console.WriteLine("Digite 3 para listar os imóveis disponíves");
            Console.WriteLine("Digite 4 para listar os imóveis alugados");
            Console.WriteLine("Digite 5 para listar os imóveis vendidos");
            Console.WriteLine("Digite 6 para listar as movimentações do imóvel");
            Console.WriteLine("Digite 7 para listar os clientes ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 8 para locação.");
            Console.WriteLine("Digite 9 para finalizar locação.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 10 para vendas.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite outra tecla para sair.");
            txtLido = Console.ReadLine();
        }

        public static void retornar()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Informe qualquer tecla para lerOpcao ao MENU PRINCIPAL!");
            Console.ReadLine();
        }
    }
}