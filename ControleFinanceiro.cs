using System;
using System.Collections.Generic;
using System.Linq;

class Gastos
{
    public double Valor { get; set; }
    public string Descricao { get; set; }
    public string Categoria { get; set; }

    public Gastos(double valor, string descricao, string categoria)
    {
        this.Valor = valor;
        this.Descricao = descricao;
        this.Categoria = categoria;

    }
    public override string ToString()
    {
        return $"R${Valor} - {Descricao} ({Categoria})";
    }
}

class ControleFinanceiro
{
    private List<Gastos> gastos = new List<Gastos>();
    public void AdicionarGastos(Gastos g)
    {
        gastos.Add(g);
        Console.WriteLine("Gasto adicionado com sucesso!");
    }

    public void ListarGastos()
    {
        if (gastos.Count == 0)
        {
            Console.WriteLine("Nenhum gasto encontrado");
            return;
        }
        foreach (var g in gastos)
        {
            Console.WriteLine(g);
        }
    }

    public void MostrarTotal()
    {
        double total = gastos.Sum(g => g.Valor);
        Console.WriteLine($"Valor total gasto: R${total}");
    }

    public void FiltrarPelaCategoria(string categoria)
    {
        var filtrados = gastos.Where(g => g.Categoria.ToLower() == categoria.ToLower()).ToList();
        if (filtrados.Count == 0)
        {
            Console.WriteLine("Nenhum gasto nessa categoria.");
            return;
        }

        foreach (var g in filtrados)
            Console.WriteLine(g);
    }
}

class Program
{
    static void Main()
    {
        ControleFinanceiro cf = new ControleFinanceiro();
        int opcao;

        do
        {
            Console.WriteLine("Sistema de Controle Financeiro");
            Console.WriteLine("1 - Registrar gasto: ");
            Console.WriteLine("2 - Listar gastos: ");
            Console.WriteLine("3 - Mostrar gasto total: ");
            Console.WriteLine("4 - Filtrar por categoria: ");
            Console.Write("Digite a opção desejada: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Write("Valor: R$ ");
                    double valor = double.Parse(Console.ReadLine());
                    Console.Write("Descrição: ");
                    string descricao = Console.ReadLine();
                    Console.Write("Categoria: ");
                    string categoria = Console.ReadLine();
                    cf.AdicionarGastos(new Gastos(valor, descricao, categoria));
                    break;

                case 2:
                    cf.ListarGastos();
                    break;

                case 3:
                    cf.MostrarTotal();
                    break;

                case 4:
                    Console.WriteLine("Categoria: ");
                    string category = Console.ReadLine();
                    cf.FiltrarPelaCategoria(category);
                    break;

                case 0:
                    Console.WriteLine("0 - Sair");
                    break;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;


            }




        } while (opcao != 0);
    }
}