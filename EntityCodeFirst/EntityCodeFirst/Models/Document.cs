using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Models
{
  class Document
  {
    [Key] public int DokumentID { get; set; }

    private DateTime? _dateCreated;
    [DataType(DataType.Date)]
    public DateTime DateCreated
    {
      get => _dateCreated ?? DateTime.Now;
      set => _dateCreated = value;
    }

    public string Title { get; set; }
    public string Text { get; set; }

    private DateTime? _dateValidFrom;
    [DataType(DataType.Date)]
    public DateTime DateValidFrom
    {
      get => _dateValidFrom ?? DateTime.Now;
      set => _dateValidFrom = value;
    }

    private DateTime? _dateValidTill;
    [DataType(DataType.Date)]
    public DateTime DateValidTill
    {
      get => _dateValidTill ?? DateTime.Now.AddYears(1);
      set => _dateValidTill = value;
    }

    public int AssociationId { get; set; }
    public virtual Association Association { get; set; }

    [DefaultValue(false)]
    public bool Activated { get; set; }
  }
}
