using System;
using System.Collections.Generic;
using System.Linq;
namespace TodoList.Lists
{
    internal class Todo
    {
        private string _id;
        public string Description { get; private set; }
        public DateTime InitialDate { get; private set; }
        public DateTime DueDate { get; private set; }
        public bool Status { get; private set; }
        public string Category { get; private set; }
        public Person Person { get; private set; }
        public Todo(string description, Person person)
        {
            // Gera um código de identificação única e transforma em uma string de 8 caracteres
            _id = Guid.NewGuid().ToString().Substring(0, 8);

            // Data de criação atual da tarefa
            InitialDate = DateTime.Now;

            // Status da tarefa começa como ativo
            Status = true;

            // Categoria começa como nenhuma
            Category = "Nenhuma";

            Description = description;
            Person = person;
        }

        // String para visualização do usuário
        public override string ToString()
        {
            return base.ToString();
        }

        // String para armazenar no backup
        public string ToFile()
        {
            return "";
        }
    }
}
