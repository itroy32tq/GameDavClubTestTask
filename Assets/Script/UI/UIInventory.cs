using Assets.Script.Interfaces;
using Script.Inventoty;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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
        public InventoryStateUpdater InventoryUpdater => _updater;
        public InventoryWithSlots InventoryModel { get; private set; }

        private void Start()
        {
            _showInventoryButton.onClick.AddListener(OnShowInventaryButtonClick);

        }
        public void InitUIInventory(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                var slotOnject = Instantiate(_uiSlot, _grid);
                _uiSlotList.Add(slotOnject.GetComponent<UIInventorySlot>());
                var uiItem = slotOnject.GetComponentInChildren<UIItem>();
                uiItem.OnUIItemRemoveButtonClickEvent += OnUIItemRemoveButtonClick;
                _uiItemList.Add(uiItem);
            }
            InventoryModel = new InventoryWithSlots(_uiSlotList.Count);
            _updater = new InventoryStateUpdater(_uiSlotList);
            InventoryModel.OnInventoryStateChangedEvent += _updater.OnInventoryStateChanged;
            _grid.gameObject.SetActive(false);
        }
        private void OnUIItemRemoveButtonClick(object sender, UIItem uiitem)
        {
            InventoryModel.Remove(sender, ((UIInventoryItem)uiitem).Item.Info.Id);
        }
        private void OnShowInventaryButtonClick()
        {
            if (!_grid.gameObject.activeInHierarchy)
                _grid.gameObject.SetActive(true);
            else _grid.gameObject.SetActive(false);
        }
        /// <summary>
        /// переносим предметы и их количество из конфигурации в инвентарь
        /// </summary>
        public void FillSlots(List<BaseInventoryData> baseItems)
        {
            foreach (var baseItem in baseItems)
            {
                var item = new InventoryItem(baseItem.itemInfo);
                item.State.Amount = baseItem.count;
                if (!InventoryModel.TryToAdd(this, item))
                    Debug.Log("не удалось добавить предметы из конфигурации в инвентарь");
            }
            SetupInventoryUI(InventoryModel);
        }
        /// <summary>
        /// удаляем элемент по клику на кнопку из инвентаря
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="uiitem"></param>
        private void SetupInventoryUI(InventoryWithSlots inventory)
        {
            var allSlots = InventoryModel.GetAllSlots();
            var allSlotsCount = allSlots.Length;
            for (int i = 0; i < allSlotsCount; i++)
            {
                var slot = allSlots[i];
                var uiSlot = _uiSlotList[i];
                uiSlot.SetSlot(slot);
                uiSlot.Refresh();
            }
        }
    }
}
