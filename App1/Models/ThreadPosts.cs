using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class Post
    {
        public int no { get; set; }
        public string now { get; set; }
        public string name { get; set; }
        public string com { get; set; }
        public string filename { get; set; }
        public string ext { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public int tn_w { get; set; }
        public int tn_h { get; set; }
        public long tim { get; set; }
        public int time { get; set; }
        public string md5 { get; set; }
        public int fsize { get; set; }
        public int resto { get; set; }
        public string id { get; set; }
        public string country { get; set; }
        public int bumplimit { get; set; }
        public int imagelimit { get; set; }
        public string semantic_url { get; set; }
        public string country_name { get; set; }
        public int replies { get; set; }
        public int images { get; set; }
        public int unique_ips { get; set; }
    }

    public class ThreadPosts
    {
        public List<Post> posts { get; set; }
    }
}
