using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

[Serializable]
public struct FilingInventoryData
{
    /// <summary>
    /// ��������, ������� ����� �������� ��������
    /// </summary>
    [Tooltip("�������� ��������")]
    public ItemInfo itemInfo;
    [Tooltip("��� ����������")]
    public int count;

}