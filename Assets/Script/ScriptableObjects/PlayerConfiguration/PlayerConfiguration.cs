using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerConfiguration", menuName = "Configurations/PlayerConfiguration")]
public class PlayerConfiguration : ScriptableObject
{
    [SerializeField, Header("Базовые параметры персонажа")] private BaseParamsData _baseParams = BaseParamsData.Empty;
    public BaseParamsData GetBaseParams => _baseParams;

    [SerializeField, Header("Начальный инвентарь персонажа")] private List<BaseInventoryData> _baseItems;
    public List<BaseInventoryData> GetBaseInventoryItems => _baseItems;

}

[Serializable]
public struct BaseParamsData
{
    /// <summary>
    /// Здоровье, сколько урона выдержит персонаж
    /// </summary>
    [Tooltip("Здоровье, сколько урона выдержит персонаж")]
    public float MaxHealth;

    /// <summary>
    /// Скорость перемещения
    /// </summary>
    [Tooltip("Скорость перемещения")]
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
    /// Здоровье, сколько урона выдержит персонаж
    /// </summary>
    [Tooltip("описание предмета")]
    public ItemInfo itemInfo;
    [Tooltip("его количество")]
    public int count;

}