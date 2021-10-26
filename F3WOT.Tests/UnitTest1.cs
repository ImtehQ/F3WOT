using F3WOT.Business;
using F3WOT.Business.Interfaces;
using F3WOT.Business.Models;
using F3WOT.Business.Readers;
using System.Threading.Tasks;
using Xunit;

namespace F3WOT.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestNotNull_GetNuFeedFromUrl()
        {
            string nuRssUrl = @"https://www.nu.nl/rss/Tech" ;

            IFragileRssFeedReaderStrategyPattern nuStrategy = new NuFeedReader();


            FragileRssFeedReaderStrategyPattern FragileReader = 
                new FragileRssFeedReaderStrategyPattern(nuStrategy);

            var t = Task.Run(() => FragileReader.ReadUrlAsync(nuRssUrl));
            t.Wait();
            
            Assert.NotNull(t.Result);

        }
    }
}
