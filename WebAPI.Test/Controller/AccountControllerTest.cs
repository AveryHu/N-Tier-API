using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using WebAPI.Domain.DTO;
using WebAPI.Domain.Interfaces.Logics;
using WebAPI.ServiceLayer.Controllers;

namespace WebAPI.Test
{
    public class AccountControllerTest
    {
        AccountController _controller;
        Mock<IAccountLogic> _logic;

        public AccountControllerTest()
        {
            _logic = new Mock<IAccountLogic>();
            _controller = new AccountController(null, _logic.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        // MethodName_ExpectedBehavior_StateUnderTest
        [Test]
        public void Get_ReturnsOkWithAllAccountDetail_WhenValid()
        {
            // Arrange
            _logic.Setup(l => l.GetAllAccountDetail())
                .Returns(new List<AccountDetail>());

            // Act
            var result = _controller.Get();
            var objectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.IsInstanceOf<IEnumerable<AccountDetail>>(objectResult.Value);
        }
    }
}