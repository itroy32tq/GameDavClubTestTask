using Assets.Script.Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Configurations/ItemInfo")]
public class ItemInfo : ScriptableObject, IItemInfo
{
    [SerializeField] private string _id;
    [SerializeField] private string _title;
    [SerializeField] private string _description;
    [SerializeField] private int _maxItemsInInventarySlot;
    [SerializeField] private Sprite _icon;
    public string Id { get => _id; }
    public string Title { get => _title; }
    public string Description { get => _description; }
    public int MaxItemsInInventarySlot { get => _maxItemsInInventarySlot; }
    public Sprite SpriteIcon { get=> _icon; }
}
