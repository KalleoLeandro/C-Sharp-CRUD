using System;

namespace CRUD.net
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(String[] args)
        {
            string opcao = Menu();

            while(opcao.ToUpper() != "X")
            {
                switch(opcao)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();                     
                }         

                opcao = Menu();       
            }

        }

        private static void ListarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("---Listar Séries---");
            
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                Console.WriteLine("#ID{0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine();
            Console.WriteLine("---Inserir Nova Série---");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo =  Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno =  int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao =  Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAno, false);

            repositorio.Inserir(novaSerie);

        }

        private static void AtualizarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("---Atualizar Série---");

            Console.WriteLine();
            Console.WriteLine("Digite o id da série: ");                        
            int indiceSerie = int.Parse(Console.ReadLine());
           
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero =  int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo =  Console.ReadLine();

            Console.WriteLine("Digite o Ano da Série: ");
            int entradaAno =  int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao =  Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, descricao: entradaDescricao, ano: entradaAno, false);

            repositorio.Atualizar(indiceSerie, atualizaSerie);
        }
    

        private static void ExcluirSeries()
        {
            Console.WriteLine();
            Console.WriteLine("---Excluir Série---");

            Console.WriteLine();
            Console.WriteLine("Digite o id da série: ");

            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSeries()
        {
            Console.WriteLine();
            Console.WriteLine("---Visualizar Série---");

            Console.WriteLine();
            Console.WriteLine("Digite o id da série: ");

            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }

        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("---MENU---");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir Nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}

