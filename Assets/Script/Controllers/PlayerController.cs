using Script.UI;
using UnityEngine;
using UnityEngine.UI;
using Script.Inventoty;
using Script.ItemSpace;
using Script.Interfaces;
using Script.Configurations;
using System.Collections.Generic;
using Assets.Script.Controllers;

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
        [SerializeField] private PlayerConfiguration _playerConfiguration;

        private Vector2 _shootDerection = Vector2.right;
        private ItemInfo _currentweapon;
        public ItemInfo CurrentWeapon => _currentweapon;
        public InventoryWithSlots InventoryModel => _playerInventory.InventoryModel;
        //public event Action<object, Item> OnTakeItemOnMapEvent;

        private void OnEnable()
        {
            _shootButton.onClick.AddListener(OnShootButtonClick);
        }
        protected override void Start()
        {
            base.Start();
            Init(_playerConfiguration);
        }
        public void Init(PlayerConfiguration configuration)
        {
            //создаем инвентарь
            _playerInventory.InitUIInventory(_playerConfiguration.BaseParams.InventoryCapacity, this);
            //местопложения, здоровье и скорость персонажа
            transform.position = configuration.Location;
            Health = configuration.BaseParams.MaxHealth;
            Speed = configuration.BaseParams.MoveSpeed;
            //оружие персонажа
            var weaponInfo = Singleton<ItemsManager>.Instance.GetAssetForId(configuration.CurrentWeaponId);
            SetCurentWeapon(weaponInfo);
            //заполняем инвентарь
            _playerInventory.FillSlots(_playerConfiguration.InventoryItems);
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
            _currentweapon = weapon;
            weaponController.ConfigureWeapon(_currentweapon);
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
        public bool TryTakeItem(Item item)
        {
            var isPlace = InventoryModel.IsPlaceForItem(item.Info.Id);
            if (isPlace) 
                _playerInventory.FillSlots(new List<ItemsData>(){new ItemsData(item.Info.Id, item.State.Amount)});
            return isPlace;
        }
        private void OnDisable()
        {
            _shootButton.onClick.RemoveListener(OnShootButtonClick);
        }
    }
}
