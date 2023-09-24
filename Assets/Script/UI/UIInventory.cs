using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _pepperInfo;
    [SerializeField, Range(1, 15)] private int _inventaryCapacity = 5;
    [SerializeField] private GameObject _uiSlot;
    [SerializeField] private Transform _grid;
    [SerializeField] private Button _showInventoryButton;
    [SerializeField] private PlayerConfiguration _playerConfiguration;

    private List<UIInventorySlot> _uiSlotList = new List<UIInventorySlot>();

    List<KeyValuePair<InventoryItemInfo, int>> _itemsData;

    private InventoryWithSlotsService _service;
    public InventoryWithSlots Inventory => _service.Inventory;

    

    private void Awake()
    {
        InitUIInventory(_inventaryCapacity);
    }

    private void InitUIInventory(int capacity)
    {
        for (int i = 0; i < capacity; i++)
        {
            var slotOnject =  Instantiate(_uiSlot, _grid);
            _uiSlotList.Add(slotOnject.GetComponent<UIInventorySlot>());
        }
    }

    private void Start()
    {
        _showInventoryButton.onClick.AddListener(OnShowInventaryButtonClick);

        _service = new InventoryWithSlotsService(_uiSlotList, _playerConfiguration.GetBaseInventoryItems);
        _grid.gameObject.SetActive(false);
    }

    private void OnShowInventaryButtonClick()
    { 
        if (!_grid.gameObject.activeInHierarchy) 
            _grid.gameObject.SetActive(true); 
        else _grid.gameObject.SetActive(false);
    }
}
