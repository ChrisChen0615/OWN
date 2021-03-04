using NUnit.Framework;
using OWN.NUnitTest.Infrastructure;
using OWN.Service;
using OWN.Service.Paging.Dto;

namespace OWN.NUnitTest
{
    public class AddServTest
    {
        IAddressService _address;

        [SetUp]
        public void Setup()
        {
            WebHostTest.Setup();
            WebHostTest.SetupRepository();

            _address = new AddressService(WebHostTest._addressRepo.Object);
        }

        [Test]
        public void GetAllList_ShouldNot_BeNull()
        {
            //Mock<IRepositoryBase<Address>> _addressRepo;
            ////IRepositoryBase<Address> _addressRepo;
            //IAddressService _address;

            //_addressRepo = new Mock<IRepositoryBase<Address>>();
            //_address = new AddressService(_addressRepo.Object);

            //var fakedata = new List<Address>
            //{
            //    new Address
            //    {
            //        City ="Toronto"
            //    }
            //}.AsQueryable();
            //_addressRepo.Setup(p => p.GetAll()).Returns(fakedata);

            // arrange
            var fakedata = WebHostTest.ctx.Address.AsQueryable();
            WebHostTest._addressRepo.Setup(p => p.GetAll()).Returns(fakedata);

            //Bothell
            //Toronto
            var input = new PagingQueryDto
            {
                City = "Bothell",
                //Draw = 1,
                //Length = 10,
                //Start = 0
            };

            //act
            var data = _address.GetAllList(input);
            var actual = data.Count;

            var expected = 4;
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}