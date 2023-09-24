using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _pepperInfo;

    public InventoryWithSlots Inventory => tester.Inventory;
    private Tester tester;

    private void Awake()
    {

    }

    private void Start()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        tester = new Tester(_appleInfo, _pepperInfo, uiSlots);
        tester.FillSlots();
    }
}
