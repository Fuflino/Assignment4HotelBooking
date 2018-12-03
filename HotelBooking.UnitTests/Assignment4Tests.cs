using HotelBooking.BusinessLogic;
using HotelBooking.UnitTests.Fakes;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using HotelBooking.Models;
using HotelBooking.UnitTests.MockData;


namespace HotelBooking.UnitTests
{
    public class Assignment4Tests
    {
        private static DateTime timtim = DateTime.Today;
        private Mock<IRepository<Room>> roomRepo = new Mock<IRepository<Room>>();
        private Mock<IRepository<Booking>> bookingRepo = new Mock<IRepository<Booking>>();
        private MockDataGenarator mockDataGen = new MockDataGenarator();
        private IBookingManager mana;

        public Assignment4Tests()
        {
            
        }

        private void MockRepositoryWithData()
        {
            bookingRepo.Setup(x => x.GetAll()).Returns(mockDataGen.GetAllMockBookings());
            roomRepo.Setup(x => x.GetAll()).Returns(mockDataGen.GetAllMockRooms());

            mana = new BookingManager(bookingRepo.Object, roomRepo.Object);
        }

        private void MockRepositoryWithNoData()
        {
            bookingRepo.Setup(x => x.GetAll()).Returns(mockDataGen.GetEmptyMockBookings());
            roomRepo.Setup(x => x.GetAll()).Returns(mockDataGen.GetEmptyMockRooms());

            mana = new BookingManager(bookingRepo.Object, roomRepo.Object);
        }

        [Fact]
        public void FindAvailableRooms_InvalidData_ThrowsException()
        {
            var startDate = DateTime.Today.AddDays(-5);
            var endDate = DateTime.Today.AddDays(-1);

            MockRepositoryWithData();
            Assert.Throws<ArgumentException>(() => mana.FindAvailableRoom(startDate, endDate));
        }
        [Fact]
        public void FindAvailableRooms_InvalidData_NoRoomsInRepo()
        {
            var startDate = DateTime.Today.AddDays(14);
            var endDate = DateTime.Today.AddDays(18);

            MockRepositoryWithNoData();
            var result = mana.FindAvailableRoom(startDate, endDate);

            Assert.Equal(-1, result);
        }
        [Fact]
        public void FindAvailableRoom_ValidData_NoAvaliableRoom()
        {
            var startDate = DateTime.Today.AddDays(1);
            var endDate = DateTime.Today.AddDays(4);

            MockRepositoryWithData();
            var result = mana.FindAvailableRoom(startDate, endDate);

            Assert.Equal(-1, result);
        }
        [Fact]
        public void FindAvailableRoom_ValidData_AvaliableRoom()
        {
            var startDate = DateTime.Today.AddDays(15);
            var endDate = DateTime.Today.AddDays(18);

            MockRepositoryWithData();
            var result = mana.FindAvailableRoom(startDate, endDate);

            Assert.Equal(1, result);
        }

        [Fact]
        public void GetFullyOccupiedDates_InvalidData_ThrowsException()
        {
            var startDate = DateTime.Today.AddDays(2);
            var endDate = DateTime.Today.AddDays(1);

            MockRepositoryWithData();
            Assert.Throws<ArgumentException>(() => mana.GetFullyOccupiedDates(startDate, endDate));
        }
        [Fact]
        public void GetFullyOccupiedDates_ValidData_NoBookings()
        {
            var startDate = DateTime.Today.AddDays(1);
            var endDate = DateTime.Today.AddDays(2);

            MockRepositoryWithNoData();
            var result = mana.GetFullyOccupiedDates(startDate, endDate);
            Assert.Equal(new List<DateTime>(), result);
        }
        [Fact]
        public void GetFullyOccupiedDates_ValidData_NoOccupiedDates()
        {
            var startDate = DateTime.Today.AddDays(15);
            var endDate = DateTime.Today.AddDays(16);

            MockRepositoryWithData();

            var result = mana.GetFullyOccupiedDates(startDate, endDate);
            Assert.Equal(new List<DateTime>(), result);
        }
        [Fact]
        public void GetFullyOccupiedDates_ValidData_OccupiedDates()
        {
            var startDate = DateTime.Today.AddDays(13);
            var endDate = DateTime.Today.AddDays(14);

            var x = new List<DateTime>()
            {
                startDate,
                endDate
            };

            MockRepositoryWithData();

            var result = mana.GetFullyOccupiedDates(startDate, endDate);
            Assert.Equal(x, result);
        }


    }
}
