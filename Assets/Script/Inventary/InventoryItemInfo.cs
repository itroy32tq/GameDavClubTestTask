using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Configurations/Inventory/InventoryItemInfo")]
public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
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
