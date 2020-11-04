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
        public static List<Task> Tasks = new List<Task>();

        public List<Task> AddJob(int taskId, string jobName)
        {
            foreach(Task task in Tasks)
            {
                if(task.Id == taskId)
                {
                    task.Jobs.Add(new Job(Id: getNextId(task.Jobs), Name: jobName, Done: false));
                    break;
                }
            }

            return Tasks;
        }

        public List<Task> addNewTask(string name, string description)
        {
            Task newTask = new Task(
                                    Id: getNextId(Tasks), 
                                    Name: name, 
                                    Description: description, 
                                    Jobs: new List<Job>(), 
                                    Status: TasksModels.Status.ToDo);
            Tasks.Add(newTask);
            return Tasks;
        }

        public List<Task> DeleteAllTasks()
        {
            Tasks.Clear();
            return Tasks;
        }

        public List<Task> DeleteJobById(int taskId, int jobId)
        {
            foreach (Task task in Tasks)
            {
                if (task.Id == taskId)
                {
                    task.Jobs.RemoveAll(j => j.Id == jobId);
                    break;
                }
            }

            return Tasks;
        }

        public List<Task> DeleteTaskById(int id)
        {
            Tasks.RemoveAll(t => t.Id == id);
            return Tasks;
        }

        public List<Task> getAllTasks()
        {
            return Tasks;
        }

        public int getNextId<T>(List<T> list) where T : Identifier
        {
            if(list == null)
            {
                throw new NullReferenceException();
            }
            else if (list.Count == 0)
            {
                return 1;
            }
            else
            {
                return list.Max(t => t.Id) + 1;
            }
        }

        public Task getTaskById(int id)
        {
            return Tasks.FirstOrDefault(t => t.Id == id);
        }

        public List<Task> UpdateJobDone(int taskId, int jobId, bool done)
        {
            foreach (Task task in Tasks)
            {
                if (task.Id == taskId)
                {
                    foreach (Job job in task.Jobs)
                    {
                        if (job.Id == jobId)
                        {
                            job.Done = done;
                            break;
                        }
                    }
                }
            }

            return Tasks;
        }

        public List<Task> UpdateJobName(int taskId, int jobId, string jobName)
        {
            foreach (Task task in Tasks)
            {
                if (task.Id == taskId)
                {
                    foreach(Job job in task.Jobs)
                    {
                        if(job.Id == jobId)
                        {
                            job.Name = jobName;
                            break;
                        }
                    }
                }
            }

            return Tasks;
        }

        public List<Task> UpdateTaskDescription(int id, string description)
        {
            foreach (Task task in Tasks)
            {
                if (task.Id == id)
                {
                    task.Description = description;
                    break;
                }
            }

            return Tasks;
        }

        public List<Task> UpdateTaskName(int id, string name)
        {
            foreach(Task task in Tasks)
            {
                if(task.Id == id)
                {
                    task.Name = name;
                    break;
                }
            }

            return Tasks;
        }

        public List<Task> UpdateTaskStatus(int id, Status status)
        {
            foreach (Task task in Tasks)
            {
                if (task.Id == id)
                {
                    task.Status = status;
                    break;
                }
            }

            return Tasks;
        }
    }
}
