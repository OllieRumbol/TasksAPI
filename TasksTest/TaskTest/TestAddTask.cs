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

            AddTask task3 = new AddTask()
            {
                Task = "Task 3",
                Description = String.Empty,
                CompletedDate = DateTime.Now.ToString()
            };

            service.addNewTask(task1);
            service.addNewTask(task2);
            service.addNewTask(task3);

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
