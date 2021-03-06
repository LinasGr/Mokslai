﻿using Abp.EntityFrameworkCore;
using Acme.SimpleTaskApp.People;
using Acme.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Acme.SimpleTaskApp.EntityFrameworkCore
{
    public class SimpleTaskAppDbContext : AbpDbContext
    {
    //Add DbSet properties for your entities...
      public DbSet<Tasks.Task> Tasks { get; set; }
      public DbSet<Person> People { get; set; }

    public SimpleTaskAppDbContext(DbContextOptions<SimpleTaskAppDbContext> options) 
            : base(options)
        {

        }
    }
}
