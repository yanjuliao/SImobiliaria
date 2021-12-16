using System;
using System.IO;
using System.Collections;

namespace SJImobiliaria
{
    class Repositorio
    {
        private static StreamWriter escritorClientes;
        private static StreamWriter escritorImoveis;
        private static StreamWriter escritorMovimentacoes;

        private static StreamReader leitorClientes;
        private static StreamReader leitorImoveis;
        private static StreamReader leitorMovimentacoes;

        private static void inicializarEscritores()
        {
            Repositorio.escritorClientes = new StreamWriter("clientes.txt");
            Repositorio.escritorImoveis = new StreamWriter("imoveis.txt");
            Repositorio.escritorMovimentacoes = new StreamWriter("movimentacoes.txt");
        }

        private static void finalizarEscritores()
        {
            Repositorio.escritorClientes.Close();
            Repositorio.escritorImoveis.Close();
            Repositorio.escritorMovimentacoes.Close();
        }

        private static void inicializarLeitores()
        {
            Repositorio.leitorClientes = new StreamReader("clientes.txt");
            Repositorio.leitorImoveis = new StreamReader("imoveis.txt");
            Repositorio.leitorMovimentacoes = new StreamReader("movimentacoes.txt");
        }

        private static void finalizarLeitores()
        {
            Repositorio.leitorClientes.Close();
            Repositorio.leitorImoveis.Close();
            Repositorio.leitorMovimentacoes.Close();
        }


        public static Imobiliaria getImobiliaria()
        {
            Repositorio.inicializarLeitores();

            ArrayList clientes = Repositorio.getClientes();
            ArrayList imoveis = Repositorio.getImoveis();
            ArrayList movimentacoes = Repositorio.getMovimentacoes();

            Imobiliaria imobiliaria = new Imobiliaria(clientes, imoveis, movimentacoes);

            Repositorio.finalizarLeitores();

            return imobiliaria;
        }

        private static ArrayList getClientes()
        {
            ArrayList clientes = new ArrayList();

            while (Repositorio.leitorClientes.Peek() >= 0)
            {
                string registro = Repositorio.leitorClientes.ReadLine();
                Cliente cliente = Repositorio.getCliente(registro);

                if (cliente != null)
                {
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        private static Cliente getCliente(string registro)
        {
            if (registro == "")
            {
                return null;
            }

            int id = Repositorio.lerValorCampoInt(registro, "id");
            int numeroContrato = Repositorio.lerValorCampoInt(registro, "numContrato", false);
            string nome = Repositorio.lerValorCampoStr(registro, "nome");

            if (id <= 0)
            {
                return null;
            }

            Cliente cliente = new Cliente(id, nome);
            cliente.setNumeroContrato(numeroContrato);
            return cliente;
        }

        private static ArrayList getImoveis()
        {
            ArrayList imoveis = new ArrayList();

            while (Repositorio.leitorImoveis.Peek() >= 0)
            {
                string registro = Repositorio.leitorImoveis.ReadLine();
                Imovel imovel = Repositorio.getImovel(registro);

                if (imovel != null)
                {
                    imoveis.Add(imovel);
                }
            }

            return imoveis;
        }

        private static Imovel getImovel(string registro)
        {
            if (registro == "")
            {
                return null;
            }

            int id = Repositorio.lerValorCampoInt(registro, "id");
            string descricao = Repositorio.lerValorCampoStr(registro, "descricao");
            string sistuacao = Repositorio.lerValorCampoStr(registro, "situacao");
            double medidaAreaExterna = Repositorio.lerValorCampoDouble(registro, "medidaAreaExterna", false);
            int andar = Repositorio.lerValorCampoInt(registro, "andar", false);

            if (id <= 0)
            {
                return null;
            }

            if (andar > 0)
            {
                Imovel imovel = new Apartamento(id, descricao, sistuacao, andar);
                return imovel;
            }
            else if (medidaAreaExterna > 0)
            {
                Imovel imovel = new Casa(id, descricao, sistuacao, medidaAreaExterna);
                return imovel;
            }
            else
            {
                throw new Exception("O tipo do imóvel é inválido ou não foi localizado.");
            }
        }

        private static ArrayList getMovimentacoes()
        {
            ArrayList movimentacoes = new ArrayList();

            while (Repositorio.leitorImoveis.Peek() >= 0)
            {
                string registro = Repositorio.leitorMovimentacoes.ReadLine();
                Movimentacao movimentacao = Repositorio.getMovimentacao(registro);

                if (movimentacao != null)
                {
                    movimentacoes.Add(movimentacao);
                }
            }

            return movimentacoes;
        }

        private static Movimentacao getMovimentacao(string registro)
        {
            if (registro == "")
            {
                return null;
            }

            int id = Repositorio.lerValorCampoInt(registro, "id");
            int idImovel = Repositorio.lerValorCampoInt(registro, "idImovel");
            int idCliente = Repositorio.lerValorCampoInt(registro, "idCliente");
            string situacao = Repositorio.lerValorCampoStr(registro, "situacao");

            if (id <= 0)
            {
                return null;
            }

            Movimentacao movimentacao = new Movimentacao(id, idImovel, idCliente, situacao);
            return movimentacao;
        }

        private static double lerValorCampoDouble(string registro, string nomeCampo, bool obrigatorio = true)
        {
            double valor = 0;
            string valorCampo = Repositorio.lerValorCampoStr(registro, nomeCampo, obrigatorio);

            if (valorCampo != "")
            {
                valor = Convert.ToDouble(valorCampo);
            }

            return valor;
        }

        private static int lerValorCampoInt(string registro, string nomeCampo, bool obrigatorio = true)
        {
            int valor = 0;
            string valorCampo = Repositorio.lerValorCampoStr(registro, nomeCampo, obrigatorio);

            if (valorCampo != "")
            {
                valor = Convert.ToInt32(valorCampo);
            }

            return valor;
        }

        private static string lerValorCampoStr(string registro, string nomeCampo, bool obrigatorio = true)
        {
            string valor = "";

            //registro -> id=1|descricao=Casa|situacao=Alugado|medidaAreaExterna=100|
            if (registro != "")
            {
                int posCampo = registro.IndexOf(nomeCampo);

                if ((posCampo < 0) && obrigatorio)
                {
                    throw new Exception("O campo " + nomeCampo + " é inválido ou não foi localizado.");
                }

                if (posCampo >= 0)
                {
                    int qtdCaracteres = registro.Length - posCampo;
                    string subStr = registro.Substring(posCampo, qtdCaracteres);
                    //subStr -> situacao=Alugado|medidaAreaExterna=100|

                    int posIniValor = subStr.IndexOf("=") + 1;
                    int posFimValor = subStr.IndexOf("|");
                    qtdCaracteres = posFimValor - posIniValor;
                    valor = subStr.Substring(posIniValor, qtdCaracteres);
                    //valor -> Alugado
                }
            }

            return valor;
        }

        public static void salvarImobiliaria(Imobiliaria imobiliaria)
        {
            if (imobiliaria == null)
            {
                throw new Exception("O objeto imobiliária é inválido ou não foi informado.");
            }

            Repositorio.inicializarEscritores();
            Repositorio.salvarClientes(imobiliaria.getClientes());
            Repositorio.salvarImoveis(imobiliaria.getImoveis());
            Repositorio.salvarMovimentacoes(imobiliaria.getMovimentacoes());
            Repositorio.finalizarEscritores();
        }

        private static void salvarClientes(ArrayList clientes)
        {
            if (clientes != null)
            {
                foreach (Cliente cliente in clientes)
                {
                    Repositorio.salvarCliente(cliente);
                }
            }
        }

        private static void salvarCliente(Cliente cliente)
        {
            string registro =
                "id=" + cliente.getId().ToString() + "|" +
                "nome=" + cliente.getNome() + "|" +
                "numeroContrato=" + cliente.getNumeroContrato().ToString() + "|";

            Repositorio.escritorClientes.WriteLine(registro);
        }

        private static void salvarImoveis(ArrayList imoveis)
        {
            if (imoveis != null)
            {
                foreach (Imovel imovel in imoveis)
                {
                    Repositorio.salvarImovel(imovel);
                }
            }
        }

        private static void salvarImovel(Imovel imovel)
        {
            string registro =
                "id=" + imovel.getId().ToString() + "|" +
                "descricao=" + imovel.getDescricao() + "|" +
                "situacao=" + imovel.getSituacao() + "|";

            if (imovel is Casa)
            {
                Casa casa = imovel as Casa;
                registro = registro +
                    "medidaAreaExterna=" + casa.getMedidaAreaExterna().ToString() + "|";
            }

            if (imovel is Apartamento)
            {
                Apartamento apartamento = imovel as Apartamento;
                registro = registro +
                    "andar=" + apartamento.getAndar().ToString() + "|";
            }

            Repositorio.escritorImoveis.WriteLine(registro);
        }


        private static void salvarMovimentacoes(ArrayList movimentacoes)
        {
            if (movimentacoes != null)
            {
                foreach (Movimentacao movimentacao in movimentacoes)
                {
                    Repositorio.salvarMovimentacao(movimentacao);
                }
            }
        }

        private static void salvarMovimentacao(Movimentacao movimentacao)
        {
            string registro =
                "id=" + movimentacao.getId().ToString() + "|" +
                "idImovel=" + movimentacao.getIdImovel().ToString() + "|" +
                "idCliente=" + movimentacao.getIdCliente().ToString() + "|" +
                "situacao=" + movimentacao.getSituacao() + "|";

            Repositorio.escritorMovimentacoes.WriteLine(registro);
        }
    }
}
