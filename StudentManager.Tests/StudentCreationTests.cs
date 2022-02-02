using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StudentManager.Data.Contexts;

namespace StudentManager.Tests
{
    [TestFixture]
    class StudentCreationTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void HasDbContext()
        {
            Assert.IsTrue(true);
        }
    }
}
