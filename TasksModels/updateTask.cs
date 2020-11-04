using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class UpdateTask
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string  Status { get; set; }
    }

    public class UpdateTaskValidator : AbstractValidator<UpdateTask>
    {
        public UpdateTaskValidator()
        {
            RuleFor(r => r.Id).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
