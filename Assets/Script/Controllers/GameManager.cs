using Script.Configurations;
using Script.ItemSpace;
using Script.Structs;
using Script.UI;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] private List<GameManagerConfig> _configs;
        [SerializeField] private PlayerController _player;
        [SerializeField] private ItemController _itenOnMapPrefab;
        private GameManagerConfig _currentConfig;
        private int _currentIndex = 0;
        private float _timeAfterLastSpawn;
        private int _spawned;
        private List<ItemInfo> _assetsList = new();
        private float _radius = 3;
        private List<Enemy> _enemies = new();

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
            LoadItemAsset();
        }
        private void Start () 
        {
            SetStartConfig(_currentIndex);
        }

        private void LoadItemAsset()
        {
            ItemInfo[] assets = Resources.LoadAll<ItemInfo>("Item");

            foreach (var asset in assets)
            {
                _assetsList.Add(asset);
            }
        }

        private ItemInfo GetAssetForId(string id)
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

            var pos = (Vector2)unit.transform.position + Random.insideUnitCircle*2;
            var itemController = Instantiate(_itenOnMapPrefab, pos, Quaternion.identity);
            itemController.Init(item);
        }

        private void SetStartConfig(int index)
        { 
            _currentConfig = _configs[index];
        }

        private void Update()
        {
            if (_currentConfig == null) return;

            if (_enemies.Count >= _currentConfig.Count) return;

            _timeAfterLastSpawn += Time.deltaTime;

            if (_timeAfterLastSpawn >= _currentConfig.Delay)
            {
                _enemies.Add(InstantiateEnemy());
                _spawned++;
                _timeAfterLastSpawn = 0;
            }
        }

        private Enemy InstantiateEnemy()
        {

            var randWithinCircle = (Vector2)transform.position + Random.insideUnitCircle * _radius;
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
