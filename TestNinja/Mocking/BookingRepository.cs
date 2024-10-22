using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? ExcludedbookingId);
    }
    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetActiveBookings(int? ExcludedbookingId = null)
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(b => b.Status != "Cancelled");
            if (ExcludedbookingId.HasValue)
            {
                bookings.Where(b=>b.Id != ExcludedbookingId.Value);
            }
            return bookings;
        }

        
    }
}
