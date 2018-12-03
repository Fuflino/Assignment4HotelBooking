using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.UnitTests.ClassData
{
    public class RoomIsAvaliableClassData : IEnumerable<object[]>
    {
        private static DateTime timtim = DateTime.Today;

        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] { timtim.AddDays(17), timtim.AddDays(20), 1},
            new object[] { timtim.AddDays(20), timtim.AddDays(25), 1},
            new object[] { timtim.AddDays(15), timtim.AddDays(19), 1},
            new object[] { timtim.AddDays(24), timtim.AddDays(27), 1}
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
