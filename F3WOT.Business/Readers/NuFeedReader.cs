using F3WOT.Business.Interfaces;
using F3WOT.Business.Models;
using Microsoft.SyndicationFeed;

namespace F3WOT.Business.Readers
{
    public class NuFeedReader : StrategyBase
    {
        
        public override IFeed Load(ISyndicationItem item)
        {
            NuFeed feed = new();
            feed.Discription = item.Description;
            feed.Url = item.Id;
            feed.LastUpdated = item.LastUpdated;
            feed.Links = new();
            foreach (var link in item.Links)
            {
                feed.Links.Add(link.Uri.OriginalString);
            }
            feed.Published = item.Published;
            feed.Title = item.Title;
            return feed;
        }
    }
}
