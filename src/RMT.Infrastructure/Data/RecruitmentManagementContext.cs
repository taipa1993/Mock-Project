
using Microsoft.EntityFrameworkCore;
using RMT.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMT.Infrastructure.Data
{
    public class RecruitmentManagementContext : DbContext
    {
        public RecruitmentManagementContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CV> CVs { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRound> UserRounds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CV>().HasData(
                new CV
                {
                    Id = 1,
                    CandidateName = "Test",
                    Gender = "Male",
                    Status = "Not Process Yet",
                    University = "PTIT",
                    LevelId = 1,
                    PositionId = 1,
                    ApplyPositionNote = "test",
                    Note = "test note",
                    Address = "Ha Noi",
                    CVSource = "web",
                    InComingDate = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    CandidateDoB = DateTime.Now,
                    SalaryExpect = 10000,
                    SalaryOffer = 20000
                },
                new CV
                {
                    Id = 2,
                    CandidateName = "Test 2",
                    Gender = "Male",
                    Status = "Not Process Yet",
                    University = "PTIT",
                    LevelId = 2,
                    PositionId = 2,
                    ApplyPositionNote = "test",
                    Note = "test note",
                    Address = "Ha Noi",
                    CVSource = "web",
                    InComingDate = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    CandidateDoB = DateTime.Now,
                    SalaryExpect = 150000,
                    SalaryOffer = 200000
                },
                new CV
                {
                    Id = 3,
                    CandidateName = "Test 3",
                    Gender = "Male",
                    Status = "Not Process Yet",
                    University = "PTIT",
                    LevelId = 3,
                    PositionId = 3,
                    ApplyPositionNote = "test",
                    Note = "test note",
                    Address = "Ha Noi",
                    CVSource = "web",
                    InComingDate = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    CandidateDoB = DateTime.Now,
                    SalaryOffer = 120000,
                    SalaryExpect = 100000
                }
                );
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "Admin",
                   PasswordHash = "q+l3mg3u2+EYnCjgX4To3P8XfZuVXLHzzIqPD+3AkBU=",
                   Role = Role.Admin,
                   FullName = "AdminTest",
                   CreateAt = DateTime.Now,
                   UpdateAt = DateTime.Now
               },
               new User
               {
                   Id = 2,
                   UserName = "Hr",
                   PasswordHash = "q+l3mg3u2+EYnCjgX4To3P8XfZuVXLHzzIqPD+3AkBU=",
                   Role = Role.HR,
                   FullName = "HrTest",
                   CreateAt = DateTime.Now,
                   UpdateAt = DateTime.Now
               },
               new User
               {
                   Id = 3,
                   UserName = "Interviewer",
                   PasswordHash = "q+l3mg3u2+EYnCjgX4To3P8XfZuVXLHzzIqPD+3AkBU=",
                   Role = Role.Interviewer,
                   FullName = "InterViewer",
                   CreateAt = DateTime.Now,
                   UpdateAt = DateTime.Now
               }
           );
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 1,
                    Name = "Intern"
                }
                );
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 2,
                    Name = "Fresher"
                }
                );
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 3,
                    Name = "Junior"
                }
                );
            modelBuilder.Entity<Level>().HasData(
                new Level
                {
                    Id = 4,
                    Name = "Senior"
                }
                );
            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    Id = 1,
                    Name = ".NET"
                }
                );
            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    Id = 2,
                    Name = "Java"
                }
                );
            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    Id = 3,
                    Name = "PHP"
                }
                );
            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    Id = 4,
                    Name = "JS"
                }
                );

        }
    }

}
