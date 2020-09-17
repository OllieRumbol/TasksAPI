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
        public ActionResult getTaskById()
        {
            return Ok(service.getAllTasks());
        }

        [HttpGet("{id}")]
        public JsonResult getAllTasks(int id)
        {


            Response.StatusCode = 200;
            return new JsonResult(service.getTaskById(id));
        }

        [HttpPost]
        public JsonResult addTasks(AddTask task)
        {
            Response.StatusCode = 200;
            return new JsonResult(service.addNewTask(task.Task));
        }

        [HttpDelete]
        public ActionResult deleteAllTasks()
        {
            return Ok(service.DeleteAllTasks());
        }

        [HttpDelete("{id}")]
        public ActionResult deleteTask(int id)
        {
            return Ok(service.DeleteTaskById(id));
        }
        
        [HttpPut]
        public ActionResult updateTaskName(UpdateTask task)
        {
            return Ok(service.UpdateTaskName(task.Id, task.Name));
        }

        [HttpPut("status")]
        public ActionResult updateTaskStatus(UpdateTask task)
        {
            Status status = (Status)Enum.Parse(typeof(Status), task.Status, true);

            return Ok(service.UpdateTaskStatus(task.Id, status));
        }

        //JOBS
        [HttpPost("job")]
        public ActionResult addJob(AddJob job)
        {
            return Ok(service.AddJob(job.TaskId, job.JobName));
        } 

        [HttpDelete("job")]
        public ActionResult deleteJobById(DeleteJob job)
        {
            return Ok(service.DeleteJobById(job.TaskId, job.JobId));
        }

        [HttpPut("job")]
        public ActionResult updateJobName(UpdateJob job)
        {
            return Ok(service.UpdateJobName(job.TaskId, job.JobId, job.JobName));
        }

        [HttpPut("job/done")]
        public ActionResult updateJobDone(UpdateJob job)
        {
            return Ok(service.UpdateJobDone(job.TaskId, job.JobId, job.Done));
        }
    }
}
