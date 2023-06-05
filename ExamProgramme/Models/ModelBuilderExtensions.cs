using Microsoft.EntityFrameworkCore;

namespace ExamProgramme.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pupil>().HasData(
             new Pupil { Id = 1, Name = "Cavid", Surname = "Alagezov", Class = 3 },
             new Pupil { Id = 2, Name = "Ali", Surname = "Farzaliyev", Class = 2 },
             new Pupil { Id = 3, Name = "Vali", Surname = "Mamedov", Class = 1 },
             new Pupil { Id = 4, Name = "Fidan", Surname = "Alagezova", Class = 1 },
             new Pupil { Id = 5, Name = "Shefa", Surname = "Quliyev", Class = 3 }
             );

            modelBuilder.Entity<Lesson>().HasData(
             new Lesson { Id = 1, LessonName = "Riyaziyyat", TeacherName = "Gunay", TeacherSurname = "Ibrahimova", Class = 3 },
             new Lesson { Id = 2, LessonName = "Ana dili", TeacherName = "Aza", TeacherSurname = "Aliyev", Class = 1 },
             new Lesson { Id = 3, LessonName = "Ingilis dili", TeacherName = "Jale", TeacherSurname = "Xasiyeva", Class = 3 },
             new Lesson { Id = 4, LessonName = "Informatika", TeacherName = "Ali", TeacherSurname = "Mamedov", Class = 3 }
             );

            modelBuilder.Entity<Exam>().HasData(
            new Exam { Id = 1, LessonId = 1, PupilId = 1, Date = DateTime.Now, Grade = 5 },
            new Exam { Id = 2, LessonId = 1, PupilId = 2, Date = DateTime.Now, Grade = 5 },
            new Exam { Id = 3, LessonId = 1, PupilId = 3, Date = DateTime.Now, Grade = 4 },
            new Exam { Id = 4, LessonId = 1, PupilId = 4, Date = DateTime.Now, Grade = 4 },
            new Exam { Id = 5, LessonId = 1, PupilId = 5, Date = DateTime.Now, Grade = 5 },

            new Exam { Id = 6, LessonId = 2, PupilId = 1, Date = DateTime.Now, Grade = 5 },
            new Exam { Id = 7, LessonId = 2, PupilId = 2, Date = DateTime.Now, Grade = 5 },
            new Exam { Id = 8, LessonId = 2, PupilId = 3, Date = DateTime.Now, Grade = 4 },
            new Exam { Id = 9, LessonId = 2, PupilId = 4, Date = DateTime.Now, Grade = 4 },
            new Exam { Id = 10, LessonId = 2, PupilId = 5, Date = DateTime.Now, Grade = 5 },

            new Exam { Id = 11, LessonId = 3, PupilId = 1, Date = DateTime.Now, Grade = 5 },
            new Exam { Id = 12, LessonId = 3, PupilId = 2, Date = DateTime.Now, Grade = 5 },
            new Exam { Id = 13, LessonId = 3, PupilId = 3, Date = DateTime.Now, Grade = 4 },
            new Exam { Id = 14, LessonId = 3, PupilId = 4, Date = DateTime.Now, Grade = 4 },
            new Exam { Id = 15, LessonId = 3, PupilId = 5, Date = DateTime.Now, Grade = 5 }
            );

        }
    }
}
