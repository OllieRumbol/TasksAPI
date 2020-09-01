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
            service.addNewTask("Task 1");
            service.addNewTask("Task 2");

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
