using MoviePoint.Models;

namespace MoviePoint.Repository
{
    public class CommentsRepository: ICommentsRepository
    {
        MoviePointContext context;

        public CommentsRepository()
        {
            context = new MoviePointContext();
        }

        public List<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

		public List<Comment> GetComments(int MovieId)
        {
            return context.Comments.Where(c=>c.movieID== MovieId).ToList();
        }


		public Comment GetById(int id)
        {
            return context.Comments.FirstOrDefault(c => c.ID == id);
        }
        public void Insert(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }
        public void Update(int id, Comment comment)
        {
            Comment org = GetById(id);
            org.comment = comment.comment;
            org.user = comment.user;
            org.movie = comment.movie;
            org.CommentDate = comment.CommentDate;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Comment org = GetById(id);
            context.Comments.Remove(org);
            context.SaveChanges();
        }
    }
}
