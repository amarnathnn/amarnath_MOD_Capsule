using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.Entities;
using MOD.TrainingService.Repository;

namespace MOD.TrainingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingRepository _trainingRepository;
        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        //  GET: api/Technology/5
        [HttpGet, Route("getTraining")]
        public IActionResult Get()
        {
            var lstTraining = _trainingRepository.GetTrainings();
            var lstTrainingDto = lstTraining.Select(x => new TrainingDto()
            {
                EndDate = x.EndDate.ToShortDateString(),
                MentorId = x.MentorId,
                MentorName = x.Mentor.MentorName,
                Progress = x.Progress,
                Rating = x.Rating,
                SkillId = x.SkillId,
                SkillName = x.Skill.Name,
                StartDate = x.StartDate.Date.ToShortDateString(),
                Status = x.Status,
                Timing = x.Timing,
                TrainingId = x.TrainingId,
                UserId = x.UserId,
                UserName = x.User.UserName,
                Fees = x.Skill.Fees
            }).ToList();
            return new OkObjectResult(lstTrainingDto);
        }
        // POST: api/User
        [HttpPost, Route("addTraining")]
        public IActionResult PostTraining([FromBody] Training training)
        {
            var status = _trainingRepository.InsertTraining(training);
            return new OkObjectResult(status);
        }

        [Route("updatetraining/{id}/{opr}")]
        [HttpPost]
        public IActionResult UpdateTraining(int id, string opr)
        {
            ResponseMessage response = null;
            //if (opr == "accept")
            //{
            //    response = _trainingRepository.AcceptTraining(id);
            //}
            //if (opr == "reject")
            //{
            //    response = _trainingRepository.RejectTraining(id);
            //}
            if (opr == "accept")
            {
                response = _trainingRepository.UpdateTraining(id, "accepted");
            }
            if (opr == "reject")
            {
                response = _trainingRepository.UpdateTraining(id, "rejected");
            }
            if (opr == "paymentdone")
            {
                response = _trainingRepository.UpdateTraining(id, "inprogress");
            }

            return new OkObjectResult(response);
        }

        [HttpPost, Route("updateTraining")]
        public IActionResult UpdateTraining([FromBody] Training training)
        {
            var status = _trainingRepository.UpdateTraining(training);
            return new OkObjectResult(status);
        }

    }
}