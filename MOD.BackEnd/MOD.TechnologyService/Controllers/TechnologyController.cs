using Microsoft.AspNetCore.Mvc;
using MOD.Entities;
using MOD.TechnologyService.Repository;
using System.Transactions;

namespace MOD.TechnologyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ISkillRepository _skillRepository;

        public TechnologyController(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        // GET: api/Technology
        [HttpGet]
        public IActionResult Get()
        {
            var skills = _skillRepository.GetSkills();
            return new OkObjectResult(skills);
        }

        // GET: api/Technology/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var skill = _skillRepository.GetSkillById(id);
            return new OkObjectResult(skill);
        }

        // POST: api/Technology
        [HttpPost, Route("addTechnology")]
        public IActionResult Post([FromBody] Skill skill)
        {
            using (var scope = new TransactionScope())
            {
                _skillRepository.InsertSkill(skill);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = skill.SkillId }, skill);
            }
        }

        // PUT: api/Technology/5
        [HttpPost,Route("updateTechnology")]
        public IActionResult Post(int id, [FromBody] Skill skill)
        {
            if (skill != null)
            {
                using (var scope = new TransactionScope())
                {
                    _skillRepository.UpdateSkill(skill);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _skillRepository.DeleteSkill(id);
            return new OkResult();
        }
    }
}
