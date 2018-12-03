using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.UnitTests.ClassData
{
    public class RoomNotAvaliableClassData : IEnumerable<object[]>
    {
        private static DateTime timtim = DateTime.Today;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { timtim.AddDays(1), timtim.AddDays(10)},
            new object[] { timtim.AddDays(3), timtim.AddDays(12)}
        };



        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
