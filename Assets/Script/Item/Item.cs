
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

