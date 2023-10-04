using Script.ItemSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Interfaces
{
    public interface IMyCloneable
    { 
        BaseItem Clone<T>(T obj) where T : BaseItem;
    }
}
