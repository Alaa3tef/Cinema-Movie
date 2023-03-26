using MoviePoint.Models;
using MoviePoint.Repository;
using MoviePoint.ViewModel.Enum;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePoint.tests
{
	[TestFixture]
	public class MovieRepository_Test
	{
		private MovieRepository movieRepository;

		[SetUp]
		public void Setup()
		{
			movieRepository = new MovieRepository();
		}

		[Test]
		public void GetAll_ReturnsListOfMovies()
		{
			// Act
			List<Movie> movies = movieRepository.GetAll();

			// Assert
			Assert.IsNotNull(movies);
			Assert.IsInstanceOf<List<Movie>>(movies);
			Assert.Greater(movies.Count, 0);
		}

		[Test]
		public void GetById_ReturnsMovieWithGivenId()
		{
			// Arrange
			int movieId = 1;

			// Act
			Movie movie = movieRepository.GetById(movieId);

			// Assert
			Assert.IsNotNull(movie);
			Assert.IsInstanceOf<Movie>(movie);
			Assert.AreEqual(movieId, movie.Id);
		}

		[Test]
		public void Insert_AddsNewMovieToDatabase()
		{
			// Arrange
			Movie newMovie = new Movie
			{
				Name = "Test Movie",
				Price = 100,
				ProducerID = 1,
				StartDate = DateTime.Now,
				EndtDate = DateTime.Now.AddDays(7),
				Category = (MovieCategory)Enum.Parse(typeof(MovieCategory), "Action"),
				CinemaID = 1,
				Description = "Test Description",
				ImageUrl = "http://example.com/testmovie.jpg"
			};

			// Act
			movieRepository.Insert(newMovie);

			// Assert
			Movie insertedMovie = movieRepository.GetById(newMovie.Id);
			Assert.IsNotNull(insertedMovie);
			Assert.AreEqual(newMovie.Name, insertedMovie.Name);
			Assert.AreEqual(newMovie.Price, insertedMovie.Price);
			Assert.AreEqual(newMovie.ProducerID, insertedMovie.ProducerID);
			Assert.AreEqual(newMovie.StartDate, insertedMovie.StartDate);
			Assert.AreEqual(newMovie.EndtDate, insertedMovie.EndtDate);
			Assert.AreEqual(newMovie.Category, insertedMovie.Category);
			Assert.AreEqual(newMovie.CinemaID, insertedMovie.CinemaID);
			Assert.AreEqual(newMovie.Description, insertedMovie.Description);
			Assert.AreEqual(newMovie.ImageUrl, insertedMovie.ImageUrl);

			movieRepository.Delete(insertedMovie.Id);
		}

		[Test]
		public void Update_ShouldUpdateExistingMovie()
		{
			// Arrange
			var movieId = 1;
			var originalMovie = movieRepository.GetById(movieId);
			var updatedMovie = new Movie
			{
				Name = "Movie A (updated)",
				Price = 200,
				ProducerID = originalMovie.ProducerID,
				StartDate = originalMovie.StartDate,
				Category = (MovieCategory)Enum.Parse(typeof(MovieCategory), "Action"),
				CinemaID = originalMovie.CinemaID,
				Description = "Updated movie",
				ImageUrl = "http://www.example.com/image.png",
				EndtDate = originalMovie.EndtDate
			};

			// Act
			movieRepository.Update(movieId, updatedMovie);
			var result = movieRepository.GetById(movieId);

			// Assert
			Assert.AreEqual(updatedMovie.Name, result.Name);
			Assert.AreEqual(updatedMovie.Price, result.Price);
			Assert.AreEqual(updatedMovie.ProducerID, result.ProducerID);
			Assert.AreEqual(updatedMovie.StartDate, result.StartDate);
			Assert.AreEqual(updatedMovie.Category, result.Category);
			Assert.AreEqual(updatedMovie.CinemaID, result.CinemaID);
			Assert.AreEqual(updatedMovie.Description, result.Description);
			Assert.AreEqual(updatedMovie.ImageUrl, result.ImageUrl);
			Assert.AreEqual(updatedMovie.EndtDate, result.EndtDate);
		}

		[Test]
		public void Delete_ShouldRemoveExistingMovie()
		{
			// Arrange
			var movieToDelete = movieRepository.GetAll().First();
			var expectedCount = movieRepository.GetAll().Count - 1;

			// Act
			movieRepository.Delete(movieToDelete.Id);
			var result = movieRepository.GetAll();

			// Assert
			Assert.AreEqual(expectedCount, result.Count);
			Assert.IsFalse(result.Contains(movieToDelete));
		}

	}
}

