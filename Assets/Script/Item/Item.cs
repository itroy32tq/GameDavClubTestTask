using Script.Interfaces;
using Script.Structs;

namespace Script.ItemSpace
{
    public class Item : BaseItem
    {
        public override BaseItem Clone()
        {
            var clonedItem = new Item(Info);
            clonedItem.State.Amount = State.Amount;
            return clonedItem;
        }
        public Item(IItemInfo info)
        {
            Info = info;
            State = new ItemState();
        }
    }
}

