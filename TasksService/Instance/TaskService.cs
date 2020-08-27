using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksModels;
using TasksService.Interface;

namespace TasksService.Instance
{
    public class TaskService : ITaskService
    {
        public static List<Task> ToDoTasks = new List<Task>();

        public static List<Task> InProgressTasks = new List<Task>();

        public static List<Task> DoneTasks = new List<Task>();

        public int getNextId(List<Task> tasks)
        {
            return tasks.Max(t => t.Id);
        }
    }
}
