using Microsoft.EntityFrameworkCore;
using MOD.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MOD.TrainingService.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly TrainingContext _dbContext;
        public TrainingRepository(TrainingContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ResponseMessage InsertTraining(Training training)
        {
            var message = new ResponseMessage();
            if (training == null)
            {
                message.SetErrorMessage("Invalid data");
            }
            var value = _dbContext.Add(training);
            var insertedCount = Save();
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Request sent successfully!");
            }
            else
            {
                message.SetErrorMessage("Error sending request");
            }
            return message;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return _dbContext.Trainings.Include(x => x.Mentor).Include(x => x.User).Include(x => x.Skill).ToList();
        }

        public int Save()
        {
            var insertedCount = _dbContext.SaveChanges();
            return insertedCount;
        }

        public int UpdateTraining(Training training)
        {
            _dbContext.Entry(training).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Save();
        }

        public ResponseMessage AcceptTraining(int trainingId)
        {
            var training = _dbContext.Trainings.Where(x => x.TrainingId == trainingId).Single();
            var message = new ResponseMessage();
            if (training == null)
            {
                message.SetErrorMessage("Invalid data");
                return message;
            }
            training.Status = "accepted";
            var insertedCount = UpdateTraining(training);
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Request sent successfully!");
            }
            else
            {
                message.SetErrorMessage("Error sending request");
            }
            return message;
        }

        public ResponseMessage RejectTraining(int trainingId)
        {
            var training = _dbContext.Trainings.Where(x => x.TrainingId == trainingId).Single();
            var message = new ResponseMessage();
            if (training == null)
            {
                message.SetErrorMessage("Invalid data");
            }
            training.Status = "rejected";
            var insertedCount = UpdateTraining(training);
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Request sent successfully!");
            }
            else
            {
                message.SetErrorMessage("Error sending request");
            }
            return message;
        }

        public ResponseMessage UpdateTraining(int trainingId,string opr)
        {
            var training = _dbContext.Trainings.Where(x => x.TrainingId == trainingId).Single();
            var message = new ResponseMessage();
            if (training == null)
            {
                message.SetErrorMessage("Invalid data");
                return message;
            }
            training.Status = opr;
            var insertedCount = UpdateTraining(training);
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Request sent successfully!");
            }
            else
            {
                message.SetErrorMessage("Error sending request");
            }
            return message;
        }

        ResponseMessage ITrainingRepository.UpdateTraining(Training training)
        {
            var etraining = _dbContext.Trainings.Where(x => x.TrainingId == training.TrainingId).Single();
            var message = new ResponseMessage();
            if (training == null)
            {
                message.SetErrorMessage("Invalid data");
                return message;
            }
            
            var insertedCount = UpdateTraining(training);
            if (insertedCount > 0)
            {
                message.SetSuccessMessage("Training updated successfully!");
            }
            else
            {
                message.SetErrorMessage("Error sending request");
            }
            return message;
        }
    }
}
