using Moq;
using OnboardingEcomindo.BLL.Cache;
using OnboardingEcomindo.BLL.test.Common;
using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace OnboardingEcomindo.BLL.test
{
    public class ItemServiceTest
    {
        private IEnumerable<Item> items;
        private Mock<RedisService> redis;
        private Mock<UnitOfWork> uow;

        public ItemServiceTest()
        {
            items = CommonHelper.LoadDataFromFile<IEnumerable<Item>>(@"MockData\Item.json");
            uow = MockUnitOfWork();
            //redis = MockRedis();
        }

        private Mock<UnitOfWork> MockUnitOfWork()
        {
            var authorsQueryable = items.AsQueryable().BuildMock().Object;

            var mockUnitOfWork = new Mock<UnitOfWork>();

            return mockUnitOfWork;
            
            //mockUnitOfWork
            //    .Setup(u => u.AuthorRepository.GetAll())
            //    .Returns(authorsQueryable);
        }
    }
}
