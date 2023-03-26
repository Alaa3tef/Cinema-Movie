using MoviePoint.Models;
using MoviePoint.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace MoviePoint.tests
{
	[TestFixture]
	public class CinemaRepository_Test
	{
			public CinemaRepository cinemaRepository;

			[SetUp]
			public void SetUp()
			{

			    cinemaRepository = new CinemaRepository();
			}

			[Test]
			public void GetAll_ReturnsListOfCinemas()
			{
				// Act
				List<Cinema> cinemas = cinemaRepository.GetAll();

				// Assert
				Assert.IsNotNull(cinemas);  // yes
				Assert.IsInstanceOf<List<Cinema>>(cinemas);  // yes
				Assert.Greater(cinemas.Count, 0);  // yes
			}

			[Test]
			public void GetById_ReturnsCinemaWithGivenId()
			{
				// Arrange
				int cinemaId = 2;

				// Act
				Cinema cinema = cinemaRepository.GetById(cinemaId);

				// Assert
				Assert.IsNotNull(cinema); // yes
				Assert.IsInstanceOf<Cinema>(cinema); // yes
				Assert.AreEqual(cinemaId, cinema.Id);  // yes
			}

			[Test]
			public void Insert_AddsNewCinemaToDatabase()
			{
			// Arrange
			Cinema newCinema = new Cinema
			{	
				Logo = "https://i.pinimg.com/originals/29/0f/a9/290fa95bd326c28d46f990c035f7d610.png",
				Name = "New Cinema",
				Description= "This made-up noun perfectly describes the cinema as a designated place to sit back and view films.",
				Location = "New Cairo"
			};

			// Act
			cinemaRepository.Insert(newCinema);

				// Assert
				
			Cinema insertedCinema = cinemaRepository.GetById(newCinema.Id);
			Assert.IsNotNull(insertedCinema);
			Assert.AreEqual(newCinema.Logo, insertedCinema.Logo);
			Assert.AreEqual(newCinema.Name, insertedCinema.Name);
			Assert.AreEqual(newCinema.Description, insertedCinema.Description);
			Assert.AreEqual(newCinema.Location, insertedCinema.Location);


			cinemaRepository.Delete(insertedCinema.Id);
			}

			[Test]
			public void Update_UpdatesCinemaInDatabase()
			{
				// Arrange
				int cinemaId = 3;
				Cinema originalCinema = cinemaRepository.GetById(cinemaId);
				Cinema updatedCinema = new Cinema
				{
					Logo = "https://i.pinimg.com/originals/29/0f/a9/290fa95bd326c28d46f990c035f7d610.png",
					Name = "Updated Cinema",
					Description= "This made-up noun perfectly describes the cinema as a designated place to sit back and view films.",
					Location = "Cairo"
		
				};

				// Act
				cinemaRepository.Update(cinemaId, updatedCinema);

				// Assert
				Cinema retrievedCinema = cinemaRepository.GetById(cinemaId);
				Assert.IsNotNull(retrievedCinema);
				Assert.AreEqual(updatedCinema.Logo, retrievedCinema.Logo);
				Assert.AreEqual(updatedCinema.Name, retrievedCinema.Name);
			    Assert.AreEqual(updatedCinema.Description, retrievedCinema.Description);
			    Assert.AreEqual(updatedCinema.Location, retrievedCinema.Location);
  
				
				cinemaRepository.Update(cinemaId, originalCinema);
			}

			[Test]
			public void Delete_RemovesCinemaFromDatabase()
			{
			// Arrange
			Cinema newCinema = new Cinema
			{
				Logo = "https://i.pinimg.com/originals/29/0f/a9/290fa95bd326c28d46f990c035f7d610.png",
				Name = "New Cinema",
				Description = "Good Cinema",
				Location = "New Cairo"
			};
			cinemaRepository.Insert(newCinema);

				// Act
				cinemaRepository.Delete(newCinema.Id);

				// Assert
				Cinema deletedCinema = cinemaRepository.GetById(newCinema.Id);
				Assert.IsNull(deletedCinema); // yes
			}
		}
}
