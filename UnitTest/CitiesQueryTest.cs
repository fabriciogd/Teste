using Application.Interfaces;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Queries.Handlers;
using Queries.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnitTest.Helpers;

namespace UnitTest
{
    [TestClass]
    public class CitiesQueryTest
    {
        List<Domain.Entities.City> entities;
        IApplicationDbContext context;

        [TestInitialize]
        public void Setup()
        {
            entities = new List<Domain.Entities.City>
            {
                new Domain.Entities.City
                {
                    Id = 1,
                    Name = "TEST NAME"
                }
            };

            var myDbMoq = new Mock<IApplicationDbContext>();
            myDbMoq.Setup(p => p.Cities).Returns(DbContextMock.GetQueryableMockDbSet<Domain.Entities.City>(entities));

            context = myDbMoq.Object;
        }

        [TestMethod]
        public async Task Query_WhenCalled_ReturnsListResult()
        {
            FindAllCitiesQuery message = new FindAllCitiesQuery();
            FindAllCitiesQueryHandler handler = new FindAllCitiesQueryHandler(context);

            var list = await handler.Handle(message, new System.Threading.CancellationToken());

            Assert.IsTrue(list.Count == 1);
        }
    }
}
