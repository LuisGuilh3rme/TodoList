using TodoList.Lists;

internal class Program
{
    private static void Main(string[] args)
    {
            Console.WriteLine("Menu de opções");
            Console.WriteLine("1 - Criar tarefa");
            Console.WriteLine("2 - Visualizar tarefas");
    }

    private static bool CreateTask()
    {
        Console.WriteLine("Nome da tarefa: ");
        string description = Console.ReadLine();

        Console.WriteLine("Dono da tarefa: ");
        string ownerName = Console.ReadLine();

        Person owner = new Person(ownerName);

        Todo todo = new Todo(description, owner);
        return true;
    }
}