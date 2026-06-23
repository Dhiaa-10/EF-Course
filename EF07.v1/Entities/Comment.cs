using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF07.v1.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int TweetId { get; set; }
        public int CommentedBy { get; set; }
        public string? CommentText { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
