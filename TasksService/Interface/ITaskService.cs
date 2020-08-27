using System;
using System.Collections.Generic;
using System.Text;
using TasksModels;

namespace TasksService.Interface
{
    public interface ITaskService
    {
        int getNextId(List<Task> tasks);
    }
}
