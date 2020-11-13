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
    public class TestUpdateJob
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testupdateJob_UpdateNameOfJob()
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

            //Act
            Task result = service.UpdateJobName(1, 1, "Job 2").First();

            //Assert
            Assert.AreEqual("Job 2", result.Jobs.First().Name);
        }

        [TestMethod]
        public void testupdateJob_UpdateStatusOfJob()
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

            //Act
            Task result = service.UpdateJobDone(1, 1, true).First();

            //Assert
            Assert.IsTrue(result.Jobs.First().Done);

        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
