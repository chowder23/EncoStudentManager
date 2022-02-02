using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StudentManager.Data.Contexts;
using StudentManager.Data.Entities;
using StudentManager.Data.Interfaces;
using StudentManager.Logic.Modules.StudentModule;
using StudentManager.Logic.Modules.StudentModule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManager.Test
{
    public class Tests
    {
        [TestFixture]
        class StudentCreationTests
        {
            private Mock<IStudentManagerContext> mockDb;
            private StudentService _service;
            private List<Student> _students;
            [SetUp]
            public void SetUp()
            {
                _students = new List<Student>();
                mockDb = new Mock<IStudentManagerContext>();
                mockDb.Setup(s => s.Students).Returns(ToDbSet<Student>(_students));
                var statisticService = new StudentStatisticService(mockDb.Object);
                _service = new StudentService(mockDb.Object, statisticService);
            }

            [Test]
            public void AddNewStudent_Succeed()
            {
                _service.AddNewStudent(new AddNewStudentDto { Name = "jani" });
                Assert.IsNotEmpty(_students);
            }

            private DbSet<T> ToDbSet<T>(List<T> sourceList) where T : class
            {
                var queryable = sourceList.AsQueryable();

                var dbSet = new Mock<DbSet<T>>();
                dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
                dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
                dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
                dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
                dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>(sourceList.Add);
                return dbSet.Object;
            }
        }


    }
}