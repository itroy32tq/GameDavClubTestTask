using Assets.Script.Controllers;
using PoketZone;
using Script.Inventoty;
using Script.ItemSpace;
using Script.Structs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class UIInventory : MonoBehaviour
    {
        [SerializeField] private GameObject _uiSlot;
        [SerializeField] private Transform _grid;
        [SerializeField] private Button _showInventoryButton;

        private List<UIInventorySlot> _uiSlotList = new List<UIInventorySlot>();
        private List<UIItem> _uiItemList = new List<UIItem>();
        private InventoryStateUpdater _updater;
        private PlayerController _playerController;
        public InventoryStateUpdater InventoryUpdater => _updater;
        public InventoryWithSlots InventoryModel { get; private set; }

        private void OnEnable()
        {
            _showInventoryButton.onClick.AddListener(OnShowInventaryButtonClick);
        }
        public void InitUIInventory(int capacity, PlayerController playerController)
        {
            _playerController = playerController;

            for (int i = 0; i < capacity; i++)
            {
                var slotPref = Instantiate(_uiSlot, _grid);
                _uiSlotList.Add(slotPref.GetComponent<UIInventorySlot>());
                var uiItem = slotPref.GetComponentInChildren<UIItem>();
                _uiItemList.Add(uiItem);
                uiItem.OnUIItemRemoveButtonClickEvent += OnUIItemRemoveButtonClick;
            }
            InventoryModel = new InventoryWithSlots(capacity);
            _updater = new InventoryStateUpdater(_uiSlotList);
            InventoryModel.OnInventoryStateChangedEvent += _updater.OnInventoryStateChanged;
            _grid.gameObject.SetActive(false);
        }
        private void OnUIItemRemoveButtonClick(object sender, Item Item)
        {
            Singleton<ItemsManager>.Instance.OnCreateItemOnMap(_playerController, Item.Clone<Item>());
            InventoryModel.Remove(sender, Item.Info.Id, Item.State.Amount);
        }
        private void OnShowInventaryButtonClick()
        {
            if (!_grid.gameObject.activeInHierarchy)
                _grid.gameObject.SetActive(true);
            else _grid.gameObject.SetActive(false);
        }
        public void FillSlots(List<ItemsData> data)
        {
            foreach (var part in data)
            {
                var info = Singleton<ItemsManager>.Instance.GetAssetForId(part.ItemInfoId);
                Item item = new Item(info);
                item.State.Amount = part.Count;
                if (!InventoryModel.TryToAdd(this, item))
                    Debug.Log("не удалось добавить предметы из конфигурации в инвентарь");
            }
            SetupInventoryUI(InventoryModel);
        }
        private void SetupInventoryUI(InventoryWithSlots inventory)
        {
            var allSlots = inventory.GetAllSlots();
            var allSlotsCount = allSlots.Length;
            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlotList[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }
        private void OnDisable()
        {
            _showInventoryButton.onClick.RemoveListener(OnShowInventaryButtonClick);
            InventoryModel.OnInventoryStateChangedEvent -= _updater.OnInventoryStateChanged;
        }
    }
}
