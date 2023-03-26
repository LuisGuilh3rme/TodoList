using System.Xml.Serialization;
using TodoList.Lists;
internal class Program
{
    public static List<Person> people = new List<Person>();
    public static List<string> categories = new List<string>();
    public static List<Todo> todos = new List<Todo>();
    private static void Main(string[] args)
    {
        Menu();
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
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();
            }
            else valid = Choice(escolha);
        }
    }
    static bool Choice(int opt)
    {
        switch (opt)
        {
            case 1:
                CreateTask();
                break;
            case 2:
                // chamar metodo para visualizar tarefas
                PrintList();
                Console.ReadLine();
                break;
            case 3:
                // chamar metodo para remover tarefas
                break;
            case 4:
                // chamar metodo para editar tarefas
                EditTask();
                break;
            case 0:
                Console.WriteLine("Saindo do programa...");
                break;
            default:
                Console.WriteLine("Opção inválida! Tente novamente.");
                Console.WriteLine("Digite ENTER para continuar");
                Console.ReadLine();
                return false;
        }
        return true;
    }
    private static bool CreateTask()
    {
        Console.Clear();
        Console.Write("Nome da tarefa: ");
        string description = Console.ReadLine();
        Console.Write("Dono da tarefa: ");
        string ownerName = Console.ReadLine();
        Person owner = new Person(ownerName);
        todos.Add(new Todo(description, owner));
        return true;
    }
    private static bool EditTask()
    {
        Console.Clear();
        Console.WriteLine("== EDIT LIST ==");
        PrintList();
        Console.WriteLine("Escolha um item da lista para edição: ");
        int.TryParse(Console.ReadLine(), out int index);
        if (todos.Count < index || index < 1)
        {
            Console.WriteLine("Index inválido");
            Console.WriteLine("Digite ENTER para continuar");
            Console.ReadLine();
            return false;
        }
        index = index - 1;
        int editOption = 0;
        do
        {
            Console.Clear();
            Console.WriteLine(todos[index].ToString());
            Console.WriteLine("O que deseja editar?");
            Console.WriteLine("1 - Editar pessoa");
            Console.WriteLine("2 - Editar descrição");
            Console.WriteLine("3 - Editar categoria");
            Console.WriteLine("4 - Editar data final");
            int.TryParse(Console.ReadLine(), out editOption);
            if (editOption > 4 || editOption < 1) editOption = 0;
        } while (editOption == 0);
        switch (editOption)
        {
            case 1:
                todos[index].setPerson(new Person("JUBILEU"));
                break;
            case 2:
                Console.WriteLine("Insira a nova descrição: ");
                string description = Console.ReadLine();
                todos[index].setDescription(description);
                break;
            case 3:
                Console.WriteLine("Insira a nova categoria: ");
                string category = Console.ReadLine();
                todos[index].setCategory(category);
                break;
            case 4:
                Console.WriteLine("Insira a data de finalização (mm/dd/yyyy): ");
                string date = Console.ReadLine();
                todos[index].setDueDate(date);
                break;
        }
        Console.ReadLine();
        return true;
    }
    private static void PrintList()
    {
        int count = 0;
        foreach (Todo todo in todos)
        {
            Console.WriteLine($"{++count}) " + todo.ToString());
        }
    }
}