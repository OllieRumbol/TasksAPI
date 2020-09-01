using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class Job : Identifier
    {
        public string Name { get; set; }

        public bool Done { get; set; }

        public Job(int Id, string Name, bool Done) : base(Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Done = Done;
        }
    }
}
