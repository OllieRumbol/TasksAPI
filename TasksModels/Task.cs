using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Job> Jobs { get; set; }

        public Task(int Id, string Name, IEnumerable<Job> Jobs)
        {
            this.Id = Id;
            this.Name = Name;
            this.Jobs = Jobs;
        }
    }
}
