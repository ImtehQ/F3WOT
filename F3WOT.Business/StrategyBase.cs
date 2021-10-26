using F3WOT.Business.Interfaces;
using Microsoft.SyndicationFeed;
using Microsoft.SyndicationFeed.Rss;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace F3WOT.Business
{
    public class StrategyBase : IFragileRssFeedReaderStrategyPattern
    {
        public async Task<List<IFeed>> ReadFeedAsync(string url)
        {
            List<IFeed> Results = new();
            using (var xmlReader = XmlReader.Create(url, new XmlReaderSettings() { Async = true }))
            {
                var feedReader = new RssFeedReader(xmlReader);
                while (await feedReader.Read())
                {
                    if (feedReader.ElementType == SyndicationElementType.Item)
                    {
                        ISyndicationItem item = await feedReader.ReadItem();

                        Results.Add(Load(item));
                    }
                }
            }
            return Results;
        }

        public virtual IFeed Load(ISyndicationItem item)
        {
            throw new NotImplementedException();
        }
    }
}
