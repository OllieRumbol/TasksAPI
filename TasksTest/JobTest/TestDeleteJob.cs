using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksModels;
using TasksService.Instance;
using TasksService.Interface;

namespace TasksTest.JobTest
{
    [TestClass]
    public class TestDeleteJob
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testDeleteJob_DeleteAJob()
        {
            //Arrange
            AddTask addTask = new AddTask()
            {
                Task = "Task 1",
                Description = String.Empty,
                CompletedDate = DateTime.Now.ToString()
            };

            service.addNewTask(addTask);

            service.AddJob(1, "Job 1");
            service.AddJob(1, "Job 2");

            //Act
            List<Task> result = service.DeleteJobById(1, 1);

            //Assert
            Assert.AreEqual(1, result.First().Jobs.Count());
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
