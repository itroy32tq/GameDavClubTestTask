using Script.ItemSpace;
using Script.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Configurations
{
    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField, Header("Базовые параметры персонажа")] private BaseParamsData _baseParams = BaseParamsData.Empty;
        public BaseParamsData BaseParams { get => _baseParams; set => _baseParams = value; }

        [SerializeField, Header("Местоположение персонажа")] private Vector2 _location = Vector2.zero;
        public Vector2 Location { get => _location; set => _location = value; }

        [SerializeField, Header("Текущее оружие персонажа")] private string _currentWeapon;
        public string CurrentWeaponId { get => _currentWeapon; set => _currentWeapon = value; }

        [SerializeField, Header("Начальный инвентарь персонажа")] private List<ItemsData> _baseItems;
        public List<ItemsData> InventoryItems { get => _baseItems; set => _baseItems = value; }
    }
}

