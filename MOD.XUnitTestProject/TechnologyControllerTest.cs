using System;
using System.Collections.Generic;
using System.Text;
using MOD.UserService.Controllers;
using MOD.UserService.Repository;
using MOD.Logging;
using Xunit;
using MOD.TechnologyService.Repository;
using MOD.TechnologyService.Controllers;
using MOD.Entities;
using Moq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace MOD.XUnitTestProject
{
    public class TechnologyControllerTest
    {      
        [Fact]
        public void Get_ReturnAOkObjectResult_GetAllTechnology()
        {
            //Arrange
            var _skillRepository = new SkillRepository(DbContextMocker.GetTechnologyContext());
            var _tecnologyController = new TechnologyController(_skillRepository);

            // Act
            var response = _tecnologyController.Get();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(response);
            var data = Assert.IsAssignableFrom<List<Skill>>(okObjectResult.Value);
            Assert.True(data.Count >= 0);
        }
        [Fact]
        public void Get_ReturnAOkObjectResult_GetOneTechnologyByID()
        {
            //Arrange
            var _skillRepository = new SkillRepository(DbContextMocker.GetTechnologyContext());
            var _tecnologyController = new TechnologyController(_skillRepository);

            // Act
            var response = _tecnologyController.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public void Post_ReturnACreatedAtActionResult_AddTechnology()
        {
            //Arrange
            var _skillRepository = new SkillRepository(DbContextMocker.GetTechnologyContext());
            var _tecnologyController = new TechnologyController(_skillRepository);
            var testSkill = GetTestSkill();
            // Act
            var response = _tecnologyController.Post(testSkill);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(response);
            var insertedData = Assert.IsAssignableFrom<Skill>(createdResult.Value);
            Assert.Equal(testSkill.Name, insertedData.Name);          
        }
        [Fact]
        public void Post_ReturnAOkResult_UpdateTechnology()
        {
            //Arrange
            var _skillRepository = new SkillRepository(DbContextMocker.GetTechnologyContext());
            var _tecnologyController = new TechnologyController(_skillRepository);
            var testSkill = GetTestSkill();
            testSkill.SkillId = 4;
            testSkill.Prerequisites = "None";
            // Act
            var response = _tecnologyController.Post(4,testSkill);

            // Assert
            Assert.IsType<OkResult>(response);
           
        }
        //[Fact]
        //public void Get_ReturnAOkObjectResult_GetOneTechnologyByID_Test()
        //{
        //    // Arrange
        //    var mockRepo = new Mock<ISkillRepository>();
        //    mockRepo.Setup(e => e.GetSkills());
        //    var controller = new TechnologyController(mockRepo.Object);

        //    //Act
        //    var response = controller.Get();

        //    // Assert
        //    var objectResult =  Assert.IsType<OkObjectResult>(response);
        //    var data = Assert.IsAssignableFrom<IEnumerable<Skill>>(objectResult.Value);
        //    Assert.Equal(3, 3);
        //    //dbContext.Dispose();
        //}

        private Skill GetTestSkill()
        {
            Skill testSkill = new Skill();
            testSkill.Name = "SQL Server";
            testSkill.Toc = "SQL Server Basics, Stored Procedure, SQL Optimization";
            testSkill.Duration = "10 Days";

            return testSkill;
        }



    }
}
