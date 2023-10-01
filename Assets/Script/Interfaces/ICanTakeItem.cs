using System;
using Script.ItemSpace;

namespace Script.Interfaces
{
    public interface ICanTakeItem
    {
        bool TryTakeItem(Item item);

        //event Action<object, It> OnTakeItemOnMapEvent;
    }
}
