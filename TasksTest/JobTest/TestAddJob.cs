using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TasksService.Instance;
using TasksService.Interface;

namespace TasksTest.JobTest
{
    [TestClass]
    public class TestAddJob
    {
        ITaskService service;

        [TestInitialize]
        public void StartUp()
        {
            service = new TaskService();
        }

        [TestMethod]
        public void testAddJob_AddingJob()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestCleanup]
        public void CleanUp()
        {
            service.DeleteAllTasks();
        }
    }
}
