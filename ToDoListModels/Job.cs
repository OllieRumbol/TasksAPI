using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Done { get; set; }

        public Job(int Id, string Name, bool Done)
        {
            this.Id = Id;
            this.Name = Name;
            this.Done = Done;
        }
    }
}
