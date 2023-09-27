using Assets.Script.ScriptableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.ScriptableObjects
{

    [CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
    public class PlayerConfiguration : ScriptableObject
    {
        [SerializeField, Header("������� ��������� ���������")] private BaseParamsData _baseParams = BaseParamsData.Empty;
        public BaseParamsData GetBaseParams => _baseParams;

        [SerializeField, Header("��������� ��������� ���������")] private List<FilingInventoryData> _baseItems;
        public List<FilingInventoryData> GetBaseInventoryItems => _baseItems;

    }

    [Serializable]
    public struct BaseParamsData
    {
        [Tooltip("��������, ������� ����� �������� ��������")]
        public float MaxHealth;

        [Tooltip("�������� �����������")]
        public float MoveSpeed;

        [Tooltip("������� ���������")]
        public int InventoryCapacity;

        public static BaseParamsData Empty => new BaseParamsData()
        {
            MaxHealth = 10f,
            MoveSpeed = 1f,
            InventoryCapacity = 5
        };

    }
}

