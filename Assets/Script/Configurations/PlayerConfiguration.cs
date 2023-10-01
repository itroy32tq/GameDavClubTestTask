using Script.ItemSpace;
using Script.Structs;
using System.Collections.Generic;
using UnityEngine;

namespace Script.Configurations
{
    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField, Header("������� ��������� ���������")] private BaseParamsData _baseParams = BaseParamsData.Empty;
        public BaseParamsData BaseParams { get => _baseParams; set => _baseParams = value; }

        [SerializeField, Header("�������������� ���������")] private Vector2 _location = Vector2.zero;
        public Vector2 Location { get => _location; set => _location = value; }

        [SerializeField, Header("������� ������ ���������")] private string _currentWeapon;
        public string CurrentWeaponId { get => _currentWeapon; set => _currentWeapon = value; }

        [SerializeField, Header("��������� ��������� ���������")] private List<ItemsData> _baseItems;
        public List<ItemsData> InventoryItems { get => _baseItems; set => _baseItems = value; }
    }
}

