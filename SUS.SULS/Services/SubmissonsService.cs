using SUS.SULS.Data;
using System;
using System.Linq;

namespace SUS.SULS
{
    internal class SubmissonsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissonsService(ApplicationDbContext db,Random random)
        {
            this.db = db;
            this.random = random;
        }
        public void Create(string userId, string code, string problemId)
        {
            var problemMaxPoints = this.db.Problems.Where(x => x.Id == problemId).Select(x => x.Points).FirstOrDefault();

            var submission = new Submission()
            {
                Code = code,
                ProblemId = problemId,
                UserId = userId,
                AchievedResult = (ushort)this.random.Next(0, problemMaxPoints + 1),
                CreatedOn = DateTime.UtcNow

            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Find(id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}