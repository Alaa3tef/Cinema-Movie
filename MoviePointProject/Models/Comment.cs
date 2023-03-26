using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviePoint.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string comment { get; set; }

        [ForeignKey("user")]
        public string userID { get; set; }
        public virtual IdentityUser user{ get; set; }

        public DateTime CommentDate { get; set;}

        [ForeignKey("movie")]
        public int movieID { get; set; }
        public virtual Movie movie { get; set; }
        
    }
}
