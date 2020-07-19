using CadeOErro.Domain.Models;
using CadeOErro.Server.Controllers;
using CadeOErro.Server.DTOs.User;
using CadeOErro.Server.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;

namespace CadeOErro.Tests.Server.Controllers
{
    public class UserControllerTest
    {
        Mock<IUserService> _serviceMock;
        UserController _controller;

        public UserControllerTest()
        {
            _serviceMock = new Mock<IUserService>();
            _controller = new UserController(_serviceMock.Object);
        }

        [Fact]
        public void GetAll_Should_Call_Service_And_Return_200_With_Dtos()
        {
            var expectedReturnFromService = new List<UserViewDTO>
            {
                new UserViewDTO {
                    id=1,
                    cpf="89218856090",
                    email= "pedro@test.com",
                    name="Pedro",
                    role="user"
                },
                new UserViewDTO {
                    id=2,
                    cpf="37615791014",
                    email= "jorge@test.com",
                    name="Jorge",
                    role="user"
                }
            };

            _serviceMock.Setup(_ => _.GetAll()).Returns(expectedReturnFromService);

            var result = _controller.GetAll();

            _serviceMock.Verify(x => x.GetAll(), Times.Once);

            var objResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, objResult.StatusCode);

            var dtos = Assert.IsType<List<UserViewDTO>>(objResult.Value);
            Assert.NotEmpty(dtos);
            Assert.Equal(expectedReturnFromService.Count, dtos.Count);
        }

        [Fact]
        public void GetById_Should_Call_Service_And_Return_200_With_Dto_When_User_Found()
        {
            var expectedReturnFromService = new UserViewDTO
            {
                id = 1,
                cpf = "89218856090",
                email = "pedro@test.com",
                name = "Pedro",
                role = "user"
            };

            _serviceMock.Setup(_ => _.GetById(1)).Returns(expectedReturnFromService);

            var result = _controller.GetById(1);

            _serviceMock.Verify(x => x.GetById(1), Times.Once);

            var objResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, objResult.StatusCode);

            var dto = Assert.IsType<UserViewDTO>(objResult.Value);
            Assert.Equal(expectedReturnFromService.cpf, dto.cpf);
        }

        [Fact]
        public void GetById_Should_Call_Service_And_Return_404_When_User_NotFound()
        {
            _serviceMock.Setup(_ => _.GetById(1)).Returns(value: null);

            var result = _controller.GetById(1);

            _serviceMock.Verify(x => x.GetById(1), Times.Once);

            var objResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, objResult.StatusCode);
        }

        [Fact]
        public void Post_Should_Call_Service_And_Return_201_When_Sucess()
        {
            var dto = new UserCreateDTO { name = "João", email = "joao@test.com", cpf = "89218856090", password = "123", role = "user" };
            var userMock = new Mock<UserViewDTO>();

            _serviceMock.Setup(x => x.Create(It.IsAny<UserCreateDTO>())).Returns(userMock.Object);
            var result = _controller.Post(dto);

            var objResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(201, objResult.StatusCode);
        }

        [Fact]
        public void Post_ShouldCallService_AndReturn400WithErrors_WhenValidationFails()
        {
            var dto = new UserCreateDTO { name = "João", cpf = "89218856090", password = "123", role = "user" };
            var personMock = new Mock<UserViewDTO>();

            //_serviceMock.Setup(x => x.Create(It.IsAny<UserCreateDTO>())).Returns(personMock.Object);

            var context = new ValidationContext(dto, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var valid=  Validator.TryValidateObject(dto, context, results, true);


            var result = _controller.Post(dto);

            var objResult = Assert.IsType<BadRequestResult>(result);
            Assert.Equal(400, objResult.StatusCode);
        }
    }
}
