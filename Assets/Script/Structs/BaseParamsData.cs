using System;
using UnityEngine;

namespace Script.Structs
{
    [Serializable]
    public struct BaseParamsData
    {
        [Tooltip("Здоровье, сколько урона выдержит персонаж")]
        public float MaxHealth;
        [Tooltip("Скорость перемещения")]
        public float MoveSpeed;
        [Tooltip("Емкость Инвентаря")]
        public int InventoryCapacity;
        public static BaseParamsData Empty => new()
        {
            MaxHealth = 10f,
            MoveSpeed = 1f,
            InventoryCapacity = 5
        };
    }
}
