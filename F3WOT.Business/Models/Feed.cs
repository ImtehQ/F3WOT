using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F3WOT.Business.Models
{
    public class Feed
    {

    }

    public class rss
    {
        public rssChannel channel;
        public decimal version;    
    }

    public partial class rssChannel
    {
        public string title;
        public string link;
        public string description;
        public link link1;
        public string language;
        public string copyright;
        public string lastBuildDate;
        public byte ttl;
        public string logo;
        public rssChannelItem item;    
    }

    public class link
    {
        public string href;
        public string rel;  
    }


    public class rssChannelItem
    {
        public string title;
        public string link;
        public string description;
        public string pubDate;
        public rssChannelItemGuid guid;
        public rssChannelItemEnclosure enclosure;
        public string[] category;
        public string creator;
        public string rights;    
    }

    public class rssChannelItemGuid
    {
        public bool isPermaLink;
        public string value;
    }

    public class rssChannelItemEnclosure
    {
        public byte length;
        public string type;
        public string url;
    }


}
