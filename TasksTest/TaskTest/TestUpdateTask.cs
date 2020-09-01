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
    public class TestUpdateTask
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testUpdateTask_UpdateTaskName()
        {
            //Arrange
            service.addNewTask("Task 1");

            //Act
            service.UpdateTaskName(1, "Task 2");
            Task result = service.getTaskById(1);

            //Assert
            Assert.AreEqual("Task 2", result.Name);
        }

        [TestMethod]
        public void testUpdateTask_UpdateTaskStatus()
        {
            //Arrange
            service.addNewTask("Task 1");

            //Act
            service.UpdateTaskStatus(1, Status.Done);
            Task result = service.getTaskById(1);

            //Assert
            Assert.AreEqual(Status.Done, result.Status);
        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
