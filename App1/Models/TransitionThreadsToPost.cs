using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class TransitionThreadsToPost
    {
        public string CurrentBoard;
        public int ThreadId;

        public TransitionThreadsToPost(int id, string currentBoard)
        {
            this.ThreadId = id;
            this.CurrentBoard = currentBoard;
        }
    }
}
