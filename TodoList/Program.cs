using System.Xml.Serialization;
using TodoList.Lists;
internal class Program
{
    private static void Main(string[] args)
    {
        Menu();
    }
    private static bool CreateTask()
    {
        Console.Clear();
        Console.Write("Nome da tarefa: ");
        string description = Console.ReadLine();
        Console.Write("Dono da tarefa: ");
        string ownerName = Console.ReadLine();
        Person owner = new Person(ownerName);
        Todo todo = new Todo(description, owner);
        return true;
    }
    static void Menu()
    {
        int escolha = -1; // aguarda a entrada do usuario para definir o valor, se continuar -1 é porque o usuario errou
        while (escolha != 0)
        {
            Console.Clear();
            Console.WriteLine("== TO DO LIST MENU ==");
            Console.WriteLine("1 - Criar tarefa");
            Console.WriteLine("2 - Visualizar tarefas");
            Console.WriteLine("3 - Remover tarefas");
            Console.WriteLine("4 - Editar tarefas");
            Console.WriteLine("0 - Sair");
            Console.Write("\nDigite a opção desejada: ");
            bool valid = int.TryParse(Console.ReadLine(), out escolha);
            if (!valid)
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else Choice(escolha);
        }
    }
    static void Choice(int opt)
    {
        switch (opt)
        {
            case 1:
                CreateTask();
                break;
            case 2:
                // chamar metodo para visualizar tarefas
                break;
            case 3:
                // chamar metodo para remover tarefas
                break;
            case 4:
                // chamar metodo para editar tarefas
                break;
            case 0:
                Console.WriteLine("Saindo do programa...");
                break;
            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                Thread.Sleep(1000);
                Console.Clear();
                Menu();
                break;
        }
    }
}