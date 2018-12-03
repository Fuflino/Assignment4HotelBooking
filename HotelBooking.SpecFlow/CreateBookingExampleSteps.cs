using HotelBooking.BusinessLogic;
using HotelBooking.Models;
using HotelBooking.UnitTests.Fakes;
using Moq;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBooking.SpecFlow
{
    [Binding]
    public class CreateBookingExampleSteps
    {
        private IBookingManager bookingManager;
        private DateTime Start;
        private DateTime End;

        private IRepository<Booking> bookingRepository;
        private IRepository<Room> roomRepository;

        [Given(@"I have entered (.*) and (.*)")]
        public void GivenIHaveEnteredAnd(string p0, string p1)
        {
            Start = DateTime.Parse(p0);
            End = DateTime.Parse(p1);
        }

        [Given(@"a room is already booked from '(.*)' to '(.*)'")]
        public void GivenARoomIsAlreadyBookedFromTo(string p0, string p1)
        {
            var start = DateTime.Parse(p0);
            var end = DateTime.Parse(p1);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            Mock<IRepository<Room>> roomRepository = new Mock<IRepository<Room>>();

            var fakeBookingRepo = new FakeBookingRepository(start, end);
            var fakeRoomRepo = new FakeRoomRepository();

            bookingRepository.Setup(x => x.GetAll()).Returns(fakeBookingRepo.GetAll());
            roomRepository.Setup(x => x.GetAll()).Returns(fakeRoomRepo.GetAll());
            bookingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(fakeBookingRepo.Get(1));

            this.bookingRepository = bookingRepository.Object;
            this.roomRepository = roomRepository.Object;
        }

        [When(@"I press create booking")]
        public void WhenIPressCreateBooking()
        {
            bookingManager = new BookingManager(bookingRepository, roomRepository);
        }

        [Then(@"the result should be '(.*)'")]
        public void ThenTheResultShouldBe(string p0)
        {
            var booking = new Booking()
            {
                StartDate = Start,
                EndDate = End
            };

            var result = bookingManager.CreateBooking(booking);

            Assert.Equal(result, bool.Parse(p0));
        }
    }
}
