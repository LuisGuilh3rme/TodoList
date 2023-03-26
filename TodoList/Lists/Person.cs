using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Name;
        }
    }
}
