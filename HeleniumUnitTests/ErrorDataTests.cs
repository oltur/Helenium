using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Helenium.Models;
using Helenium.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Helenium.UnitTests
{
    /// <summary>
    /// Errordata tests.
    /// </summary>
    [TestClass]
    public class ErrorDataTests
    {
        /// <summary>
        /// Creates the and save error data.
        /// </summary>
        [TestMethod]
        public void CreateAndSaveErrorData()
        {
            var mockSet = new Mock<DbSet<ErrorData>>();

            var mockContext = new Mock<HeleniumDbContext>();
            mockContext.Setup(m => m.ErrorData).Returns(mockSet.Object);

            var db = mockContext.Object;
            db.ErrorData.Add(new ErrorData() { Message = "test", Parent = null });
            db.SaveChanges();

            mockSet.Verify(m => m.Add(It.IsAny<ErrorData>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Gets all configuration data.
        /// </summary>
        [TestMethod]
        public void GetAllErrorData()
        {
            var data = new List<ErrorData>
            {
                new ErrorData { Message = "1", Parent = null },
                new ErrorData { Message = "2", Parent = null },
                new ErrorData { Message = "3", Parent = null }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ErrorData>>();
            mockSet.As<IQueryable<ErrorData>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ErrorData>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ErrorData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ErrorData>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<HeleniumDbContext>();
            mockContext.Setup(c => c.ErrorData).Returns(mockSet.Object);

            var configDatas = mockContext.Object.ErrorData.ToList();

            Assert.AreEqual(3, configDatas.Count);
            Assert.AreEqual("1", configDatas[0].Message);
            Assert.AreEqual("2", configDatas[1].Message);
            Assert.AreEqual("3", configDatas[2].Message);
        }

    }
}
