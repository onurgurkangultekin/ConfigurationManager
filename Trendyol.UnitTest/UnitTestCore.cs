using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trendyol.Core;
using System.Configuration;
using System.Threading;

namespace Trendyol.UnitTest
{
    [TestClass]
    public class UnitTestCore
    {
        private IConfigurationReader _reader;

        public UnitTestCore()
        {
        }

        /// <summary>
        /// get siteName parameter for Service-A
        /// </summary>
        [TestMethod]
        public void TestMethod_GetValue_ServiceA()
        {
            _reader = new ConfigurationReader("SERVICE-A", ConfigurationManager.ConnectionStrings["TrendyolEntities"].ConnectionString, 1000);
            string siteName = _reader.GetValue<string>("SiteName");
            Assert.AreEqual("trendyol.com", siteName);
        }

        /// <summary>
        /// get IsBasketEnabled parameter for Service-B
        /// </summary>
        [TestMethod]
        public void TestMethod_GetValue_ServiceB()
        {
            _reader = new ConfigurationReader("SERVICE-B", ConfigurationManager.ConnectionStrings["TrendyolEntities"].ConnectionString, 1000);
            bool isBasketEnabled = _reader.GetValue<bool>("IsBasketEnabled");
            Assert.AreEqual(true, isBasketEnabled);
        }

        /// <summary>
        /// Create configurationReader and use it for 5 seconds. ConfigurationReader will go to the database for 5 times to refresh its cached data regarding 1000ms.
        /// </summary>
        [TestMethod]
        public void TestMethodIntervalRefresh()
        {
            _reader = new ConfigurationReader("SERVICE-B", ConfigurationManager.ConnectionStrings["TrendyolEntities"].ConnectionString, 1000);
            Thread.Sleep(5000);
            
        }
    }
}