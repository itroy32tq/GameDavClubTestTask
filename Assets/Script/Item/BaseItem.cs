using Script.Interfaces;
using System;

namespace Script.ItemSpace
{
    public abstract class BaseItem
    {
        public IItemInfo Info { get; set; }
        public IItemState State { get; set; }
        public Type Type { get; set; }
        public virtual BaseItem Clone() { return this; }
    }
}
