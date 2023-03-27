using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

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
        public Todo(string description, Person person)
        {
            // Gera um código de identificação única e transforma em uma string de 8 caracteres
            _id = Guid.NewGuid().ToString().Substring(0, 8);

            // Data de criação atual da tarefa
            Created = DateTime.Now;

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
            return $"{Description} | {Category} | {DueDate} | {Status} | {Owner}";
        }

        // String para armazenar no backup
        public string ToFile()
        {
            return $"{_id}|{Description}|{Category}|{Created}|{DueDate}|{Status}|{Owner}";
        }

        public void setDueDate(string date)
        {
            DueDate = DateTime.Parse(date);
        }

        public void setDescription(string description)
        {
            Description = description;
        }

        public void setStatus() => Status = true ? false : true;

        public void setCategory(string category)
        {
            Category = category;
        }

        public void setPerson(Person person)
        {
            Owner = person;
        }
    }
}
