using Script.Structs;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Configurations
{
    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField, Header("Базовые параметры персонажа")] private BaseParamsData _baseParams = BaseParamsData.Empty;
        public BaseParamsData BaseParams { get => _baseParams; private set => _baseParams = value; }

        [SerializeField, Header("Местоположение персонажа")] private Vector2 _location = Vector2.zero;
        public Vector2 Location { get => _location; private set => _location = value; }

        [SerializeField, Header("Текущее оружие персонажа")] private string _currentWeapon;
        public string CurrentWeaponId { get => _currentWeapon; private set => _currentWeapon = value; }

        [SerializeField, Header("Начальный инвентарь персонажа")] private List<ItemsData> _baseItems;
        public List<ItemsData> BaseInventoryItems { get => _baseItems; private set => _baseItems = value; }

        public PlayerConfiguration(BaseParamsData baseParamsData, Vector2 location, string currentWeapon, List<ItemsData> itemsData)
        {
            _baseParams = baseParamsData; _location = location; _currentWeapon = currentWeapon; _baseItems = itemsData;
        }
    }
}

