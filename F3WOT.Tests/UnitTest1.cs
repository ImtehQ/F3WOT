using F3WOT.Business;
using F3WOT.Business.Models;
using System;
using Xunit;

namespace F3WOT.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string[] feedUrls = new string[] { "https://www.nu.nl/rss/Tech" };
            IStrategy strategy = new StrategyA();
            UselessStrategyPattern usp = new UselessStrategyPattern(strategy);

            Feed[] feedDataArray = usp.DoStuffOrSomethingIDK(feedUrls);

            Assert.Single(feedDataArray);

        }
    }
}
