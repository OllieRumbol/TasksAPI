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
        [ExpectedException(typeof(NullReferenceException))]
        public void testGetNextId_NullCheck()
        {
            //Arrange 
            List<Task> task = null;

            //Act
            service.getNextId(task);
            
            //Assert
            //Catch null reference
        }

        [TestMethod]
        public void testGetNextId_EmptyCheck()
        {
            //Arrange 
            List<Task> task = new List<Task>();

            //Act
            int id = service.getNextId(task);

            //Assert
            Assert.AreEqual(1, id);
        }

        [TestMethod]
        public void testGetNextId_Check()
        {
            //Arrange 
            List<Task> task = new List<Task>
            {
                new Task(Id: 1, Name: "Blank", null),
                new Task(Id: 2, Name: "Blank", null)
            };

            //Act
            int id = service.getNextId(task);

            //Assert
            Assert.AreEqual(3, id);
        }
    }
}
