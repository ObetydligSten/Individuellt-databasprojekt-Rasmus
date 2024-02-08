using Individuellt_databasprojekt_Rasmus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individuellt_databasprojekt_Rasmus.Data
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<Kurs> Kurss { get; set; }
        public DbSet<Betyg> Betygs { get; set; }
        public object Student { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source = RASMUS-LAPTOP;Initial Catalog = IndividuelltDBProjekt;Integrated Security=True;TrustServerCertificate = Yes");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Betyg>()
                .HasKey(e => new {e.StudentId, e.PersonalId, e.KursId});

            modelBuilder.Entity<Betyg>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Betyg>()
                .HasOne(k => k.Kurs)
                .WithMany(k => k.Kurss)
                .HasForeignKey(k => k.KursId);

            modelBuilder.Entity<Betyg>()
                .HasOne(p => p.Personal)
                .WithMany(p => p.Personals)
                .HasForeignKey(p => p.PersonalId);


            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 1,
                FirstName = "Lasse",
                LastName = "Persson",
                PersonNr = "19850312-1234",
                Class = "A1",
            },
            new Student
            {
                StudentId = 2,
                FirstName = "Anna",
                LastName = "Andersson",
                PersonNr = "19901005-5678",
                Class = "B2",
            },
            new Student
            {
                StudentId = 3,
                FirstName = "Erik",
                LastName = "Ekström",
                PersonNr = "19930420-9012",
                Class = "A1",
            },
            new Student
            {
                StudentId = 4,
                FirstName = "Maria",
                LastName = "Månsson",
                PersonNr = "19970215-3456",
                Class = "B2",
            },
            new Student
            {
                StudentId = 5,
                FirstName = "Karl",
                LastName = "Karlsson",
                PersonNr = "19981230-7890",
                Class = "C3",
            },
            new Student
            {
                StudentId = 6,
                FirstName = "Sara",
                LastName = "Svensson",
                PersonNr = "20010325-2345",
                Class = "B2",
            },
            new Student
            {
                StudentId = 7,
                FirstName = "Johan",
                LastName = "Johansson",
                PersonNr = "19940810-6789",
                Class = "A1",
            },
            new Student
            {   
                StudentId = 8,
                FirstName = "Emma",
                LastName = "Engström",
                PersonNr = "19871203-0123",
                Class = "A1",
            },
            new Student
            {   
                StudentId = 9,
                FirstName = "Peter",
                LastName = "Petersson",
                PersonNr = "20000218-4567",
                Class = "C3",
            },
            new Student
            {   
                StudentId = 10,
                FirstName = "Lisa",
                LastName = "Lindström",
                PersonNr = "19921205-8901",
                Class = "B2",
            },
            new Student
            {   
                StudentId = 11,       
                FirstName = "Anders",
                LastName = "Andersson",
                PersonNr = "20000120-2345",
                Class = "A1",
            });

            modelBuilder.Entity<Personal>().HasData(new Personal
            {
                PersonalId = 1,
                FirstName = "Chris",
                LastName = "Jakobsson",
                Befattning = "Admin",
                YearsService = 6,
                Salary = 30000
            },
             new Personal
             {
                 PersonalId = 2,
                 FirstName = "Eva",
                 LastName = "Andersson",
                 Befattning = "Lärare",
                 YearsService = 8,
                 Salary = 35000
             },
            new Personal
            {
                PersonalId = 3,
                FirstName = "David",
                LastName = "Pettersson",
                Befattning = "Vaktmästare",
                YearsService = 4,
                Salary = 28000
            },
            new Personal
            {
                PersonalId = 4,
                FirstName = "Sofia",
                LastName = "Lindgren",
                Befattning = "Lärare",
                YearsService = 3,
                Salary = 32000
            },
            new Personal
            {
                PersonalId = 5,
                FirstName = "Lars",
                LastName = "Gustavsson",
                Befattning = "IT-tekniker",
                YearsService = 5,
                Salary = 38000
            },
            new Personal
            {
                PersonalId = 6,
                FirstName = "Emma",
                LastName = "Andersson",
                Befattning = "Lärare",
                YearsService = 2,
                Salary = 26000
            });

            modelBuilder.Entity<Kurs>().HasData(new Kurs
            {
                KursId = 1,
                KursName = "Svenska",
                Active = false
            },
            new Kurs
            {
                KursId = 2,
                KursName = "Engelska",
                Active = false
            },
            new Kurs
            {
                KursId = 3,
                KursName = "Matematik",
                Active = true
            },
            new Kurs
            {
                KursId = 4,
                KursName = "Programmering",
                Active = false
            });



            modelBuilder.Entity<Betyg>().HasData(
            new Betyg
            {
                KursId = 1,
                StudentId = 1,
                PersonalId = 2,
                Grade = 3,
                GradeSet = new DateOnly(2023, 11, 01)
            },
            new Betyg
            {
                KursId = 2,
                StudentId = 2,
                PersonalId = 4,
                Grade = 4,
                GradeSet = new DateOnly(2023, 10, 15)
            },
            new Betyg
            {
                KursId = 3,
                StudentId = 3,
                PersonalId = 6,
                Grade = 5,
                GradeSet = new DateOnly(2023, 12, 05)
            },
            new Betyg
            {
                KursId = 4,
                StudentId = 4,
                PersonalId = 2,
                Grade = 3,
                GradeSet = new DateOnly(2023, 11, 20)
            },
            new Betyg
            {
                KursId = 1,
                StudentId = 5,
                PersonalId = 4,
                Grade = 4,
                GradeSet = new DateOnly(2023, 12, 10)
            },
            new Betyg
            {
                KursId = 2,
                StudentId = 6,
                PersonalId = 2,
                Grade = 5,
                GradeSet = new DateOnly(2023, 10, 30)
            },
            new Betyg
            {
                KursId = 3,
                StudentId = 7,
                PersonalId = 6,
                Grade = 3,
                GradeSet = new DateOnly(2023, 12, 25)
            },
            new Betyg
            {
                KursId = 4,
                StudentId = 8,
                PersonalId = 4,
                Grade = 4,
                GradeSet = new DateOnly(2023, 11, 12)
            },
            new Betyg
            {
                KursId = 1,
                StudentId = 9,
                PersonalId = 2,
                Grade = 5,
                GradeSet = new DateOnly(2023, 12, 01)
            },
            new Betyg
            {
                KursId = 2,
                StudentId = 10,
                PersonalId = 4,
                Grade = 3,
                GradeSet = new DateOnly(2023, 10, 20)
            },
            new Betyg
            {
                KursId = 3,
                StudentId = 11,
                PersonalId = 6,
                Grade = 4,
                GradeSet = new DateOnly(2023, 12, 15)
            },
            new Betyg
            {
                KursId = 4,
                StudentId = 1,
                PersonalId = 2,
                Grade = 5,
                GradeSet = new DateOnly(2024, 01, 28)
            },
            new Betyg
            {
                KursId = 1,
                StudentId = 2,
                PersonalId = 4,
                Grade = 3,
                GradeSet = new DateOnly(2024, 02, 05)
            },
            new Betyg
            {
                KursId = 2,
                StudentId = 3,
                PersonalId = 6,
                Grade = 4,
                GradeSet = new DateOnly(2023, 10, 25)
            },
            new Betyg
            {
                KursId = 3,
                StudentId = 4,
                PersonalId = 2,
                Grade = 1,
                GradeSet = new DateOnly(2023, 12, 10)
            },
            new Betyg
            {
                KursId = 4,
                StudentId = 5,
                PersonalId = 4,
                Grade = 3,
                GradeSet = new DateOnly(2024, 01, 20)
            },
            new Betyg
            {
                KursId = 1,
                StudentId = 6,
                PersonalId = 2,
                Grade = 2,
                GradeSet = new DateOnly(2023, 12, 15)
            },
            new Betyg
            {
                KursId = 2,
                StudentId = 7,
                PersonalId = 6,
                Grade = 5,
                GradeSet = new DateOnly(2023, 10, 30)
            },
            new Betyg
            {
                KursId = 3,
                StudentId = 8,
                PersonalId = 4,
                Grade = 3,
                GradeSet = new DateOnly(2023, 12, 10)
            },
            new Betyg
            {
                KursId = 4,
                StudentId = 9,
                PersonalId = 2,
                Grade = 2,
                GradeSet = new DateOnly(2023, 11, 25)
            },
            new Betyg
            {
                KursId = 1,
                StudentId = 10,
                PersonalId = 4,
                Grade = 1,
                GradeSet = new DateOnly(2023, 12, 05)
            }
            );



        }
    }
}
