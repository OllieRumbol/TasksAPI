using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TasksModels
{
    public class DeleteJob
    {
        public int TaskId { get; set; }

        public int JobId { get; set; }
    }

    public class DeleteJobValidator : AbstractValidator<DeleteJob>
    {
        public DeleteJobValidator()
        {
            RuleFor(r => r.TaskId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(r => r.JobId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
