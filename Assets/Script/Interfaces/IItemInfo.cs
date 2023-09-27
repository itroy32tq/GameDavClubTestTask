using UnityEngine;

namespace Script.Interfaces
{
    public interface IItemInfo
    {
        string Id { get; }
        string Title { get; }
        string Description { get; }
        int MaxItemsInInventarySlot { get; }
        Sprite SpriteIcon { get; }
        public float Scale { get;  }
        float ShootInterval { get; }
        GameObject BulletPref { get; }
        string BulletItemId { get; }
    }
}
