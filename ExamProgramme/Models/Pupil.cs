namespace ExamProgramme.Models
{
    public class Pupil
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
