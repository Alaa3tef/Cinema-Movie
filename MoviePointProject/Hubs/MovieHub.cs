using Microsoft.AspNetCore.SignalR;
using MoviePoint.Models;

using MoviePoint.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoviePoint.Hubs
{
	public class MovieHub:Hub
    {
		
		IMovieRepository movieRepository;
		ICommentsRepository commentsRepository;
		public MovieHub( IMovieRepository _movRepo, ICommentsRepository _commentsRepo)
		{
			
			movieRepository = _movRepo;
			commentsRepository = _commentsRepo;
		}


		//public void NewComment(string cmt,string CommentDate,string movieID,string userid)
		//{
		//	Comment comment = new Comment();
		//	comment.comment=cmt;
		//	comment.CommentDate=DateTime.Parse(CommentDate);
		//	comment.movieID=int.Parse(movieID);
		//	comment.userID= userid;
		//	commentsRepository.Insert(comment);

		//	//notify  Another Online Client
		//	Clients.All.SendAsync("NewCommentNotify", comment);//nameof Client method,data 
		//												 //Clients.AllExcept(Context.ConnectionId).SendAsync("NewMessageNotify", name, message);//nameof Client method,data 

		//}

		//public void WriteComment(string name, string text, string CommentDate, string movieID, string userid)
		//{
		//	// Create a new comment object with the provided data
		//	Comment comment = new Comment();

		//	comment.comment = text;
		//	comment.CommentDate = DateTime.Parse(CommentDate);
		//	comment.movieID = int.Parse(movieID);
		//	comment.userID = userid;
		//	commentsRepository.Insert(comment);
		//	//comment.UserName = name;
		//	//comment.Text = text;


		//	//// Save the comment to the database
		//	//context.Comments.Add(comment);
		//	//context.SaveChanges();
		//	// Notify all connected clients that a new comment has been added
		//	//Clients.All.SendAsync("NewComment", name, text);
		//	Clients.All.SendAsync("NewComment", comment);
		//}

		public void WriteComment(string com, string MovieId , string UserID, string date)
		{
			Comment comment = new Comment();
			comment.comment = com;
			comment.movieID=int.Parse(MovieId);
			comment.userID = UserID;
			comment.CommentDate=DateTime.Parse(date);
			commentsRepository.Insert(comment);

			// Notify all connected clients that a new comment has been added
			Clients.All.SendAsync("NewComment", comment);
		}
	}
}
