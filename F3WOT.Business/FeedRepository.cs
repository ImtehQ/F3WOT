using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace F3WOT.Business
{
    public class FeedRepository //: IFancy interface here
    {
        private FeedDbContext _context;
        private string[] _urls;

        public FeedRepository(FeedDbContext context)
        {
            _context = context;
        }

        public void SetFeedUrls(string[] urls)
        {
            _urls = urls;
        }

        public void UpdateFromFeedUrls()
        {

        }

        public void GetFeeds()
        {

        }
    }
}
