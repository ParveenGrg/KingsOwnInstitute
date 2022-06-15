using KingsOwnInstitute.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingsOwnInstitute.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<SeminarType> SeminarTypes { get; set; }
        public DbSet<Seminar> Seminars { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<RegistrationInfo> RegistrationInfo { get; set; }

        public DbSet<SeminarOrganizer> SeminarOrganizers { get; set; }
    }
}
