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
        public ActionResult getAllTasks()
        {
            return Ok(service.getAllTasks());
        }

        [HttpGet("{id}")]
        public ActionResult getTaskById(int id)
        {
            if(id != 0)
            {
                return Ok(service.getTaskById(id));
            }

            return BadRequest();
        }

        [HttpPost]
        public ActionResult addTasks(AddTask task)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.addNewTask(task.Task));
            }

            return BadRequest();
        }

        [HttpDelete]
        public ActionResult deleteAllTasks()
        {
            return Ok(service.DeleteAllTasks());
        }

        [HttpDelete("{id}")]
        public ActionResult deleteTask(int id)
        {
            if (id != 0)
            {
                return Ok(service.DeleteTaskById(id));
            }

            return BadRequest();
        }
        
        [HttpPut]
        public ActionResult updateTaskName(UpdateTask task)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.UpdateTaskName(task.Id, task.Name));
            }

            return BadRequest();
        }

        [HttpPut("status")]
        public ActionResult updateTaskStatus(UpdateTask task)
        {
            if (ModelState.IsValid)
            {
                Status status = (Status)Enum.Parse(typeof(Status), task.Status, true);
                return Ok(service.UpdateTaskStatus(task.Id, status));
            }

            return BadRequest();
        }

        //JOBS
        [HttpPost("job")]
        public ActionResult addJob(AddJob job)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.AddJob(job.TaskId, job.JobName));
            }

            return BadRequest();
        } 

        [HttpDelete("job")]
        public ActionResult deleteJobById(DeleteJob job)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.DeleteJobById(job.TaskId, job.JobId));
            }

            return BadRequest();
        }

        [HttpPut("job")]
        public ActionResult updateJobName(UpdateJob job)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.UpdateJobName(job.TaskId, job.JobId, job.JobName));
            }

            return BadRequest();
        }

        [HttpPut("job/done")]
        public ActionResult updateJobDone(UpdateJob job)
        {
            if (ModelState.IsValid)
            {
                return Ok(service.UpdateJobDone(job.TaskId, job.JobId, job.Done));
            }

            return BadRequest();
        }
    }
}
