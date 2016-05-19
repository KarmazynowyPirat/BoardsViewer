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
    public class ThreadsViewModel : NotificationBase
    {
        public List<Thread> GetThreads
        {
            get
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync("https://a.4cdn.org/"+CurrentBoard+"/catalog.json").Result; //CurrentBoard
                var result = response.Content.ReadAsStringAsync().Result;

                var x = JsonConvert.DeserializeObject<List<ThreadRootObject>>(result);

                return x.FirstOrDefault().threads; //first page for now
            }
        }

        public string CurrentBoard { get; set; }
    }
}
