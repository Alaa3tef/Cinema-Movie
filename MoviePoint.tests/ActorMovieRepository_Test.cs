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
	public class ActorMovieRepository_Test
	{
		public ActorMovieRepository actorMovieRepository;

		[SetUp]
		public void SetUp()
		{

			actorMovieRepository = new ActorMovieRepository();
		}

		[Test]
		public void GetAll_ShouldReturnAllActorMovies1()
		{
			// Arrange

			// Act
			var result = actorMovieRepository.GetAll();

			// Assert
			Assert.AreEqual(24, result.Count);

		}

		[Test]
		public void GetAll_ShouldReturnAllActorMovies2()
		{
			// Arrange

			// Act
			var result = actorMovieRepository.GetAll();

			var Act = result.Count;
			
			// Assert
			Assert.AreEqual("same as 24", "same as " + Act);

		}
		[Test]
		public void GetAll_ShouldReturnAllActorMovies3()
		{
			// Arrange
			var actorMovieRepo = new ActorMovieRepository();
			var expectedCount = 24;

			// Act
			var result = actorMovieRepo.GetAll();

			// Assert
			Assert.AreEqual(expectedCount, result.Count);
		}

		[Test]
		public void GetAll_ShouldReturnAllActorMovies4()
		{
			// Arrange

			// Act
			var result = actorMovieRepository.GetAll();

			// Assert
			var Act = result.Count > 20;
			Assert.IsTrue(Act);

		}

		[Test]
		public void GetById_ShouldReturnCorrectActorMovie()
		{
			// Arrange
			int id = 29;

			// Act
			var result = actorMovieRepository.GetById(id);

			// Assert
			Assert.AreEqual("Ramez Galal", result.Actor.FullName);
			Assert.AreEqual("Ahmed Notrdam", result.Movie.Name);
		}

		[Test]
		public void GetByMovieId_ShouldReturnCorrectActorMovies()
		{
			// Arrange
			int movieId = 6;

			// Act
			var result = actorMovieRepository.GetByMovieId(movieId);

			// Assert
			Assert.AreEqual(5, result.Count);
		}

		[Test]
		public void Insert_ShouldAddNewActorMovie()
		{
			// Arrange
			var newActorMovie = new Actor_Movie()
			{
				ActorID = 23,
				MovieID = 11
			};

			// Act
			actorMovieRepository.Insert(newActorMovie);
			var result = actorMovieRepository.GetById(newActorMovie.ID);

			// Assert
			Assert.NotNull(result);
			Assert.AreEqual(newActorMovie.ActorID, result.ActorID);
			Assert.AreEqual(newActorMovie.MovieID, result.MovieID);
		}

		[Test]
		public void Update_ShouldUpdateActorMovie()
		{
			// Arrange
			int id = 1;
			var updatedActorMovie = new Actor_Movie()
			{
				ActorID = 23,
				MovieID = 12
			};

			// Act
			actorMovieRepository.Update(id, updatedActorMovie);
			var result = actorMovieRepository.GetById(id);

			// Assert
			Assert.AreEqual(updatedActorMovie.ActorID, result.ActorID);
			Assert.AreEqual(updatedActorMovie.MovieID, result.MovieID);
		}

		[Test]
		public void Delete_ShouldRemoveActorMovie()
		{
			// Arrange
			int id = 32;

			// Act
			actorMovieRepository.Delete(id);
			var result = actorMovieRepository.GetById(id);

			// Assert
			Assert.Null(result);
		}

		[Test]
		public void ActorById_ShouldReturnCorrectActorIds()
		{
			// Arrange
			int movieId = 13;
			List<int> expectedActorIds = new List<int>() { 23,24,25,27};

			// Act
			var result = actorMovieRepository.ActorById(movieId);

			// Assert
			Assert.AreEqual(expectedActorIds, result);
		}
	}
}
