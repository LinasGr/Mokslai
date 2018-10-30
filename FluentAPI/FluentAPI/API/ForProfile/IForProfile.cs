using System.Collections.Generic;
using FluentAPI.Models;

namespace FluentAPI.API.ForProfile
{
  interface IForProfile
  {
    void List();
    IForProfile Is(DocumentStatus status);
    IForProfile Not(DocumentStatus status);
    IForProfile OrderDESC(DocumentColumns columns);
    IForProfile OrderASC(DocumentColumns columns);
  }
}
