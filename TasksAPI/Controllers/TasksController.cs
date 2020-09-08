using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    }
}
