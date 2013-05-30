using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuyAtYourPrice.Web.Controllers;
using BuyAtYourPrice.Membership;

namespace BuyAtYourPrice.Api.Tests
{
    [TestClass]
    public class CustomerApi
    {
        private AccountController accountController;

        [TestInitialize]
        public void Setup()
        {
            var membership = new MembershipProvider();
            this.accountController = new AccountController(membership);
        }

        [TestMethod]
        public void TestMethod1()
        {
            accountController.GetCustomer("test1");
        }
    }
}
