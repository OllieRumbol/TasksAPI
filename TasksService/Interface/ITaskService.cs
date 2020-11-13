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

        List<Task> addNewTask(AddTask task);

        Task getTaskById(int id);

        List<Task> getAllTasks();

        List<Task> DeleteAllTasks();

        List<Task> DeleteTaskById(int id);

        List<Task> UpdateTaskDescription(int id, string description);

        List<Task> UpdateTaskName(int id, string name);

        List<Task> UpdateTaskStatus(int id, Status status);

        List<Task> UpdateTaskCompletedDate(int id, string completedDate);

        List<Task> AddJob(int taskId, string jobName);

        List<Task> DeleteJobById(int taskId, int jobId);

        List<Task> UpdateJobName(int taskId, int jobId, string jobName);

        List<Task> UpdateJobDone(int taskId, int jobId, bool done);
    }
}
