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
        Mock<IAccountLogic> _mocklogic;

        public AccountControllerTest()
        {
            _mocklogic = new Mock<IAccountLogic>();
            _controller = new AccountController(null, _mocklogic.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        // MethodName_ExpectedBehavior_StateUnderTest
        #region Get
        [Test]
        public void Get_ReturnsOkWithAllAccountDetails_WhenVaild()
        {
            // Arrange
            _mocklogic.Setup(l => l.GetAllAccountDetail())
                .Returns(new List<AccountDetail>());

            // Act
            var result = _controller.Get();
            var objectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.IsInstanceOf<IEnumerable<AccountDetail>>(objectResult.Value);
        }
        #endregion

        #region GetById
        [Test]
        public void GetById_ReturnsNotFound_WhenIdNotExists()
        {
            // Arrange
            _mocklogic.Setup(l => l.GetAccountDetail(It.IsAny<int>()))
                .Returns((AccountDetail)null);

            // Act
            var result = _controller.Get(0);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result.Result);
        }
        [Test]
        public void GetById_ReturnsOkResultWithAccountDetail_WhenIdExists()
        {
            // Arrange
            _mocklogic.Setup(l => l.GetAccountDetail(It.IsAny<int>()))
                .Returns(new AccountDetail());

            // Act
            var result = _controller.Get(0);
            var objectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            Assert.IsInstanceOf<AccountDetail>(objectResult.Value);
        }
        #endregion

        #region Post
        [Test]
        public void Post_ReturnsBadRequest_InvalidObjectPassed()
        {
            // Arrange
            // Invalid object, password over 32 length
            AccountCreation input = new AccountCreation
            {
                Name = "Test",
                Password_hash = "abcdefghijklmnopqrstuvwxyz_abcdef"
            };

            // Act
            var result = _controller.Post(input);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
        [Test]
        public void Post_ReturnsBadRequest_ValidObjectPassed()
        {
            // Arrange
            // Valid object, password less than 32 length
            AccountCreation input = new AccountCreation
            {
                Name = "Test",
                Password_hash = "abcdefghijklmnopqrstuvwxyz_"
            };

            // Act
            var result = _controller.Post(input);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result);
        }
        #endregion
    }
}