namespace ExamProgramme.Models.Repositories.ExamRepository
{
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext context) : base(context)
        {
        }
    }
}
