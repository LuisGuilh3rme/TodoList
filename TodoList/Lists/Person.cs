namespace TodoList.Lists
{
    internal class Person
    {
        private string _id;
        public string Name { get; private set; }

        public Person(string name)
        {
            // Gera um código de identificação única e transforma em uma string de 8 caracteres
            _id = Guid.NewGuid().ToString().Substring(0, 8);

            Name = name;
        }

        public void setName(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{_id}|{Name}";
        }

        public string getId()
        {
            return _id;
        }

        public void loadId(string id) { _id = id; }
    }
}
