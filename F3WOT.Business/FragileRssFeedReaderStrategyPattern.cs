using F3WOT.Business.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F3WOT.Business
{
    public class FragileRssFeedReaderStrategyPattern
    {
        private IFragileRssFeedReaderStrategyPattern _strategy;

        public FragileRssFeedReaderStrategyPattern(IFragileRssFeedReaderStrategyPattern strategy)
        {
            _strategy = strategy;
        }

        public Task<List<IFeed>> ReadUrlAsync(string url)
        {
            return _strategy.ReadFeedAsync(url);
        }
    }
}
