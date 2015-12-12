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
    /// ConfigData tests.
    /// </summary>
    [TestClass]
    public class ConfigDataTests
    {
        /// <summary>
        /// Creates the and save configuration data.
        /// </summary>
        [TestMethod]
        public void CreateAndSaveConfigData()
        {
            var mockSet = new Mock<DbSet<ConfigData>>();

            var mockContext = new Mock<HeleniumDbContext>();
            mockContext.Setup(m => m.ConfigData).Returns(mockSet.Object);

            var db = mockContext.Object;
            db.ConfigData.Add(new ConfigData() {DelayMs = 2, IsDebugger = true, LogPath = "3", MaxHtmlLength = 4, UrlPattern ="5"});
            db.SaveChanges();

            mockSet.Verify(m => m.Add(It.IsAny<ConfigData>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        /// <summary>
        /// Gets all configuration data.
        /// </summary>
        [TestMethod]
        public void GetAllConfigData()
        {
            var data = new List<ConfigData>
            {
                new ConfigData { DelayMs = 2, IsDebugger = true, LogPath = "1", MaxHtmlLength = 4, UrlPattern ="5" },
                new ConfigData { DelayMs = 2, IsDebugger = true, LogPath = "2", MaxHtmlLength = 4, UrlPattern ="5" },
                new ConfigData { DelayMs = 2, IsDebugger = true, LogPath = "3", MaxHtmlLength = 4, UrlPattern ="5" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<ConfigData>>();
            mockSet.As<IQueryable<ConfigData>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<ConfigData>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<ConfigData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<ConfigData>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<HeleniumDbContext>();
            mockContext.Setup(c => c.ConfigData).Returns(mockSet.Object);

            var configDatas = mockContext.Object.ConfigData.ToList();

            Assert.AreEqual(3, configDatas.Count);
            Assert.AreEqual("1", configDatas[0].LogPath);
            Assert.AreEqual("2", configDatas[1].LogPath);
            Assert.AreEqual("3", configDatas[2].LogPath);
        }

        /// <summary>
        /// Tests URLData serialization.
        /// </summary>
        [TestMethod]
        public void TestURLData()
        {
            var data1 = new ConfigData();

            data1.Urls.Add(new URLData("1", false, 1));
            data1.Urls.Add(new URLData("2", false, 2));
            data1.Urls.Add(new URLData("3", false, 3));

            string serialized = data1.UrlsSerialized;

            var data2 = new ConfigData();
            data2.UrlsSerialized = serialized;

            foreach (var url in data2.Urls)
            {
                Assert.AreEqual(url.URL, url.Level.ToString());
            }
        }
    }
}
