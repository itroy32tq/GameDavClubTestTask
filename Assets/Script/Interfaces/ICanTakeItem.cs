using System;
using Script.ItemSpace;

namespace Script.Interfaces
{
    public interface ICanTakeItem
    {
        void TakeItem(Item item);

        //event Action<object, It> OnTakeItemOnMapEvent;
    }
}
