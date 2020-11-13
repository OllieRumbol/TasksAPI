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
    public class TestGetNextId
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testGetNextId_EmptyCheck()
        {
            //Arrange 

            //Act
            int id = service.getNextId(service.getAllTasks());

            //Assert
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void testGetNextId_Check()
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
            int id = service.getNextId(service.getAllTasks());

            //Assert
            Assert.AreEqual(3, id);
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
