using Script.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Script.Inventoty;
using Script.ItemSpace;
using Script.Interfaces;
using Script.Configurations;
using Script.Structs;

namespace PoketZone
{
    public class PlayerController : Unit, ICanTakeItem
    {
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private VariableJoystick _joystick;
        [SerializeField] private Button _shootButton;
        [SerializeField] private UIInventory _playerInventory;
        [SerializeField] private SpriteRenderer _weaponSpriteRenderer;
        [SerializeField] private SpriteRenderer _playerSpriteRenderer;
        [SerializeField] private ItemInfo _defaultWeaponInfo;
        [SerializeField] private PlayerConfiguration _playerConfiguration;

        public InventoryWithSlots InventoryModel => _playerInventory.InventoryModel;

        private Vector2 _shootDerection = Vector2.right;
        public event Action<object, Item> OnTakeItemOnMapEvent;
        protected override void Start()
        {
            //todo
            base.Start();
            _shootButton.onClick.AddListener(OnShootButtonClick);
            _playerInventory.InitUIInventory(_playerConfiguration.GetBaseParams.InventoryCapacity);
            SetCurentWeapon(_defaultWeaponInfo);
            _playerInventory.FillSlots(_playerConfiguration.BaseInventoryItems);
        }

        public void Binding()
        {
            
        }
        private void OnShootButtonClick()
        {
            //из условия не понятно надо ли делать самонаводящуюся стрельбу
            weaponController.Shoot(_shootPoint.position, GetShootDirection());
        }
        private void Update() 
        {
            MakeMove(_joystick.Direction);
        }
        private void SetCurentWeapon(ItemInfo weapon)
        {
            weaponController.ConfigureWeapon(weapon);
            _weaponSpriteRenderer.sprite = weaponController.Weapon.SpriteIcon;
            _weaponSpriteRenderer.sortingOrder = _playerSpriteRenderer.sortingOrder + 1;
        }

        private Vector2 GetShootDirection()
        {
            if (_shootDerection == Vector2.right)
                return Faceing;
            //todo
            return _shootDerection;
        }

        public void TakeItem(Item item)
        {
            var g = item.Info;
        }
    }
}
