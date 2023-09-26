using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField, Header("������� ��������� ���������")] private BaseParamsData _baseParams = BaseParamsData.Empty;
    public BaseParamsData GetBaseParams => _baseParams;

    [SerializeField, Header("��������� ��������� ���������")] private List<BaseInventoryData> _baseItems;
    public List<BaseInventoryData> GetBaseInventoryItems => _baseItems;

}

[Serializable]
public struct BaseParamsData
{
    /// <summary>
    /// ��������, ������� ����� �������� ��������
    /// </summary>
    [Tooltip("��������, ������� ����� �������� ��������")]
    public float MaxHealth;

    /// <summary>
    /// �������� �����������
    /// </summary>
    [Tooltip("�������� �����������")]
    public float MoveSpeed;

    public static BaseParamsData Empty => new BaseParamsData()
    {
        MaxHealth = 10f,
        MoveSpeed = 1f
    };

}

[Serializable]
public struct BaseInventoryData
{
    /// <summary>
    /// ��������, ������� ����� �������� ��������
    /// </summary>
    [Tooltip("�������� ��������")]
    public ItemInfo itemInfo;
    [Tooltip("��� ����������")]
    public int count;

}