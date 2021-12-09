# SJImobiliaria

Sistema de uma imobiliária que permite ao usuário controlar os imóveis da mesma, quais imóveis ela tem disponível, quais estão alugados, quais serão vendidos, quem são os residentes, entre outros...

--------------------------------------------------------------------------------------------------------------------------------------------------------------------

Relatório 25/11

Até o momento ainda estamos trabalhando na arquitetura do projeto, quais serão as classes e como irão funcionar. Estamos em fase de planejamento


--------------------------------------------------------------------------------------------------------------------------------------------------------------------

Relatório 12/11

Começei a programar o projeto, criei 5 classes, uma chamada Imóvel e duas que herdam dela chamadas, casa e apartamento, uma classe morador e uma classe imobiliaria. Na classe Imóvel já crieis os atributos bases e também iniciei a concepção da classe casa que possui 2 Métodos, CadastrarCasa() e ExcluirCasa().

Abaixo um pouco do que já fiz: 

using System;

class Imovel
{
    private double Area, CEP, PreçoLocação;
    public bool Alugado;

    public void SetArea(double area)
    {
        Area = area;
    }

    public void SetCEP(double cep)
    {
       CEP = cep;
    }

    public void GetArea()
    {
        Console.WriteLine(Area);
    }

    public void GetCEP()
    {
        Console.WriteLine(CEP);
    }

    class Casa : Imovel
    {
        string Endereço;

        public void CadastrarCasa( double area, double preçolocação, string endereço, double cep)
        {
            Console.WriteLine("Informe a area da casa em m²: ");
            area = Convert.ToDouble(Console.ReadLine());
            SetArea(area);

            Console.WriteLine("Informe o endereço da casa: ");
            endereço = Console.ReadLine();
            Endereço = endereço;

            Console.WriteLine("Informe o CEP: ");
            cep = Convert.ToDouble(Console.ReadLine());
            SetCEP(cep);
            
            Console.WriteLine("Informe o preço de locação da casa: ");
            preçolocação = Convert.ToDouble(Console.ReadLine());
            PreçoLocação = preçolocação;
        }

        public void ExcluirCasa()
        {
            SetArea(0);
            Endereço = "";
            PreçoLocação = 0;
            SetCEP(0);
        }
    }

    class Apartamento : Imovel
    {

    }

    class Morador
    {

    }

    class Imobiliaria
    {
        Casa[] CasasAlugadas = new Casa[100];
        Casa[] CasasDisponíveis = new Casa[100];
    }

    class Program
    {
        public static void Main(string[] args)
        {
            
        }
    }
}
