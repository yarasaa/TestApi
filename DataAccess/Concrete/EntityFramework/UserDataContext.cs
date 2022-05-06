﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class UserDataContext : DbContext
    {
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(@"Host=localhost;Database=BurganUser;Username=postgres;Password=lamal159***");
            //optionsBuilder.UseNpgsql(@"Host=18.192.189.47:5433;Database=yugabyte;Username=admin;Password=rd2OZvpjbrthkDc0ASgiteXnUKCX6Y");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0UBP1P5;Database=SurveyTest;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=10.180.20.125;Database=SurveyTest;User Id=DEBUGUSER;Password=aAR=GsG4");
            //optionsBuilder.UseSqlServer(@"Server=10.200.0.14;Database=HUMANIST;User Id=DEBUGUSER;Password=aAR=GsG4");
            //optionsBuilder.UseSqlServer(@"Server=10.200.0.14;Database=HUMANIST;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=10.180.20.125;Database=SurveyTest;User Id=DEBUGUSER;Password=aAR=GsG4");


            base.OnConfiguring(optionsBuilder);

        }

        public DbSet<User>? PERTRANS1 { get; set; }
    }
}
