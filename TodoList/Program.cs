using System.Xml.Serialization;
using TodoList.Lists;
internal class Program
{
    public static List<Person> personList { get; private set; }
    public static List<Todo> todos { get; private set; }
    public static FileManager fm = new();
    private static void Main(string[] args)
    {
        // Carregamento de arquivos
        LoadFiles();

        Menu();
    }
    static void Menu()
    {
        int escolha;

        do
        {
            Console.Clear();
            Console.WriteLine("== TO DO LIST MENU ==");
            Console.WriteLine("1 - Criar tarefa");
            Console.WriteLine("2 - Visualizar tarefas");
            Console.WriteLine("3 - Editar tarefas");
            Console.WriteLine("4 - Deletar tarefas");
            Console.WriteLine("0 - Sair");

            Console.Write("\nDigite a opção desejada: ");
            bool valid = int.TryParse(Console.ReadLine(), out escolha);

            if (!valid) escolha = -1;

            Choice(escolha);

        } while (escolha != 0);
    }
    static bool Choice(int opt)
    {
        Console.Clear();
        switch (opt)
        {
            case 1:
                CreateTask();
                break;
            case 2:
                // chamar metodo para visualizar tarefas
                int option;
                do
                {
                    Console.Clear();
                    Console.WriteLine("1 - Visualizar todas as tarefas");
                    Console.WriteLine("2 - Visualizar por categorias");
                    Console.WriteLine("\n\nEscolha uma opção: ");
                    option = int.Parse(Console.ReadLine());
                } while ((option != 1) && (option != 2));
                if(option == 1)
                {
                    if (!PrintList())
                    {
                        PrintError("Lista vazia!");
                        break;
                    }
                }
                else
                {
                    if (!PrintCategoryList())
                    {
                        PrintError("Lista vazia!");
                        break;
                    }
                }

                Console.ReadLine();
                break;
            case 3:
                // chamar metodo para editar tarefas
                EditTask();
                break;
            case 4:
                DeleteTask();
                break;
            case 0:
                Console.WriteLine("Saindo do programa...");
                WriteFiles();
                break;
            default:
                PrintError("Opção inválida! Tente novamente");
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

        Person person;
        person = personList.Find(person => person.Name == ownerName);
        if (person == null)
        {
            person = new Person(ownerName);
            personList.Add(person);
        }

        todos.Add(new Todo(description, person));
        return true;
    }
    private static bool EditTask()
    {
        Console.Clear();
        Console.WriteLine("== EDIT LIST ==");

        if (!PrintList())
        {
            PrintError("Lista vazia!");
            return false;
        }

        Console.WriteLine("Escolha um item da lista para edição: ");
        int.TryParse(Console.ReadLine(), out int index);

        if (todos.Count < index || index < 1)
        {
            PrintError("Index inválido");
            return false;
        }

        index = index - 1;
        int editOption = 0;

        do
        {
            Console.Clear();
            Console.WriteLine(todos[index].ToString());
            Console.WriteLine();
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
                Console.WriteLine("Insira o novo nome: ");
                string name = Console.ReadLine();

                Person person;
                person = personList.Find(p => p.Name == name);
                if (person == null)
                {
                    person = new Person(name);
                    personList.Add(person);
                }

                todos[index].setPerson(person);
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

        Console.WriteLine("Sucesso na edição! Digite ENTER para continuar");
        Console.ReadLine();
        return true;
    }
    private static bool PrintList()
    {
        if (todos.Count == 0) return false;

        Console.WriteLine("LISTA DE TAREFAS");

        int count = 0;
        foreach (Todo todo in todos)
        {
            Console.WriteLine("{0:D4}) {1} ", ++count, todo.ToString());
        }
        Console.WriteLine();

        return true;
    }

    static bool PrintCategoryList()
    {
        List<string> categories = new List<string>();
        if (todos.Count == 0) return false;
        foreach(Todo todo in todos)
        {
            
            if (categories.Exists(category => todo.Category != category))
            {
                categories.Add(todo.Category);
            }

        }
        foreach(string category in categories)
        {

        }

    }

    private static void WriteFiles()
    {
        fm.WriteTodo(todos);
        fm.WritePerson(personList);
    }

    private static void LoadFiles()
    {
        personList = fm.LoadPersonFile();
        todos = fm.LoadTodoFile(personList);

        if (personList == null) personList = new List<Person>();
        if (todos == null) todos = new List<Todo>();
    }

    private static void PrintError(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }

    static bool DeleteTask()
    {
        Console.WriteLine("O que deseja deletar?");
        PrintList();
        Console.WriteLine("Escolha um item da lista para remoção: ");
        int.TryParse(Console.ReadLine(), out int index);

        if (todos.Count < index || index < 1)
        {
            PrintError("Index inválido");
            return false;
        }
        todos.RemoveAt(index - 1);
        return true;
    }
}