using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Models
{
  class Association
  {
    [Key]
    public int AssociationId { get; set; }

    public string Name { get; set; }

    private DateTime? _dateCreated;
    [DataType(DataType.Date)]
    public DateTime DateCreated
    {
      get { return _dateCreated.HasValue ? _dateCreated.Value : DateTime.Now; }
      set { _dateCreated=value; }
    }

    public List<Document> Documents { get; set; }

    [DefaultValue(false)]
    public bool Suspended { get; set; }
  }
}
