using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
  public interface IDoc
  {
    void AddNew();
    void Edit();
    void Delete();
    
    int Count { get; }
    int Current { get; }

    event EventHandler PositionChanged;
  }
}
