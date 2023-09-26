using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Interfaces
{
    public interface ICanTakeItems
    {
        void TakeItems(IItemOnMap item);

        event Action<object, IItemOnMap> OnTakeItemOnMapEvent;
    }
}
