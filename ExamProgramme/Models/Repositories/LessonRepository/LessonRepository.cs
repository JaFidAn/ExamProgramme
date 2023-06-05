namespace ExamProgramme.Models.Repositories.LessonRepository
{
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
