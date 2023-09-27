using Assets.Script.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Configurations
{

    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField, Header("Базовые параметры персонажа")] private BaseParamsData _baseParams = BaseParamsData.Empty;
        public BaseParamsData GetBaseParams => _baseParams;

        [SerializeField, Header("Начальный инвентарь персонажа")] private List<FilingInventoryData> _baseItems;
        public List<FilingInventoryData> BaseInventoryItems => _baseItems;
    }

}

