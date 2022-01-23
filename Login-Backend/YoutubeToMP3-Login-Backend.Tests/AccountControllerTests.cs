using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using YoutubeToMP3_Login_Backend.Controllers;
using YoutubeToMP3_Login_Backend.Data;
using YoutubeToMP3_Login_Backend.Models;

namespace YoutubeToMP3_Login_Backend.Tests
{
    [TestClass]
    public class AccountControllerTests
    {
        private readonly AccountController _accountcontroller;
        private readonly Mock<IAccountData> _accountDataMock = new Mock<IAccountData>();

        public AccountControllerTests()
        {
            _accountcontroller = new AccountController(_accountDataMock.Object);
        }

        [TestMethod]
        public void GetMedicines_ReturnsList()
        {
            // Arrange
            List<Account> accounts = new List<Account>()
            {
                new Account() { AccountId =1, UserName = "FirstUser", Email = "FirstUserMail@gmail.com", Password = "FirstPassword" },
                new Account() { AccountId =2, UserName = "SecondUser", Email = "SecondUserMail@gmail.com", Password = "SecondPassword" },
                new Account() { AccountId =1, UserName = "ThirdUser", Email = "ThirdUserMail@gmail.com", Password = "ThirdPassword" },

            };

            _accountDataMock.Setup(x => x.GetAccounts()).Returns(accounts);

            // Act
            var actionResult = _accountcontroller.GetAccounts();
            var result = actionResult as ObjectResult;
            List<Account> actualMedicines = (List<Account>)result.Value;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(accounts.Count, actualMedicines.Count);
            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
        }
    }
}
