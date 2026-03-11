using ChatGram.Core.Entities.Message;
using ChatGram.Storage.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGram.Storage
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<MessageBase> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TextMessage>()
                .HasBaseType<MessageBase>();

            builder.Entity<FileMessage>()
                .HasBaseType<MessageBase>();

            builder.Entity<GeoMessage>()
                .HasBaseType<MessageBase>();

            base.OnModelCreating(builder);
        }
    }
}
