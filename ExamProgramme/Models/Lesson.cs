namespace ExamProgramme.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public int Class { get; set; }
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
