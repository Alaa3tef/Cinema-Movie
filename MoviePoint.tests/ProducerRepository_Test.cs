using MoviePoint.Models;
using MoviePoint.Repository;
using NuGet.Protocol.Core.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviePoint.tests
{
	[TestFixture]
	public class ProducerRepository_Test
	{
		public ProducerRepository producerRepository;

		[SetUp]
		public void SetUp()
		{

			producerRepository = new ProducerRepository();
		}

		[Test]

		public void GetAll_ShouldReturnAllProducers()
		{
			// Arrange

			// Act
			var producers =producerRepository.GetAll();

			// Assert
			Assert.NotNull(producers);
			Assert.AreEqual(3, producers.Count); 
		}

		[Test]
		public void GetById_ShouldReturnProducerWithMatchingId()
		{
			// Arrange
			var id = 1; 

			// Act
			var producer =producerRepository.GetById(id);

			// Assert
			Assert.NotNull(producer);
			Assert.AreEqual(id, producer.Id);
		}

		[Test]
		public void Insert_ShouldAddNewProducer()
		{
			// Arrange
			var newProducer = new Producer
			{
				FullName = "New producer",
				ProfilePicture = "New_producer.jpg",
				Bio = "Inserted producer"
			};

			// Act
			producerRepository.Insert(newProducer);

			// Assert
			var insertedProducer =producerRepository.GetById(newProducer.Id);
			Assert.NotNull(insertedProducer);
			Assert.AreEqual(newProducer.FullName, insertedProducer.FullName);
			Assert.AreEqual(newProducer.ProfilePicture, insertedProducer.ProfilePicture);
			Assert.AreEqual(newProducer.Bio, insertedProducer.Bio);
		}

		[Test]
		public void Update_ShouldUpdateExistingProducer()
		{
			// Arrange
			var id = 7; 
			var updatedProducer = new Producer
			{
				FullName = "New producer",
				ProfilePicture = "New_producer.jpg",
				Bio = "An updated producer"
			};

			// Act
			producerRepository.Update(id, updatedProducer);

			// Assert
			var orgProducer =producerRepository.GetById(id);
			Assert.NotNull(orgProducer);
			Assert.AreEqual(updatedProducer.FullName, orgProducer.FullName);
			Assert.AreEqual(updatedProducer.ProfilePicture, orgProducer.ProfilePicture);
			Assert.AreEqual(updatedProducer.Bio, orgProducer.Bio);
		}

		[Test]
		public void Delete_ShouldRemoveProducerWithMatchingId()
		{
			// Arrange
			var id = 7;

			// Act
			producerRepository.Delete(id);

			// Assert
			var deletedProducer =producerRepository.GetById(id);
			Assert.Null(deletedProducer);
		}
	}
}
