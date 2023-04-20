using TPIntegradorProgIII.Entities;
using Microsoft.EntityFrameworkCore;

namespace TPIntegradorProgIII.DBContexts
{
    public class TPContext : DbContext
    {
        public DbSet<Student> Swimmers { get; set; } //lo que hagamos con LINQ sobre estos DbSets lo va a transformar en consultas SQL
        public DbSet<Company> Meets { get; set; } //Los warnings los podemos obviar porque DbContext se encarga de eso.
        public DbSet<Offer> Trials { get; set; }

        public TPContext(DbContextOptions<TPContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Company meet1 = new Company()
            {
                Id = 1,
                MeetDate = "20-12-2022",
                MeetName = "Primer Meet",
                MeetPlace = "Rosario",
            };

            Company meet2 = new Company()
            {
                Id = 2,
                MeetDate = "25-12-2022",
                MeetName = "Segundo Meet",
                MeetPlace = "Buenos Aires",
            };

            modelBuilder.Entity<Company>().HasData(
                meet1, meet2);

            Offer trial1 = new Offer()
            {
                Id = 1,
                Distance = 100,
                Style = "Croll",
                MeetId = meet1.Id,
                MeetName = meet1.MeetName
            };

            Offer trial2 = new Offer()
            {
                Id = 2,
                Distance = 150,
                Style = "Espalda",
                MeetId = meet2.Id,
                MeetName = meet2.MeetName
            };

            modelBuilder.Entity<Offer>().HasData(
                trial1, trial2);

            Student swimmer1 = new Student()
            {
                Id = 1,
                Name = "Manuel",
                Surname = "Ibarbia",
                Email = "manuel@gmail.com",
                Password = "string",
                UserName = "string",
                DNI = 44555666,
                TrialId = trial1.Id,
                AttendedTrial = trial1.Style + " " + trial1.Distance + " metros" + " (" + trial1.MeetName + ")"
            };

            Student swimmer2 = new Student()
            {
                Id = 2,
                Name = "Luciano",
                Surname = "Solari",
                Email = "luciano@gmail.com",
                Password = "123456",
                UserName = "lucianoS",
                DNI = 33444555,
                TrialId = trial1.Id,
                AttendedTrial = trial1.Style + " " + trial1.Distance + " metros" + " (" + trial1.MeetName + ")"
            };

            Student swimmer3 = new Student()
            {
                Id = 3,
                Name = "Santiago",
                Surname = "Caso",
                Email = "santiago@gmail.com",
                Password = "123456",
                UserName = "santiagoC",
                DNI = 55666777,
                TrialId = trial2.Id,
                AttendedTrial = trial2.Style + " " + trial2.Distance + " metros" + " (" + trial2.MeetName + ")"
            };

            modelBuilder.Entity<Student>().HasData(
                swimmer1, swimmer2, swimmer3);

            modelBuilder.Entity<Company>()
                .HasMany<Offer>(m => m.Trials)
                .WithOne(t => t.Meet);

            modelBuilder.Entity<Offer>()
                .HasMany<Student>(t => t.RegisteredSwimmers)
                .WithOne(s => s.Trial);

            base.OnModelCreating(modelBuilder);
        }
    }
}
