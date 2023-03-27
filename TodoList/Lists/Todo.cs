namespace TodoList.Lists
{
    internal class Todo
    {
        private string _id;
        public string Description { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool Status { get; private set; }
        public string Category { get; private set; }
        public Person Owner { get; private set; }
        public Todo(string description, Person person, string? created = null)
        {
            // Gera um código de identificação única e transforma em uma string de 8 caracteres
            _id = Guid.NewGuid().ToString().Substring(0, 8);

            // Data de criação atual da tarefa
            if (created != null) Created = DateTime.Parse(created);
            else Created = DateTime.Now;

            DueDate = Created;

            // Status da tarefa começa como ativo
            Status = true;

            // Categoria começa como nenhuma
            Category = "Nenhuma";

            Description = description;
            Owner = person;
        }

        // String para visualização do usuário
        public override string ToString()
        {
            return $"{Description.PadRight(30)} | {Category.PadRight(15)} | {DueDate} | {Status.ToString().PadRight(7)} | {Owner.Name}";
        }

        // String para armazenar no backup
        public string ToFile()
        {
            return $"{_id}|{Description}|{Category}|{Created}|{DueDate}|{Status}|{Owner.getId()}";
        }

        public void setDueDate(DateTime date) { DueDate = date; }

        public void setDescription(string description) { Description = description; }

        public void setCategory(string category) { Category = category;  }
        public void setPerson(Person person) { Owner = person; }

        public void loadId(string id) { _id = id; }
        public void setStatus() => Status = true ? false : true;
    }
}
