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

    public InventoryWithSlots Inventory => tester.Inventory;
    private Tester tester;

    private void Awake()
    {
        for (int i = 0; i < _inventaryCapacity; i++)
        {
            Instantiate(_uiSlot, _grid);
        }
        
    }

    private void Start()
    {
        _showInventoryButton.onClick.AddListener(OnShowInventaryButtonClick);
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        
        tester = new Tester(_appleInfo, _pepperInfo, uiSlots);
        tester.FillSlots();
        _grid.gameObject.SetActive(false);
    }
    private void OnShowInventaryButtonClick()
    { 
        if (!_grid.gameObject.activeInHierarchy) 
            _grid.gameObject.SetActive(true); 
        else _grid.gameObject.SetActive(false);
    }
}
