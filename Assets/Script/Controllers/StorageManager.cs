using Assets.Script.Interfaces;
using Assets.StorageService;
using PoketZone;
using Script.Configurations;
using Script.Structs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Controllers
{
    public class StorageManager: MonoBehaviour
    {
        [SerializeField] Button _loadConfigurationButton;
        [SerializeField] PlayerController _player;
        [SerializeField] SpawnManager _spawnManager;
        private IStorageService _storageService;
        private const string key = "playerConfiguration";

        private void Start()
        {
            _spawnManager.OnRespawnEnemyEvent += OnRespawnEnemy;
            _loadConfigurationButton.onClick.AddListener(LoadDataButtonClick);
            _storageService = new JsonToFileStorageService();
        }

        private void LoadDataButtonClick()
        {
            _storageService.Load<PlayerConfiguration>(key, data =>
            {
                _player.Init(data);
            });
        }

        public void OnRespawnEnemy()
        {
            _storageService.Save(key, GetCurrentPlayerConfig());
        }

        private object GetCurrentPlayerConfig()
        {
            PlayerConfiguration newConfig = ScriptableObject.CreateInstance<PlayerConfiguration>();
            newConfig.BaseParams = new BaseParamsData()
            {
                MaxHealth = _player.Health,
                MoveSpeed = _player.Speed,
                InventoryCapacity = _player.InventoryModel.Capacity
            };
            newConfig.Location = _player.transform.position;
            newConfig.CurrentWeaponId = _player.CurrentWeapon.Id;
            newConfig.InventoryItems = GetInventoryData();
            return newConfig;
        }
        private List<ItemsData> GetInventoryData()
        {
            List<ItemsData> result = new List<ItemsData>();
            foreach (var item in _player.InventoryModel.GetAllItems())
            {
                var v = result.FirstOrDefault(d => d.ItemInfoId == item.Info.Id);
                if (result.Contains(v)) v.Count += item.State.Amount;
                else result.Add(new ItemsData(item.Info.Id, item.State.Amount));
            }
            return result;
        }
    }
}
