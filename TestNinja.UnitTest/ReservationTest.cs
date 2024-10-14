using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ReservationTest
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnTrue()
        {
            // Arrang
            var reservation = new Reservation();

            // Act
            var result =reservation.CanBeCancelledBy(new User() { IsAdmin=true});

            // Assert
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_SameUSerCanllinReservation_ReturnTrue()
        {
            // Arrang
            var user = new User();
            var reservation = new Reservation() { MadeBy = user};

            // Act
            var result = reservation.CanBeCancelledBy(reservation.MadeBy);

            // Assert
            Assert.That(result, Is.True);
        }
        [Test]
        public void CanBeCancelledBy_NotUSer_ReturnFalse()
        {
            // Arrang
            var user = new User();
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
