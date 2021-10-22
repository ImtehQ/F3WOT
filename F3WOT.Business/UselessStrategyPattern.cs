using F3WOT.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace F3WOT.Business
{
    public class UselessStrategyPattern
    {
        private IStrategy _strategy;

        public UselessStrategyPattern(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public Feed[] DoStuffOrSomethingIDK(string[] urls)
        {
            List<Feed> feedData = new List<Feed>();
            foreach (var url in urls)
            {
                feedData.Add<Feed>(this._strategy.DoSomethingIDK(url));
            }
            return feedData.ToArray();
        }
    }

    public interface IStrategy
    {
        Feed DoSomethingIDK(string rssFeed);
    }

    public class StrategyA : IStrategy
    {
        public Feed DoSomethingIDK(string rssFeed)
        {
            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load(rssFeed);

            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            return rssNodes.ToFeed();
        }
    }

    public class StrategyB : IStrategy
    {
        public Feed DoSomethingIDK(string rssFeed)
        {
            return null;
        }
    }

}
