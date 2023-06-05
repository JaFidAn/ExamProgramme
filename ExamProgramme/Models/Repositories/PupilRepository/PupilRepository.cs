namespace ExamProgramme.Models.Repositories.PupilRepository
{
    public class PupilRepository : Repository<Pupil>, IPupilRepository
    {
        public PupilRepository(AppDbContext context) : base(context)
        {
        }
    }
}
