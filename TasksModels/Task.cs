using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class Task : Identifier
    {
        public string Name { get; set; }

        public List<Job> Jobs { get; set; }

        public Status Status { get; set; }

        public Task(int Id, string Name, List<Job> Jobs, Status Status) : base(Id)
        {
            this.Name = Name;
            this.Jobs = Jobs;
            this.Status = Status;
        }
    }

    public enum Status
    {
        ToDo,
        InProgress,
        Done
    }
}
