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
        [SerializeField] private GameObject _itenOnMapPrefab;
        private GameManagerConfig _currentConfig;
        private int _currentIndex = 0;
        private float _timeAfterLastSpawn;
        private int _spawned;
        private List<ItemInfo> _assetsList = new();

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

        public void OnCreateItemOnMap(object sender, UIItem uiItem)
        {
            var itemController = Instantiate(_itenOnMapPrefab, (_player.transform.position - new Vector3(-1, 0, 0)), Quaternion.identity).GetComponent<ItemController>();
            var inventoryItem = (UIInventoryItem)uiItem;
            var item = new Item(GetAssetForId(inventoryItem.ItemId));
            item.State = new ItemState(inventoryItem.Item.State.Amount, false, true);
            itemController.Init(item);
        }

        private void SetStartConfig(int index)
        { 
            _currentConfig = _configs[index];
        }
        private void Update()
        {
            if (_currentConfig == null) return;

            _timeAfterLastSpawn += Time.deltaTime;

            if (_timeAfterLastSpawn >= _currentConfig.Delay)
            { 
                
                
            }
        }
        private void InstantiateEnemy()
        { 
        
        }
    }
}
