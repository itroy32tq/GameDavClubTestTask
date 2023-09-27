using Script.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Configurations
{
    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField, Header("Базовые параметры персонажа")] private BaseParamsData _baseParams = BaseParamsData.Empty;
        public BaseParamsData GetBaseParams => _baseParams;

        [SerializeField, Header("Начальный инвентарь персонажа")] private List<ItemsData> _baseItems;
        public List<ItemsData> BaseInventoryItems => _baseItems;
    }
}

