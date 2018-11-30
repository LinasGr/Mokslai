using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Models
{
  class User
  {
    [Key]
    public string UserName { get; set; }

    private DateTime? _dateCreated = null;
    [DataType(DataType.Date)]
    public DateTime DateCreated
    {
      get
      {
        return this._dateCreated.HasValue
          ? this._dateCreated.Value
          : DateTime.Now;
      }

      set { this._dateCreated = value; }
    }

    [DefaultValue(false)]
    public bool Suspended { get; set; }
  }
}
