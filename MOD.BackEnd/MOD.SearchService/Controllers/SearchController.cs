using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.SearchService.Models;
using MOD.SearchService.Repository;

namespace MOD.SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;

        public SearchController(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        // GET: api/Technology
        [HttpGet]
        //public IActionResult Get()
        //{
        //    var skills = _searchRepository.GetMentors();
        //    return new OkObjectResult(skills);
        //}

        // GET: api/Technology/5
        [Route("{id:int}")]
        [HttpGet]
        public IActionResult Get(int id)
        {
            var lstMentors = _searchRepository.GetMentorbySkillId(id);

            var mentors = lstMentors.Select(x => new MentorDto()
            {
                MentorId = x.MentorId,
                Name = x.MentorName,
                Skill = x.MentorSkills.FirstOrDefault(s => s.SkillId == id).Skill.Name,
                LinkedInUrl = x.LinkedInUrl,
                YearsOfExperience = x.YearsOfExperience,
                Email = x.EmailId,
                Fees = x.MentorSkills.FirstOrDefault(skill => skill.SkillId == id).Skill.Fees,
                NoOfTrainingsCompleted = x.MentorTrainings.Count(training => training.SkillId == id)
            }).ToList();

            return new OkObjectResult(mentors);
        }
    }
}
