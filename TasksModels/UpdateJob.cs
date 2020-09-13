using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class UpdateJob
    {
        public int TaskId { get; set; }

        public int JobId { get; set; }

        public string JobName { get; set; }

        public bool Done { get; set; }
    }
}
