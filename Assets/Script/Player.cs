using Assets.Script.Weapons;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

namespace PoketZone
{
    public class Player : Unit
    {
        [SerializeField] private WeaponController weaponController;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private VariableJoystick _joystick;
        [SerializeField] private Button _shootButton;
        [SerializeField] private UIInventory _playerInventory;
        [SerializeField, Range(1, 15)] private int _inventaryCapacity = 5;
        [SerializeField] private SpriteRenderer _weaponSpriteRenderer;
        [SerializeField] private SpriteRenderer _playerSpriteRenderer;
        [SerializeField] private WeaponInfo _defaultWeaponInfo;
        [SerializeField] private PlayerConfiguration _playerConfiguration;

        private Vector2 _shootDerection = Vector2.right;

        protected override void Start()
        {
            //todo
            base.Start();
            _shootButton.onClick.AddListener(OnShootButtonClick);

            _playerInventory.InitUIInventory(_inventaryCapacity);
            SetCurentWeapon(_defaultWeaponInfo);
            _playerInventory.InventoryService.FillSlots(_playerConfiguration.GetBaseInventoryItems);
            
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

    }
}
