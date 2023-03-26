namespace TodoList.Lists
{
    internal class FileManager
    {
        static string Path = @"C:\\Users\\" + Environment.UserName;
        private string _backupPath;
        private StreamWriter _sw;
        private StreamReader _sr;

        public FileManager(string fileName)
        {
            _backupPath = fileName + ".backup";
        }

        // Armazena as tarefas
        public void WriteTodo(List<Todo> TodoList)
        {
            foreach (Todo task in TodoList)
            {
                WriteItem(task.ToFile());
            }
        }

        // Armazena as categorias
        public void WriteCategory(List<string> categories)
        {
            foreach (string category in categories)
            {
                WriteItem(category);
            }
        }

        public void WriteItem(string item)
        {
            _sw = new StreamWriter(_backupPath);

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

        public List<Todo> LoadTodoFile()
        {
            return null;
        }

        public List<string> LoadCategoryFile()
        {
            return null;
        }

        public bool FileExists()
        {
            return File.Exists(_backupPath);
        }
    }
}
