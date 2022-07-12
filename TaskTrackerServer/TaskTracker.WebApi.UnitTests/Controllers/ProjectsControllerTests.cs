using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Business.DTOs;
using TaskTracker.Business.Interfaces;
using TaskTracker.WebApi.Controllers;
using Xunit;

namespace TaskTracker.WebApi.UnitTests.Controllers
{
    public class ProjectsControllerTests
    {
        private readonly Mock<IProjectService> _projectService;
        private readonly Mock<ILogger<ProjectsController>> _logger;
        private readonly ProjectsController _controller;

        public ProjectsControllerTests()
        {
            _projectService = new Mock<IProjectService>();
            _logger = new Mock<ILogger<ProjectsController>>();
            _controller = new ProjectsController(_projectService.Object, _logger.Object);
        }

        //[Fact]
        //public void GetAllProjects_ActionExecutes_ReturnsOkObjectResult()
        //{
        //    var result = _controller.GetAllProjects();

        //    Assert.IsType<OkObjectResult>(result);
        //}

        //[Fact]
        //public void GetAllProjects_ActionExecutes_ReturnsExactNumberOfProjects()
        //{
        //    _projectService.Setup(projectService => projectService.GetAllProjects())
        //        .Returns(new List<ProjectDto>() { new ProjectDto(), new ProjectDto() });

        //    var result = _controller.GetAllProjects();

        //    var viewResult = Assert.IsType<OkObjectResult>(result);
        //    var projects = Assert.IsType<List<ProjectDto>>(viewResult.Value);
        //    Assert.Equal(2, projects.Count);
        //}

        [Fact]
        public void CreateProject_ProjectIsNull_ReturnsBadRequest()
        {
            ProjectForCreationDto project = null;

            var result = _controller.CreateProject(project);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void CreateProject_InvalidModelState_ReturnsBadRequest()
        {
            ProjectForCreationDto project = new ProjectForCreationDto
            {
                Name = null,
                Priority = 2
            };
            _controller.ModelState.AddModelError("Name", "Name field is required");

            var result = _controller.CreateProject(project);

            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<string>(resultType.Value);
        }

        [Fact]
        public void CreateProject_ProjectCreated_ReturnsCreatedAtRouteResult()
        {
            var projectForCreation = new ProjectForCreationDto
            {
                Name = "project1"
            };

            var projectDto = new ProjectDto();

            _projectService.Setup(projectService => projectService.CreateProject(It.IsAny<ProjectForCreationDto>()))
                .Returns(projectDto);

            var result = _controller.CreateProject(projectForCreation);

            Assert.IsType<CreatedAtRouteResult>(result);
            Assert.NotNull(result);
        }


    }
}
