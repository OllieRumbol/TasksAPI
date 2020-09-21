using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class AddJob
    {
        public int TaskId { get; set; }

        public string JobName { get; set; }
    }

    public class AddJobValidator : AbstractValidator<AddJob>
    {
        public AddJobValidator()
        {
            RuleFor(r => r.TaskId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(r => r.JobName).NotNull().NotEmpty();
        }
    }
}
