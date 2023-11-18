using App_Main_Web.Controllers;
using App_Model.Authorization;
using App_Model.UserInfo;
using App_Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AppXUnitTest
{
    public class UnitTestHomeController
    {
        [Fact]
        public void AppLogin_ValidCredentials_RedirectsToHomeIndex()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var userInfo = new UserInfo { UserId = "tareq612625", UserPassword = "12345" };
            var userData = new UserInfo { /* mocked user data */ };
            var userPermission = new List<A_USER_MENU> { /* mocked user permission data */ };

            mockUnitOfWork.Setup(u => u.LoginRepo.UserLogin(userInfo.UserId, userInfo.UserPassword))
                .Returns(userData);
            mockUnitOfWork.Setup(u => u.LoginRepo.MenuPermission(userInfo.UserId))
                .Returns(userPermission);

            var controller = new LoginControllerCopy(mockUnitOfWork.Object);

            // Act
            var result = controller.AppLogin(userInfo) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
            Assert.Equal("Login Successful", controller.ViewBag.Message);
        }

        [Fact]
        public void AppLogin_InvalidCredentials_ReturnsViewWithError()
        {
            // Arrange
            var userInfo = new UserInfo { UserId = "testuser", UserPassword = "invalidpassword" };
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(u => u.LoginRepo.UserLogin(userInfo.UserId, userInfo.UserPassword))
                .Returns((UserInfo)null);

            var controller = new LoginControllerCopy(mockUnitOfWork.Object);

            // Act
            var result = controller.AppLogin(userInfo) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userInfo, result.Model);
            Assert.Equal("User Id and password are incorrect", controller.ViewBag.Message);
        }
    }
}