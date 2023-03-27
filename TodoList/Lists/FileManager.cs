namespace TodoList.Lists
{
    internal class FileManager
    {
        static string Path = @"C:\\Users\\" + Environment.UserName;
        private string _backupPath;
        private StreamWriter _sw;
        private StreamReader _sr;

        // Armazena as tarefas
        public void WriteTodo(List<Todo> TodoList)
        {
            _backupPath = "Tasks.backup";
            _sw = new StreamWriter(_backupPath);
            _sw.Close();

            foreach (Todo task in TodoList)
            {
                WriteItem(task.ToFile());
            }
        }

        // Armazena as pessoas
        public void WritePerson(List<Person> persons)
        {
            _backupPath = "Persons.backup";
            _sw = new StreamWriter(_backupPath);
            _sw.Close();

            foreach (Person person in persons)
            {
                WriteItem(person.ToString());
            }
        }

        // Escreve item por item
        public void WriteItem(string item)
        {
            _sw = File.AppendText(_backupPath);

            try
            {
                _sw.WriteLine(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
            _sw.Close();
        }

        public List<Todo> LoadTodoFile(List<Person> persons)
        {
            _backupPath = "Tasks.backup";
            if (!FileExists()) return null;

            List<Todo> todos = new List<Todo>();
            _sr = new StreamReader(_backupPath);

            while (!_sr.EndOfStream)
            {
                string[] line = _sr.ReadLine().Split('|');
                string id = line[0];
                string description = line[1];
                string category = line[2];
                string created = line[3];
                string duedateString = line[4];
                string status = line[5];
                string owner = line[6];

                Person person;

                person = persons.Find(p => p.getId() == owner);
                if (person == null) person = new Person(owner);

                Todo todo = new Todo(description, person, created);
                todo.loadId(id);

                if (DateTime.TryParse(duedateString, out DateTime duedate))
                    todo.setDueDate(duedate);

                todo.setCategory(category);
                if (status == "False") todo.setStatus();
                todos.Add(todo);
            }

            _sr.Close();
            return todos;
        }

        public List<Person> LoadPersonFile()
        {
            _backupPath = "Persons.backup";
            if (!FileExists()) return null;

            _sr = new StreamReader(_backupPath);
            List<Person> persons = new List<Person>();

            while (!_sr.EndOfStream)
            {
                string[] line = _sr.ReadLine().Split('|');

                string id = line[0];
                string name = line[1];

                Person person = new Person(name);
                person.loadId(id);

                persons.Add(person);
            }

            _sr.Close();
            return persons;
        }

        public bool FileExists()
        {
            return File.Exists(_backupPath);
        }
    }
}
