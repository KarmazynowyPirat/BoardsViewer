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
    public class BoardsViewModel : NotificationBase
    {
        public List<Board> Boards
        {
            get
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync("https://a.4cdn.org/boards.json").Result;
                var result = response.Content.ReadAsStringAsync().Result;

                var x = JsonConvert.DeserializeObject<RootObject>(result);
                
                return x.boards;
            }
        }

        public void NavigateToBoard()
        {

        }
    }
}
