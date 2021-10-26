using Microsoft.SyndicationFeed;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F3WOT.Business.Interfaces
{
    public interface IFragileRssFeedReaderStrategyPattern
    {
        IFeed Load(ISyndicationItem item);
        Task<List<IFeed>> ReadFeedAsync(string url);
    }
}
