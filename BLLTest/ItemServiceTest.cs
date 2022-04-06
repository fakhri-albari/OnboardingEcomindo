using Moq;
using OnboardingEcomindo.BLL.Cache;
using OnboardingEcomindo.BLLTest.Common;
using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;
using MockQueryable.Moq;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using OnboardingEcomindo.BLL;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLLTest
{
    public class ItemServiceTest
    {
        private IEnumerable<Item> items;
        private Mock<RedisService> redis;
        private Mock<IUnitOfWork> uow;
        private IConfiguration config;

        public ItemServiceTest()
        {
            items = CommonHelper.LoadDataFromFile<IEnumerable<Item>>("C:\\Users\\Ecomindo\\source\\repos\\OnBoardingEcomindo\\BLLTest\\MockData\\Item.json");
            uow = MockUnitOfWork();

        }

        private Mock<IUnitOfWork> MockUnitOfWork()
        {
            var itemsQueryable = items.AsQueryable().BuildMock().Object;
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork
                .Setup(u => u.ItemRepo.GetAll())
                .ReturnsAsync(itemsQueryable);

            return mockUnitOfWork;
        }

        private ItemService CreateAuthorService()
        {
            return new ItemService(uow.Object, null, null, null);
        }

        [Fact]
        public async Task GetAll_Success()
        {
            //arrange
            var expected = items;

            var svc = CreateAuthorService();

            // act
            var actual = await svc.GetAll();

            // assert      
            actual.Should().BeEquivalentTo(expected);
        }

    }
}
