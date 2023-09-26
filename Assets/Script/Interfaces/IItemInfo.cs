using UnityEngine;

namespace Assets.Script.Interfaces
{
    public interface IItemInfo
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemsInInventarySlot { get; }
        Sprite SpriteIcon { get; }
    }
}
