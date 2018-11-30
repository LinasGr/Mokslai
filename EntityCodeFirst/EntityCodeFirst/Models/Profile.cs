using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Models
{
  class Profile
  {
    [Key] public int ProfileId { get; set; }

    public string UserName { get; set; }
    public virtual User User { get; set; }

    public string Name { get; set; }
    public string FamilyName { get; set; }
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }
    public string EMail { get; set; }
    public string Mobile { get; set; }
  }
}
