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
    public class TestAddTask
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testAddTask_AddingTask()
        {
            //Arrange 

            //Act
            service.addNewTask("Task 1");
            service.addNewTask("Task 2");
            service.addNewTask("Task 3");

            //Assert
            Assert.AreEqual(3, service.getAllTasks().Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
