using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using MOD.Entities;
using MOD.TechnologyService.Controllers;
using MOD.TechnologyService.Repository;
using NBench;
using Xunit;
namespace MOD.XUnitTestProject.PerformanceTest
{
    public class TechnologyControllerPerformanceTest
    {
        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput,
        TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 5000)]
        [Fact]
        public void Get_ReturnOkObjectResult_GetTechnologyDetails_PerformanceTest()
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
    }
}
