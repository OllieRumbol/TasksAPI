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

        public List<Task> addNewTask(List<Task> tasks, string name)
        {
            Task newTask = new Task(Id: getNextId(tasks), Name: name, Jobs: new List<Job>());
            tasks.Add(newTask);
            return tasks;
        }

        public int getNextId(List<Task> tasks)
        {
            if(tasks == null)
            {
                throw new NullReferenceException();
            }
            else if (tasks.Count == 0)
            {
                return 1;
            }
            else
            {
                return tasks.Max(t => t.Id) + 1;
            }
        }
    }
}
