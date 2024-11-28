using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS.Movie.Dtos
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class CreateCommentDto
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
    public class UpdateCommentDto
    {
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}
