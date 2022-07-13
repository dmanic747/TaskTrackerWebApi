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
using TaskTracker.Data.Enums;
using TaskTracker.WebApi.Controllers;
using Xunit;

namespace TaskTracker.WebApi.UnitTests.Controllers
{
    public class ProjectsControllerTests
    {
        private readonly Mock<IProjectService> _projectService;
        private readonly Mock<ILogger<ProjectsController>> _logger;
        private readonly ProjectsController _controller;
        private readonly Random _rand = new Random();

        public ProjectsControllerTests()
        {
            _projectService = new Mock<IProjectService>();
            _logger = new Mock<ILogger<ProjectsController>>();
            _controller = new ProjectsController(_projectService.Object, _logger.Object);
        }

        [Fact]
        public void GetAllProjects_ActionExecutes_ReturnsOkObjectResult()
        {
            ProjectQueryDto projectQuery = null;
            _projectService.Setup(service => service.GetAllProjects(It.IsAny<ProjectQueryDto>()))
                .Returns(new List<ProjectDto>());

            var result = _controller.GetAllProjects(projectQuery);

            var resultType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, resultType.StatusCode);
        }

        [Fact]
        public void GetAllProjects_ActionExecutes_ReturnsExactNumberOfProjects()
        {
            ProjectQueryDto projectQuery = null;

            _projectService.Setup(service => service.GetAllProjects(It.IsAny<ProjectQueryDto>()))
                .Returns(new List<ProjectDto>() { new ProjectDto(), new ProjectDto() });

            var result = _controller.GetAllProjects(projectQuery);

            var resultType = Assert.IsType<OkObjectResult>(result);
            var projects = Assert.IsType<List<ProjectDto>>(resultType.Value);
            Assert.Equal(2, projects.Count);
        }

        [Fact]
        public void GetAllProjects_UnexpectedErrorHappened_ReturnsObjectResultWith500StatusCode()
        {
            _projectService.Setup(service => service.GetAllProjects(It.IsAny<ProjectQueryDto>()))
                .Throws(new Exception("error"));

            var result = _controller.GetAllProjects(new ProjectQueryDto());

            var resultType = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, resultType.StatusCode);
        }

        [Fact]
        public void GetProjectById_ProjectNotExistsInDb_ReturnsNotFound()
        {
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
                .Returns((ProjectDto) null);

            var result = _controller.GetProjectById(Guid.NewGuid());

            var resultType = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, resultType.StatusCode);
        }

        [Fact]
        public void GetProjectById_ProjectFoundInDb_ReturnsOk()
        {
            ProjectDto expectedProject = CreateRandomProjectDto();

            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
                .Returns(expectedProject);

            var result = _controller.GetProjectById(Guid.NewGuid());


            var resultType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, resultType.StatusCode);
            var returnedProject = Assert.IsType<ProjectDto>(resultType.Value);
            Assert.Equal(expectedProject, returnedProject);
        }

        [Fact]
        public void GetProjectById_UnexpectedErrorHappened_ReturnsObjectResultWith500StatusCode()
        {
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
                .Throws(new Exception("error"));

            var result = _controller.GetProjectById(Guid.NewGuid());

            var resultType = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, resultType.StatusCode);
        }

        [Fact]
        public void CreateProject_ProjectIsNull_ReturnsBadRequest()
        {
            ProjectForCreationDto project = null;

            var result = _controller.CreateProject(project);

            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

        [Fact]
        public void CreateProject_ProjectCreated_ReturnsCreatedAtRouteResult()
        {
            var projectForCreation = CreateRandomProjectForCreationDto();
            var projectDto = CreateRandomProjectDto();

            _projectService.Setup(service => service.CreateProject(It.IsAny<ProjectForCreationDto>()))
                .Returns(projectDto);

            var result = _controller.CreateProject(projectForCreation);

            var resultType = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal(201, resultType.StatusCode);
            Assert.IsType<ProjectDto>(resultType.Value);
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateProject_UnexpectedErrorHappened_ReturnsObjectResultWith500StatusCode()
        {
            ProjectForCreationDto project = CreateRandomProjectForCreationDto();
            _projectService.Setup(service => service.CreateProject(It.IsAny<ProjectForCreationDto>()))
                .Throws(new Exception("error"));

            var result = _controller.CreateProject(project);

            var resultType = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, resultType.StatusCode);
        }

        [Fact]
        public void UpdateProject_ProjectIsNull_ReturnsBadRequest()
        {
            ProjectForUpdateDto project = null;

            var result = _controller.UpdateProject(Guid.NewGuid(), project);

            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

        [Fact]
        public void UpdateProject_ProjectNotExistsInDb_ReturnsNotFound()
        {
            ProjectForUpdateDto project = CreateRandomProjectForUpdateDto();
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
                .Returns((ProjectDto)null);

            var result = _controller.UpdateProject(Guid.NewGuid(), project);

            var resultType = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, resultType.StatusCode);
        }

        [Fact]
        public void UpdateProject_ProjectSuccessfullyUpdated_ReturnsNoContent()
        {
            ProjectForUpdateDto project = CreateRandomProjectForUpdateDto();
            ProjectDto projectDto = CreateRandomProjectDto();
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
               .Returns(projectDto);

            var result = _controller.UpdateProject(Guid.NewGuid(), project);

            var resultType = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, resultType.StatusCode);
        }

        [Fact]
        public void UpdateProject_UnexpectedErrorHappened_ReturnsObjectResultWith500StatusCode()
        {
            ProjectForUpdateDto project = CreateRandomProjectForUpdateDto();
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
                .Throws(new Exception("error"));

            var result = _controller.UpdateProject(Guid.NewGuid(), project);

            var resultType = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, resultType.StatusCode);
        }

        [Fact]
        public void DeleteProject_ProjectNotExistsInDb_ReturnsNotFound()
        {
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
               .Returns((ProjectDto)null);

            var result = _controller.DeleteProject(Guid.NewGuid());

            var resultType = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, resultType.StatusCode);
        }

        [Fact]
        public void DeleteProject_ProjectExistsInDb_ReturnsNoContent()
        {
            ProjectDto project = CreateRandomProjectDto();
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
               .Returns(project);

            var result = _controller.DeleteProject(Guid.NewGuid());

            var resultType = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, resultType.StatusCode);
        }

        [Fact]
        public void DeleteProject_UnexpectedErrorHappened_ReturnsObjectResultWith500StatusCode()
        {
            _projectService.Setup(service => service.GetProjectById(It.IsAny<Guid>()))
                .Throws(new Exception("error"));

            var result = _controller.DeleteProject(Guid.NewGuid());

            var resultType = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, resultType.StatusCode);
        }

        [Fact]
        public void GetProjectTasks_ProjectNotExistsInDb_ReturnsNotFound()
        {
            _projectService.Setup(service => service.IsProjectExists(It.IsAny<Guid>()))
                .Returns(false);

            var result = _controller.GetProjectTasks(Guid.NewGuid());

            var resultType = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, resultType.StatusCode);
        }

        [Fact]
        public void GetProjectTasks_ProjectExistsInDb_ReturnsOk()
        {
            _projectService.Setup(service => service.IsProjectExists(It.IsAny<Guid>()))
                .Returns(true);
            _projectService.Setup(service => service.GetProjectTasks(It.IsAny<Guid>()))
                .Returns(new List<TaskDto> { new TaskDto(), new TaskDto() });

            var result = _controller.GetProjectTasks(Guid.NewGuid());

            var resultType = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, resultType.StatusCode);
            var tasks = Assert.IsType<List<TaskDto>>(resultType.Value);
            Assert.Equal(2, tasks.Count);
        }

        private ProjectDto CreateRandomProjectDto()
        {
            return new ProjectDto
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Priority = _rand.Next(1, 5),
                Status = ((ProjectStatus)_rand.Next(1, 3)),
                StartDate = DateTime.UtcNow,
                CompletionDate = DateTime.UtcNow.AddDays(7),
                Tasks = null
            };
        }

        private ProjectForCreationDto CreateRandomProjectForCreationDto()
        {
            return new ProjectForCreationDto
            {
                Name = Guid.NewGuid().ToString(),
                StartDate = DateTime.UtcNow,
                CompletionDate = DateTime.UtcNow.AddDays(2),
                Priority = _rand.Next(1, 5),
                Status = ((ProjectStatus)_rand.Next(1, 3))
            };
        }

        private ProjectForUpdateDto CreateRandomProjectForUpdateDto()
        {
            return new ProjectForUpdateDto
            {
                Name = Guid.NewGuid().ToString(),
                StartDate = DateTime.UtcNow,
                CompletionDate = DateTime.UtcNow.AddDays(2),
                Priority = _rand.Next(1, 5),
                Status = ((ProjectStatus)_rand.Next(1, 3)),
                Id = Guid.NewGuid()
            };
        }
    }
}
