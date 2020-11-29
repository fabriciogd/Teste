using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitTest.Helpers;

namespace UnitTest
{
    [TestClass]
    public class RepositoryListQueryTest
    {
        List<Domain.Entities.City> entities;
        IApplicationDbContext context;

        [TestInitialize]
        public void Setup()
        {
            entities = new List<City>
            {
                new City
                {
                    Id = 1,
                    Name = "TEST NAME"
                }
            };

            var myDbMoq = new Mock<IApplicationDbContext>();
            myDbMoq.Setup(p => p.AsNoTracking<City>()).Returns(DbContextMock.GetQueryableMockDbSet<Domain.Entities.City>(entities));

            context = myDbMoq.Object;
        }

        [TestMethod]
        public async Task Query_WhenCalled_ReturnsListResult()
        {
            RepositoryListQuery<City, CityDTO> repositoryQuery = new RepositoryListQuery<City, CityDTO>(context);

            var list = await repositoryQuery.GetAll();

            Assert.IsTrue(list.Count == 1);
        }
    }
}
