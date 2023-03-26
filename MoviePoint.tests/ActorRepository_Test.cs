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
	public class ActorRepository_Test
	{
			public ActorRepository actorRepository;

			[SetUp]
			public void SetUp()
			{
			
				actorRepository = new ActorRepository();
			}

			[Test]
			public void GetAll_ReturnsListOfActors()
			{
				// Act
				List<Actor> actors = actorRepository.GetAll();

				// Assert
				Assert.IsNotNull(actors);  // yes
				Assert.IsInstanceOf<List<Actor>>(actors);  // yes
				Assert.Greater(actors.Count, 0);  // yes
			}

			[Test]
			public void GetById_ReturnsActorWithGivenId()
			{
				// Arrange
				int actorId = 1;

				// Act
				Actor actor = actorRepository.GetById(actorId);

				// Assert
				Assert.IsNotNull(actor); // yes
				Assert.IsInstanceOf<Actor>(actor); // yes
				Assert.AreEqual(actorId, actor.ID);  // yes
			}

			[Test]
			public void Insert_AddsNewActorToDatabase()
			{
				// Arrange
				Actor newActor = new Actor
				{
					FullName = "Test Actor",
					ProfilePicUrl = "http://example.com/testactor.jpg",
					Bio = "Test bio"
				};

				// Act
				actorRepository.Insert(newActor);

				// Assert
				Actor insertedActor = actorRepository.GetById(newActor.ID);
				Assert.IsNotNull(insertedActor);
				Assert.AreEqual(newActor.FullName, insertedActor.FullName);
				Assert.AreEqual(newActor.ProfilePicUrl, insertedActor.ProfilePicUrl);
				Assert.AreEqual(newActor.Bio, insertedActor.Bio);

				
				actorRepository.Delete(insertedActor.ID);
			}

			[Test]
			public void Update_UpdatesActorInDatabase()
			{
				// Arrange
				int actorId = 1;
				Actor originalActor = actorRepository.GetById(actorId);
				Actor updatedActor = new Actor
				{
					ID = actorId,
					FullName = "Updated Actor",
					ProfilePicUrl = "http://example.com/updatedactor.jpg",
					Bio = "Updated bio"
				};

				// Act
				actorRepository.Update(actorId, updatedActor);

				// Assert
				Actor retrievedActor = actorRepository.GetById(actorId);
				Assert.IsNotNull(retrievedActor);
				Assert.AreEqual(updatedActor.FullName, retrievedActor.FullName);
				Assert.AreEqual(updatedActor.ProfilePicUrl, retrievedActor.ProfilePicUrl);
				Assert.AreEqual(updatedActor.Bio, retrievedActor.Bio);

				
				actorRepository.Update(actorId, originalActor);
			}

			[Test]
			public void Delete_RemovesActorFromDatabase()
			{
				// Arrange
				Actor newActor = new Actor
				{
					FullName = "Test Actor",
					ProfilePicUrl = "http://example.com/testactor.jpg",
					Bio = "Test bio"
				};
				actorRepository.Insert(newActor);

				// Act
				actorRepository.Delete(newActor.ID);

				// Assert
				Actor deletedActor = actorRepository.GetById(newActor.ID);
				Assert.IsNull(deletedActor); // yes
			}
		}
}
