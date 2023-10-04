using Assets.Script.Interfaces;
using Script.Interfaces;
using Script.Structs;
using System;

namespace Script.ItemSpace
{
    public class Item : BaseItem
    {

        public Item(ItemInfo info)
        {
            Info = info;
            State = new ItemState();
        }
    }
}

