using Assets.Script.Interfaces;
using Assets.Script.Configurations;
using Assets.Script.Structs;
using Assets.Script.Weapons;
using Script.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        [SerializeField] private WeaponInfo _defaultWeaponInfo;
        [SerializeField] private PlayerConfiguration _playerConfiguration;

        private Vector2 _shootDerection = Vector2.right;
        public event Action<object, IItemOnMap> OnTakeItemOnMapEvent;
        protected override void Start()
        {
            //todo
            base.Start();
            _shootButton.onClick.AddListener(OnShootButtonClick);
            _playerInventory.InitUIInventory(_playerConfiguration.GetBaseParams.InventoryCapacity);
            SetCurentWeapon(_defaultWeaponInfo);
            _playerInventory.FillSlots(_playerConfiguration.BaseInventoryItems);
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
        private void SetCurentWeapon(WeaponInfo weapon)
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

        public void TakeItem(IItemOnMap item)
        {
            var data = new FilingInventoryData((ItemInfo)item, item.CountOnMap);
            _playerInventory.FillSlots(new List<FilingInventoryData>(){data});
        }
    }
}
