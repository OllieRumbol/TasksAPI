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
            service.addNewTask("Blank");
            service.addNewTask("Blank2");

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
