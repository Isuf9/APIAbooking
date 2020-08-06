using APIAbooking.Controllers;
using APIAbooking.Models;
using APIAbooking.Services;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestOfApplication
{
    public class ClientTesting
    {
        [Fact]
        public string IfEmailExist()
        {
            var client = new ClientsController();

            client.Login();
        }
    }
}
