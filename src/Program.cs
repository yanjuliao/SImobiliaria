using System;
using System.Collections;

namespace SJImobiliaria
{   
    class Program
    {        
        static void Main(string[] args)
        {            
            Imobiliaria imobiliaria = Repositorio.getImobiliaria();

            MenuPrincipal.lerOpcao();
            while (MenuPrincipal.txtLido != "")
            {
                try
                {
                    if (MenuPrincipal.txtLido == "0")
                    {
                        imobiliaria.cadastrarImovel();
                    }
                    else if (MenuPrincipal.txtLido == "1")
                    {
                        imobiliaria.cadastrarCliente();                        
                    }
                    else if (MenuPrincipal.txtLido == "2")
                    {
                        imobiliaria.listarImoveis();
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "3")
                    {
                        imobiliaria.listarImoveis("Disponivel");
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "4")
                    {
                        imobiliaria.listarImoveis("Alugado");
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "5")
                    {
                        imobiliaria.listarImoveis("Vendido");
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "6")
                    {
                        imobiliaria.listarMoviemtacoesImovel();
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "7")
                    {
                        imobiliaria.listarClientes();
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "8")
                    {
                        imobiliaria.alugarImovel();                        
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "9")
                    {
                        imobiliaria.finalizarLocacao();                        
                        MenuPrincipal.retornar();
                    }
                    else if (MenuPrincipal.txtLido == "10")
                    {
                        imobiliaria.venderImovel();
                        MenuPrincipal.retornar();
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

                MenuPrincipal.lerOpcao();
            }
        }
    }
}