using Microsoft.AspNetCore.Identity;
using MoviePoint.Models;
using MoviePoint.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePoint.tests
{
	[TestFixture]
	public class CommentsRepository_Test
	{
		public CommentsRepository commentsRepository;
		public Movie movie = new Movie();
		public IdentityUser identityUser = new IdentityUser();

		public CommentsRepository_Test()
		{
			commentsRepository = new CommentsRepository();
		}

		[Test]
		public void GetAll_ShouldReturnAllComments()
		{
			// Arrange

			// Act
			var comments = commentsRepository.GetAll();

			// Assert
			Assert.NotNull(comments);
			Assert.AreEqual(5, comments.Count); // assuming there are 5 comments in the database
		}

		[Test]
		public void GetById_ShouldReturnCommentWithMatchingId()
		{
			// Arrange
			var id = 1; // assuming there is a comment with id = 1 in the database

			// Act
			var comment = commentsRepository.GetById(id);

			// Assert
			Assert.NotNull(comment);
			Assert.AreEqual(id, comment.ID);
		}

		[Test]
		public void Insert_ShouldAddNewComment()
		{
			// Arrange
			var newComment = new Comment
			{
				comment = "Great movie",
			    userID=	identityUser.Id,
			    movieID=movie.Id,
				CommentDate = DateTime.Now
			};

			// Act
			commentsRepository.Insert(newComment);

			// Assert
			var insertedComment = commentsRepository.GetById(newComment.ID);
			Assert.NotNull(insertedComment);
			Assert.AreEqual(newComment.comment, insertedComment.comment);
			Assert.AreEqual(newComment.user, insertedComment.user);
			Assert.AreEqual(newComment.movie, insertedComment.movie);
			Assert.AreEqual(newComment.CommentDate, insertedComment.CommentDate);
		}

		[Test]
		public void Update_ShouldUpdateExistingComment()
		{
			// Arrange
			var id = 1;
			var updatedComment = new Comment
			{
				comment = "Updated comment",
				userID = identityUser.Id,
				movieID = movie.Id,
				CommentDate = DateTime.Now
			};

			// Act
			commentsRepository.Update(id, updatedComment);

			// Assert
			var orgComment = commentsRepository.GetById(id);
			Assert.NotNull(orgComment);
			Assert.AreEqual(updatedComment.comment, orgComment.comment);
			Assert.AreEqual(updatedComment.user, orgComment.user);
			Assert.AreEqual(updatedComment.movie, orgComment.movie);
			Assert.AreEqual(updatedComment.CommentDate, orgComment.CommentDate);
		}

		[Test]
		public void Delete_ShouldRemoveCommentWithMatchingId()
		{
			// Arrange
			var id = 1;

			// Act
			commentsRepository.Delete(id);

			// Assert
			var deletedComment = commentsRepository.GetById(id);
			Assert.Null(deletedComment);
		}
	}
}
