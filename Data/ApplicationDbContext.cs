using ChatAppNats.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppNats.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Message> Messages { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=RINKU-LAPPY\SQLEXPRESS; Database=ChatAppDB; TrustServerCertificate=True; Trusted_Connection=True");
            optionsBuilder.UseSqlServer(@"Server=synapsedb.c1ysu4usmo3z.ap-south-1.rds.amazonaws.com, 1433;
                                        Database=SynapseDB;
                                        User Id=Rinku2001;
                                        Password=Rin-#KU29%;
                                        TrustServerCertificate=True;
                                        Encrypt=True;
                                        Connect Timeout=60;"
                                        //sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                                        //maxRetryCount: 5,              // Number of retries
                                        //maxRetryDelay: TimeSpan.FromSeconds(10), // Delay between retries
                                        //errorNumbersToAdd: null)
                                       );
                                        
                                        
        }
    }
}