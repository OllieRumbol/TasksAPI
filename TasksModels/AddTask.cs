using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class AddTask
    {
        public string Task { get; set; }
    }

    public class AddTaskValidator : AbstractValidator<AddTask>
    {
        public AddTaskValidator()
        {
            RuleFor(t => t.Task).NotNull().NotEmpty();
        }
    }
}
