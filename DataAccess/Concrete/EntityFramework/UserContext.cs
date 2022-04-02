﻿using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Concrete.EntityFramework
{
    //Context database tabloları ile proje classlarına bağlamak için vardır.
    public class UserContext : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(@"Host=localhost;Database=BurganUser;Username=postgres;Password=lamal159***");
            //optionsBuilder.UseNpgsql(@"Host=18.192.189.47:5433;Database=yugabyte;Username=admin;Password=rd2OZvpjbrthkDc0ASgiteXnUKCX6Y");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-0UBP1P5;Database=SurveyTest;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Server=10.180.20.125;Database=SurveyTest;User Id=DEBUGUSER;Password=aAR=GsG4");
            

            base.OnConfiguring(optionsBuilder);
           
        }


        public DbSet<UserTest>? UserTest { get; set; }
        public DbSet<VoteLimit>? VoteLimits { get; set; }
        
       


    }
}
