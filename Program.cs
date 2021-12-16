using System;
using System.Collections;

namespace SJImobiliaria
{   
    class Program
    {
        static string txtLido;

        static void lerOpcaoMenuPrincipal()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite 0 para cadastrar imóvel ");
            Console.WriteLine("Digite 1 para cadastrar cliente ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Digite 2 para listar todos os imóveis ");
            Console.WriteLine("Digite 3 para listar os imóveis disponíves");
            Console.WriteLine("Digite 4 para listar os imóveis alugados");
            Console.WriteLine("Digite 5 para listar os imóveis vendidos");
            Console.WriteLine("Digite 6 para listar os clientes ");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 7 para locação.");
            Console.WriteLine("Digite 8 para finalizar locação.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite 9 para vendas.");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Digite outra tecla para sair.");
            txtLido = Console.ReadLine();
        }

        static void retornarMenuPrincipal()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Informe qualquer tecla para retornar ao MENU PRINCIPAL!");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Imobiliaria imobiliaria = Repositorio.getImobiliaria();

            lerOpcaoMenuPrincipal();

            while (txtLido != "")
            {
                try
                {
                    if (txtLido == "0")
                    {
                        imobiliaria.cadastrarImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                    }
                    else if (txtLido == "1")
                    {
                        imobiliaria.cadastrarCliente();
                        Repositorio.salvarImobiliaria(imobiliaria);
                    }
                    else if (txtLido == "2")
                    {
                        imobiliaria.listarImoveis();
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "3")
                    {
                        imobiliaria.listarImoveis("Disponivel");
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "4")
                    {
                        imobiliaria.listarImoveis("Alugado");
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "5")
                    {
                        imobiliaria.listarImoveis("Vendido");
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "6")
                    {
                        imobiliaria.listarClientes();
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "7")
                    {
                        imobiliaria.alugarImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "8")
                    {
                        imobiliaria.finalizarLocacao();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        retornarMenuPrincipal();
                    }
                    else if (txtLido == "9")
                    {
                        imobiliaria.venderImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        retornarMenuPrincipal();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception erro)
                {
                    if (erro is EAbort)
                    {
                        Console.WriteLine("Operação abortada. Descrição: " + erro.Message);
                    }
                    else
                    {
                        Console.WriteLine("Ocorreu um erro inesperado. Descrição: " + erro.Message);
                    }
                }

                lerOpcaoMenuPrincipal();
            }
        }
    }
}