using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TasksModels;

namespace TasksService.Interface
{
    public interface ITaskService
    {
        int getNextId<T>(List<T> list) where T : Identifier;

        List<Task> addNewTask(string name);

        Task getTaskById(int id);

        List<Task> getAllTasks();

        List<Task> DeleteAllTasks();

        List<Task> DeleteTaskById(int id);

        List<Task> UpdateTaskName(int id, string name, Status status);

        List<Task> AddJob(int taskId, string jobName);

        List<Task> DeleteJobById(int taskId, int jobId);

        List<Task> UpdateJobName(int taskId, int jobId, string jobName);

        List<Task> UpdateCheckJob(int taskId, int jobId);
    }
}
