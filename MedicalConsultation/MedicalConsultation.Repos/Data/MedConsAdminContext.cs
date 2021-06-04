using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MedicalConsultation.Models;

    public class MedConsAdminContext : DbContext
    {
        public MedConsAdminContext (DbContextOptions<MedConsAdminContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Contact> Contact { get; set; }
}
