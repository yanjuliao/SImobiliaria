using System;

namespace SJImobiliaria
{
    class Pessoa
    {
        int id;
        string nome;

        public Pessoa(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int getId()
        {
            return this.id;
        }

        public string getNome()
        {
            return this.nome;
        }
    }
}
