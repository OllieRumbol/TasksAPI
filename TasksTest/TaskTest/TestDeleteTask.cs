using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TasksService.Instance;
using TasksService.Interface;

namespace TasksTest
{
    [TestClass]
    public class TestDeleteTask
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testDeleteTask_DeleteATask()
        {
            //Arrange
            service.addNewTask("Task 1");
            service.addNewTask("Task 2");
            service.addNewTask("Task 3");

            //Act
            service.DeleteTaskById(3);

            //Assert
            Assert.AreEqual(2, service.getAllTasks().Count);
        }

        [TestMethod]
        public void testDeleteTask_DeleteAllTasks()
        {
            //Arrange
            service.addNewTask("Task 1");
            service.addNewTask("Task 2");
            service.addNewTask("Task 3");

            //Act
            service.DeleteAllTasks();

            //Assert
            Assert.AreEqual(0, service.getAllTasks().Count);
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
