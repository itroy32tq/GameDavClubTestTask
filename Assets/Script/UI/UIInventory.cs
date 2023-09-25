using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{

    
    [SerializeField] private GameObject _uiSlot;
    [SerializeField] private Transform _grid;
    [SerializeField] private Button _showInventoryButton;

    private List<UIInventorySlot> _uiSlotList = new List<UIInventorySlot>();
    private List<UIItem> _uiItemList = new List<UIItem>();

    private InventoryWithSlotsService _service;
    public InventoryWithSlotsService InventoryService => _service;
    public InventoryWithSlots Inventory => _service.Inventory;



    public void InitUIInventory(int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            var slotOnject =  Instantiate(_uiSlot, _grid);
            _uiSlotList.Add(slotOnject.GetComponent<UIInventorySlot>());
            var uiItem = slotOnject.GetComponentInChildren<UIItem>();
            uiItem.OnUIItemRemoveButtonClickEvent += OnUIItemRemoveButtonClick;
            _uiItemList.Add(uiItem);
        }
        _service = new InventoryWithSlotsService(_uiSlotList);
        _grid.gameObject.SetActive(false);
    }

    private void OnUIItemRemoveButtonClick(object sender, UIItem item)
    {
        _service.TryRemoveItemOnClick(sender, item);
    }

    private void Start()
    {
        _showInventoryButton.onClick.AddListener(OnShowInventaryButtonClick);

        
    }

    private void OnShowInventaryButtonClick()
    { 
        if (!_grid.gameObject.activeInHierarchy) 
            _grid.gameObject.SetActive(true); 
        else _grid.gameObject.SetActive(false);
    }
}
