using MOD.Entities;
using System.Collections.Generic;

namespace MOD.TrainingService.Repository
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetTrainings();
        //User GetUser(string username);
        ResponseMessage InsertTraining(Training user);
        ResponseMessage AcceptTraining(int trainingId);
        ResponseMessage UpdateTraining(int trainingId,string opr);
        ResponseMessage UpdateTraining(Training training);
        ResponseMessage RejectTraining(int trainingId);
        //bool InsertMentor(Mentor user);
        //void DeleteUser(string username);
        //void UpdateUser(User user);
        int Save();

    }
}
