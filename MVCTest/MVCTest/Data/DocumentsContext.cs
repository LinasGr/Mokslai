using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Models
{
  public class DocumentsContext : DbContext
  {
    public DocumentsContext(DbContextOptions<DocumentsContext> options)
        : base(options)
    {
    }

    public DbSet<MVCTest.Models.Document> Document { get; set; }

    public DbSet<MVCTest.Models.Association> Association { get; set; }

    public DbSet<MVCTest.Models.Profile> Profile { get; set; }
  }
}
