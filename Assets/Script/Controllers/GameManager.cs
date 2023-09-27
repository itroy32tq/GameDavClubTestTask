using Script.Configurations;
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

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
        }
        private void Start () 
        {
            _player.InventoryModel.OnInventoryItemRemoveEvent += OnCreateItemOnMap;
            SetStartConfig(_currentIndex);
        }

        private void OnCreateItemOnMap(object sender, string id, int amount)
        {
            var itemController = Instantiate(_itenOnMapPrefab, (_player.transform.position - new Vector3(-5, 0, 0)), Quaternion.identity).GetComponent<ItemController>();
            //itemController.Init();

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
