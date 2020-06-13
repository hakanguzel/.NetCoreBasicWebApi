using System;
using BasicWebApi.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApi.Models
{
    public class StickyNotesContext : DbContext
    {
        public DbSet<StickyNote> StickyNotes { get; set; }
        public DbSet<User> Users { get; set; }

        public StickyNotesContext(DbContextOptions<StickyNotesContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                    Id = Guid.Parse("26f4e1ac-e426-421e-b2ea-e759500430f3"),
                    FirstName = "FirstName1",
                    LastName = "LastName1"
            },
                new User
                {
                    Id = Guid.Parse("6f793c05-8555-4090-a411-b16fdff9e5f1"),
                    FirstName = "FirstName2",
                    LastName = "LastName2"
                });

            modelBuilder.Entity<StickyNote>().HasData(new StickyNote
            {
                    Id = Guid.Parse("4469ec5f-b8ba-45e7-b144-a36fbcc48827"),
                    UserId = Guid.Parse("26f4e1ac-e426-421e-b2ea-e759500430f3"),
                    Title = "Test Title1",
                    Note = "Test Note1"
                },
                new StickyNote
                {
                    Id = Guid.Parse("1657de06-3e16-4ac7-8b9d-fc1359d1ddc6"),
                    UserId = Guid.Parse("26f4e1ac-e426-421e-b2ea-e759500430f3"),
                    Title = "Test Title2",
                    Note = "Test Note2"
                },
                new StickyNote
                {
                    Id = Guid.Parse("1fd849e2-f3b0-4a80-a7dd-32f47de67fcf"),
                    UserId = Guid.Parse("6f793c05-8555-4090-a411-b16fdff9e5f1"),
                    Title = "Test Title3",
                    Note = "Test Note3"
                },
                new StickyNote
                {
                    Id = Guid.Parse("48b06430-5ae0-4420-bb3a-0bbf5a528c7f"),
                    UserId = Guid.Parse("6f793c05-8555-4090-a411-b16fdff9e5f1"),
                    Title = "Test Title4",
                    Note = "Test Note4"
                }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
