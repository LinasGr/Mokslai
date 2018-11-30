using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Models;

namespace EntityCodeFirst
{
  class EntityContext:DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Profile> Profiles { get; set; }
  }
}
