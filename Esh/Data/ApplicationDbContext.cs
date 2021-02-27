using Esh.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esh.Data
{
    public class ApplicationDbContext : IdentityDbContext<ChatApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        //protected  void OnConfiguring(ApplicationDbContext applicationDbContext)
        //{

        //applicationDbContext.UseSqlServer("");
        //}
        public DbSet<EshUser> Eusers { get; set; }
        public DbSet<Connection_Req> Connection_Reqs { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<PostData> postDatas { get; set; }
        //public DbSet<UsersPost> UsersPosts { get; set; }
        //public DbSet<Workp> Workps { get; set; }
        //public DbSet<Post_Create> Posts { get; set; }
        //public DbSet<MyNetwork> MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Post_Create>().OwnsOne(x => x.Id);

            //modelBuilder.Entity<MyNetwork>().HasNoKey();
            modelBuilder.Entity<Connection_Req>()
            .HasKey(e => new { e.Recivername, e.requestuser });
            modelBuilder.Entity<Friend>()
            .HasKey(e => new { e.fid, e.uid });
            
            //modelBuilder.Entity<Friend>().HasNoKey();
            // for Message table
            modelBuilder.Entity<Message>()
                .HasOne(mes => mes.SenderUser)
                .WithMany(u => u.MessagesSent)
                .HasForeignKey(mes => mes.SenderUserID);

            modelBuilder.Entity<Message>()
                .HasOne(mes => mes.ReceiverUser)
                .WithMany(u => u.MessagesReceived)
                .HasForeignKey(mes => mes.ReceiverUserID);
            //modelBuilder.Entity<EshUserEducation>().HasKey( sc => new { sc.EducationId,sc.EshUserId});
            //base.OnModelCreating(modelBuilder);
            //oneToManyRelationshipConfiguration(modelBuilder);
        }

        //protected override void OnModelCreating

        /*private void oneToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Education>()
        .HasMany(c => c.User)
        .WithOne(s => s.Education)
        .IsRequired();
        }*/



        
        public DbSet<Message> Messages { get; set; }
        //public DbSet<Education> Educations { get; set; }
        //public EshUserEducation EshUserEducations { get; set; }
        //public DbSet<EshUsersEducation> EshUsersEducation { get; set; }
        //
        //public DbSet<Organization> Organizations { get; set; }
        //public DbSet<Skill> Skills { get; set; }





    }
}
