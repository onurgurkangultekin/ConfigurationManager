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

        [TestMethod]
        public void TestMethod_GetValue_ServiceA()
        {
            _reader = new ConfigurationReader("SERVICE-A", ConfigurationManager.ConnectionStrings["TrendyolEntities"].ConnectionString, 1000);
            string siteName = _reader.GetValue<string>("SiteName");
            Assert.AreEqual("trendyol.com", siteName);
        }

        [TestMethod]
        public void TestMethod_GetValue_ServiceB()
        {
            _reader = new ConfigurationReader("SERVICE-B", ConfigurationManager.ConnectionStrings["TrendyolEntities"].ConnectionString, 1000);
            bool isBasketEnabled = _reader.GetValue<bool>("IsBasketEnabled");
            Assert.AreEqual(true, isBasketEnabled);
        }

        [TestMethod]
        public void TestMethodIntervalRefresh()
        {
            _reader = new ConfigurationReader("SERVICE-B", ConfigurationManager.ConnectionStrings["TrendyolEntities"].ConnectionString, 1000);
            Thread.Sleep(5000);
            
        }
    }
}