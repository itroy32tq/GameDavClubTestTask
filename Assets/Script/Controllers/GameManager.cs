using Assets.Script.Controllers;
using Script.Configurations;
using Script.ItemSpace;
using Script.Structs;
using Script.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] private List<GameManagerConfig> _configs;
        [SerializeField] private PlayerController _player;
        [SerializeField] private ItemController _itenOnMapPrefab;
        [SerializeField] private float _spawnRadius = 3;
        [SerializeField] private float _dropRadius = 1.5f;
        [SerializeField] private StorageManager _storageManager;
        private GameManagerConfig _currentConfig;
        private int _currentIndex = 0;
        private float _timeAfterLastSpawn;
        private int _spawned;
        private List<ItemInfo> _assetsList = new();
        
        private List<Enemy> _enemies = new();

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
            LoadItemAsset();
        }
        private void Start () 
        {
            SetConfig(_currentIndex);
        }

        private void LoadItemAsset()
        {
            ItemInfo[] assets = Resources.LoadAll<ItemInfo>("Item");

            foreach (var asset in assets)
            {
                _assetsList.Add(asset);
            }
        }

        public ItemInfo GetAssetForId(string id)
        {
            return _assetsList.Find(asset => asset.Id == id);
        }
        private ItemInfo GetRandomAsset()
        {
            var index = Random.Range(0, _assetsList.Count);
            return _assetsList[index];
        }

        public void OnCreateItemOnMap(object sender, Item item)
        {
            //todo
            var unit = sender as Unit;
            if (unit == null) return;
            var circle = Random.insideUnitCircle * _dropRadius;
            var pos = (Vector2)unit.transform.position + circle;
            var itemController = Instantiate(_itenOnMapPrefab, pos, Quaternion.identity);
            itemController.Init(item);
        }

        private void SetConfig(int index)
        { 
            _currentConfig = _configs[index];
        }

        private void Update()
        {
            if (_currentConfig == null) return;

            if (_enemies.Count >= _currentConfig.Count)
            {
                StartCoroutine(DelayForRespawn(_currentConfig.DelayForRespawn));
                return;
            } 

            _timeAfterLastSpawn += Time.deltaTime;

            if (_timeAfterLastSpawn >= _currentConfig.Delay)
            {
                _enemies.Add(InstantiateEnemy());
                _spawned++;
                _timeAfterLastSpawn = 0;
            }
        }
        private IEnumerator DelayForRespawn(float delay)
        {
            _storageManager.SaveData(GetCurrentPlayerConfig());
            yield return new WaitForSeconds(delay);
            _storageManager.SaveData(GetCurrentPlayerConfig());
            SetConfig(_currentIndex + 1);

        }

        private object GetCurrentPlayerConfig()
        {
            PlayerConfiguration p = ScriptableObject.CreateInstance<PlayerConfiguration>()
            {
                new BaseParamsData()
                {
                    MaxHealth = _player.Health,
                    MoveSpeed = _player.Speed,
                    InventoryCapacity = _player.InventoryModel.Capacity
                };
                _player.transform.position;
                _player.CurrentWeapon.Id;
                GetInventoryData();
            }
        }

        private List<ItemsData> GetInventoryData()
        {
            List<ItemsData> result = new List<ItemsData>();
            foreach (var item in _player.InventoryModel.GetAllItems())
            {
                result.Add(new ItemsData() { ItemInfoId = item.Info.Id, Count = item.State.Amount });
            }
            return result;
        }

        private Enemy InstantiateEnemy()
        {
            var randWithinCircle = (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
            Enemy enemy = Instantiate(_currentConfig.Tamplate, randWithinCircle, Quaternion.identity).GetComponent<Enemy>();
            enemy.OnUnitDiesEvent += OnUnitDies;
            enemy.name = _enemies.Count.ToString();
            enemy.Init(_player);
            return enemy;
        }

        private void OnUnitDies(Unit unit)
        {
            OnCreateItemOnMap(unit, new Item(GetRandomAsset()));
        }
    }
}
