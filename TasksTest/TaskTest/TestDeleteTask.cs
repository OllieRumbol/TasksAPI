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

            //Act
            service.DeleteTaskById(3);

            //Assert
            Assert.AreEqual(2, service.getAllTasks().Count);
        }

        [TestMethod]
        public void testDeleteTask_DeleteAllTasks()
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
