using System;
using System.Collections;

namespace SJImobiliaria
{   
    class Program
    {        
        static void Main(string[] args)
        {
            Imobiliaria imobiliaria = Repositorio.getImobiliaria();

            MenuPrincipal.lerOpcaoMenuPrincipal();

            while (MenuPrincipal.txtLido != "")
            {
                try
                {
                    if (MenuPrincipal.txtLido == "0")
                    {
                        imobiliaria.cadastrarImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                    }
                    else if (MenuPrincipal.txtLido == "1")
                    {
                        imobiliaria.cadastrarCliente();
                        Repositorio.salvarImobiliaria(imobiliaria);
                    }
                    else if (MenuPrincipal.txtLido == "2")
                    {
                        imobiliaria.listarImoveis();
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "3")
                    {
                        imobiliaria.listarImoveis("Disponivel");
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "4")
                    {
                        imobiliaria.listarImoveis("Alugado");
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "5")
                    {
                        imobiliaria.listarImoveis("Vendido");
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "6")
                    {
                        imobiliaria.listarClientes();
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "7")
                    {
                        imobiliaria.alugarImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "8")
                    {
                        imobiliaria.finalizarLocacao();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        MenuPrincipal.retornarMenuPrincipal();
                    }
                    else if (MenuPrincipal.txtLido == "9")
                    {
                        imobiliaria.venderImovel();
                        Repositorio.salvarImobiliaria(imobiliaria);
                        MenuPrincipal.retornarMenuPrincipal();
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

                MenuPrincipal.lerOpcaoMenuPrincipal();
            }
        }
    }
}