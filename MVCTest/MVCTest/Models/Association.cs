using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTest.Models
{
  public class Association
  {
    public int ID { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime CreationDate{ get; set; }

    [Required]
    [StringLength(maximumLength:50,MinimumLength = 3)]
    public string Name { get; set; }

    [Required]
    [DisplayName("Code")]
    [StringLength(maximumLength: 10, MinimumLength = 3)]
    public string ShortName { get; set; }
  }
}
