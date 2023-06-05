namespace ExamProgramme.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }
        public DateTime Date { get; set; }
        public int Grade { get; set; }
    }
}
