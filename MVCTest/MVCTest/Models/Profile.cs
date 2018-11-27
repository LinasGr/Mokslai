using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MVCTest.Migrations;
using System.Globalization;
using Newtonsoft.Json;

namespace MVCTest.Models
{
  public class Profile
  {
    public int ID { get; set; }

    private DateTime _date = DateTime.Now;

    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Sukūrimo data")]
    public DateTime CreationDate
    {
      get { return _date; }
      set { _date = value; }
    }

    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 3)]
    [Display(Name="Vardas")]
    public string Name { get; set; }

    [Required]
    [Display(Name="Pavardė")]
    [StringLength(maximumLength: 50, MinimumLength = 3)]
    public string FamilyName { get; set; }

    [Display(Name = "Vardas Pavardė")]
    public string FullName
    {
      get { return Name + "  " + FamilyName; }
    }

    [Required]
    [Display(Name="E_paštas")]
    [DataType(DataType.EmailAddress)]
    public string E_Mail { get; set; }

    public int UserID { get; set; }

    [DefaultValue(true)]
    public bool Visible { get; set; }
  }
}
