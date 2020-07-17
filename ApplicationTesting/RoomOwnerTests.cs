using System;
using Xunit;
using APIAbooking.Models;
using Microsoft.Owin.Security.Provider;

namespace ApplicationTesting
{
    public class OwnerTests
    {
        [Fact]
        public void IfEmailExist()
        {
            //Arrange 
            var o = new RoomOwner { Email = "dresha4@gmail.com" };

            //Act 
            o.Email = "dresha4@gmail.com";

            // Assert 
            Assert.Equal("dresha4@gmail.com", o.Email);


        }
        [Fact]

        public void IfEmailExits2()
        {
            //Arrange
            var o = new RoomOwner();
            //Act
            o.Email = null;
            //Assert
            Assert.Equal(null, o.Email);

        }
    }
}