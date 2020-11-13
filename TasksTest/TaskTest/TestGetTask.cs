using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TasksModels;
using TasksService.Instance;
using TasksService.Interface;

namespace TasksTest
{
    [TestClass]
    public class TestGetTask
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testGetTask_GetTask()
        {
            //Arrange
            AddTask task1 = new AddTask()
            {
                Task = "Task 1",
                Description = String.Empty,
                CompletedDate = DateTime.Now.ToString()
            };

            AddTask task2 = new AddTask()
            {
                Task = "Task 2",
                Description = String.Empty,
                CompletedDate = DateTime.Now.ToString()
            };

            service.addNewTask(task1);
            service.addNewTask(task2);

            //Act
            Task result = service.getTaskById(1);

            //Assert
            Assert.AreEqual("Task 1", result.Name);
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
