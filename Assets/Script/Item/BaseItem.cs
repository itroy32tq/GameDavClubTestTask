using Assets.Script.Interfaces;
using Script.Interfaces;
using System;

namespace Script.ItemSpace
{
    public abstract class BaseItem
    {
        public ItemInfo Info { get; set; }
        public ItemState State { get; set; }
        public Type Type { get; set; }
        public T Clone<T>() where T : BaseItem
        {
            var clonedItem = (T)MemberwiseClone();
            clonedItem.State = new ItemState();
            clonedItem.State.Amount = State.Amount;
            return clonedItem;
        }
    }
}
