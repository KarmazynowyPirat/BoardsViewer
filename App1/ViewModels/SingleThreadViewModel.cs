using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using Newtonsoft.Json;

namespace App1.ViewModels
{
    public class SingleThreadViewModel : NotificationBase
    {
        public string CurrentBoard { get; set; }
        public string ThreadNumber { get; set; }

        public List<Post> Posts
        {
            get
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync("https://a.4cdn.org/"+CurrentBoard+"/thread/"+ThreadNumber+".json").Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var x = JsonConvert.DeserializeObject<ThreadPosts>(result);

                return x.posts;
            }
        }
    }
}
