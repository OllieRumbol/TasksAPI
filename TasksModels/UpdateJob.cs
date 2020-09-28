using FluentValidation;
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

    public class UpdateJobValidator : AbstractValidator<UpdateJob>
    {
        public UpdateJobValidator()
        {
            RuleFor(r => r.TaskId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(r => r.JobId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
