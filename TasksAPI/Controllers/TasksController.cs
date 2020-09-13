using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TasksModels;
using TasksService.Interface;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskService service;

        public TasksController(ITaskService service)
        {
            this.service = service;
        }

        //TASKS
        [HttpGet]
        public JsonResult getTaskById()
        {
            return new JsonResult(service.getAllTasks());
        }

        [HttpGet("{id}")]
        public JsonResult getAllTasks(int id)
        {
            return new JsonResult(service.getTaskById(id));
        }

        [HttpPost]
        public JsonResult addTasks(AddTask task)
        {
            return new JsonResult(service.addNewTask(task.Task));
        }

        [HttpDelete]
        public JsonResult deleteAllTasks()
        {
            return new JsonResult(service.DeleteAllTasks());
        }

        [HttpDelete("{id}")]
        public JsonResult deleteTask(int id)
        {
            return new JsonResult(service.DeleteTaskById(id));
        }
        
        [HttpPut]
        public JsonResult updateTaskName(UpdateTask task)
        {
            Status status = (Status)Enum.Parse(typeof(Status), task.Status, true);

            return new JsonResult(service.UpdateTaskName(task.Id, task.Name, status));
        }

        //JOBS
        [HttpPost("job")]
        public JsonResult addJob(AddJob job)
        {
            return new JsonResult(service.AddJob(job.TaskId, job.JobName));
        } 

        [HttpDelete("job")]
        public JsonResult deleteJobById(DeleteJob job)
        {
            return new JsonResult(service.DeleteJobById(job.TaskId, job.JobId));
        }

        [HttpPut("job")]
        public JsonResult updateJobName(UpdateJob job)
        {
            return new JsonResult(service.UpdateJobName(job.TaskId, job.JobId, job.JobName));
        }

        [HttpPut("job/done")]
        public JsonResult updateJobDone(UpdateJob job)
        {
            return new JsonResult(service.UpdateJobDone(job.TaskId, job.JobId, job.Done));
        }
    }
}
