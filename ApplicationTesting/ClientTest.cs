using System;
using Xunit;
using APIAbooking.Models;
using Microsoft.Owin.Security.Provider;

namespace ApplicationTesting
{
    public class ClientTests
    {
        [Fact]
        public void IfEmailExist()
        {
            //Arrange 
            var c = new ClientServices { Email = "arberdresha4@gmail.com" };

            //Act 
            c.Email = "arberdresha4@gmail.com";

            // Assert 
            Assert.Equal("arberdresha4@gmail.com", c.Email);

        }
        [Fact]
        public void IfEmailExist1()
        {
            // Arrange
            var c = new ClientServices { Email = "lindi25@gmail.com" };
            // Act
            c.Email = "lindi25@gmail.com";
            // Assert
            Assert.Equal("lindi25@gmail.com", c.Email);

        }
        [Fact]

        public void IfEmailExits2()
        {
            //Arrange
            var c = new ClientServices();
            //Act
            c.Email = null;
            //Assert
            Assert.Equal(null, c.Email);

        }
        [Fact]

        public void GetById()
        {
            //Arrange
            var c = new ClientServices();
            //Act
            c.ClientId = "15ea3d62-9ae1-4dba-a092-8e233491b04d";
            //Assert
            Assert.Equal("15ea3d62-9ae1-4dba-a092-8e233491b04d", c.ClientId);

        }
       
       
        }
        }

    

