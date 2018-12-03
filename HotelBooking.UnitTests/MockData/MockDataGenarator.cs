using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.UnitTests.MockData
{
    public class MockDataGenarator
    {

        public IEnumerable<Room> GetAllMockRooms()
        {
            List<Room> rooms = new List<Room>
            {
                new Room { Id=1, Description="A" },
                new Room { Id=2, Description="B" },
            };
            return rooms;
        }

        public IEnumerable<Booking> GetAllMockBookings()
        {
            List<Booking> bookings = new List<Booking>
            {
                new Booking { Id=1, StartDate = DateTime.Today, EndDate= DateTime.Today.AddDays(14), IsActive=true, CustomerId=1, RoomId=1 },
                new Booking { Id=2, StartDate= DateTime.Today, EndDate= DateTime.Today.AddDays(14), IsActive=true, CustomerId=2, RoomId=2 },
            };
            return bookings;
        }

        public IEnumerable<Room> GetEmptyMockRooms()
        {
            return new List<Room>(); 
        }

        public IEnumerable<Booking> GetEmptyMockBookings()
        {
            return new List<Booking>();
        }

    }


}
