using Script.Structs;
using System;

namespace Script.ItemSpace
{
    public abstract class BaseItem
    {
        public ItemInfo Info { get; set; }
        public ItemState State { get; set; }
        public Type Type { get; set; }
        public abstract BaseItem Clone();
    }
}
