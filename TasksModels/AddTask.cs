using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class AddTask
    {
        public string Task { get; set; }

        public string Description { get; set; }
    }

    public class AddTaskValidator : AbstractValidator<AddTask>
    {
        public AddTaskValidator()
        {
            RuleFor(t => t.Task).NotNull().NotEmpty();
        }
    }
}
