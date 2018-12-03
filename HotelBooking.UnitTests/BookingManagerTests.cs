//using HotelBooking.BusinessLogic;
//using HotelBooking.UnitTests.Fakes;
//using System;
//using System.Collections.Generic;
//using Xunit;
//using Moq;
//using HotelBooking.Models;
//using HotelBooking.UnitTests.MockData;

//namespace HotelBooking.UnitTests
//{
//    public class BookingManagerTests
//    {
//        private static DateTime timtim = DateTime.Today;
//        private Mock<IRepository<Room>> roomRepo = new Mock<IRepository<Room>>();
//        private Mock<IRepository<Booking>> bookingRepo = new Mock<IRepository<Booking>>();
//        private MockDataGenarator mockDataGen = new MockDataGenarator();
//        private IBookingManager mana;

//        public BookingManagerTests()
//        {
//            bookingRepo.Setup(x => x.GetAll()).Returns(mockDataGen.GetAllMockBookings());
//            roomRepo.Setup(x => x.GetAll()).Returns(mockDataGen.GetAllMockRooms());
            
//            mana = new BookingManager(bookingRepo.Object, roomRepo.Object);
//        }

//        public static IEnumerable<object[]> GetLocalData()
//        {
//            yield return new object[] { timtim.AddDays(7), timtim.AddDays(10), new List<DateTime>() {timtim.AddDays(7), timtim.AddDays(8), timtim.AddDays(9), timtim.AddDays(10) } };
//            yield return new object[] { timtim.AddDays(10), timtim.AddDays(15), new List<DateTime>() { timtim.AddDays(10), timtim.AddDays(11), timtim.AddDays(12), timtim.AddDays(13), timtim.AddDays(14) } };
//            yield return new object[] { timtim.AddDays(5), timtim.AddDays(9), new List<DateTime>() { timtim.AddDays(5), timtim.AddDays(6), timtim.AddDays(7), timtim.AddDays(8), timtim.AddDays(9)} };
//            yield return new object[] { timtim.AddDays(1), timtim.AddDays(6), new List<DateTime>() { timtim.AddDays(1), timtim.AddDays(2), timtim.AddDays(3), timtim.AddDays(4), timtim.AddDays(5), timtim.AddDays(6) } };
//            yield return new object[] { timtim.AddDays(15), timtim.AddDays(17), new List<DateTime>() {  } };
//        }

//        [Theory]
//        [MemberData(nameof(GetLocalData))]
//        public void GetFullyOccupiedDates_ValidMemberData_FullyOccupiedDates(DateTime startDate, DateTime endDate, List<DateTime> datetimes)
//        {
//            var reslut = mana.GetFullyOccupiedDates(startDate, endDate);

//            Assert.Equal(reslut, datetimes);
//        }

//        [Theory]
//        [ClassData(typeof(ClassData.RoomIsAvaliableClassData))]
//        public void FindAvaliableRoom_ValidClassData_RoomIsAvaliable(DateTime startDate, DateTime endDate, int roomId)
//        {
//            var reslut = mana.FindAvailableRoom(startDate, endDate);

//            Assert.Equal(roomId, reslut);
//        }

//        [Theory]
//        [ClassData(typeof(ClassData.RoomNotAvaliableClassData))]
//        public void FindAvaliableRoom_ValidClassData_NoRoomAvaliable(DateTime startDate, DateTime endDate)
//        {
//            var reslut = mana.FindAvailableRoom(startDate, endDate);

//            Assert.Equal(-1, reslut);
//        }



//        [Theory]
//        [JsonData("JSONData/BookingCreatedData.json")]
//        public void CreateBooking_ValidJsonData_BookingIsCreated(string startDate, string endDate, int customerId)
//        {
//            var booking = new Booking();
//            booking.StartDate = DateTime.Parse(startDate);
//            booking.EndDate = DateTime.Parse(endDate);
//            booking.CustomerId = customerId;


//            var result = mana.CreateBooking(booking);
            
//            bookingRepo.Verify(x => x.Add(It.IsAny<Booking>()));

//            Assert.True(result);
//        }

//        [Theory]
//        [JsonData("JSONData/BookingNotCreatedData.json")]
//        public void CreateBooking_ValidJsonData_BookingNotCreated(string startDate, string endDate, int customerId)
//        {
//            var booking = new Booking();
//            booking.StartDate = DateTime.Parse(startDate);
//            booking.EndDate = DateTime.Parse(endDate);
//            booking.CustomerId = customerId;
            
//            var result = mana.CreateBooking(booking);

//            Assert.False(result);
//        }
//    }
//}
