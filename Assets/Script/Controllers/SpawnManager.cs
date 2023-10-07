using Assets.Script.Controllers;
using Assets.Script.StateMachine;
using Script.Configurations;
using Script.StateMachine;
using Script.Structs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace PoketZone
{
    public class SpawnManager: MonoBehaviour
    {
        [SerializeField] private List<GameManagerConfig> _configs;
        [SerializeField] private PlayerController _player;
        [SerializeField] private float _spawnRadius = 3;
        [SerializeField] private StorageManager _storageManager;
        [SerializeField] private ItemsManager _itemsManager;
        [SerializeField] private int _currentIndex = 0;

        private GameManagerConfig _currentConfig;
        private List<Enemy> _enemies = new();

        public SpawnerStateMachine<SpawnManager> SSM { get; private set; }

        public Action OnRespawnEnemyEvent;
        public List<GameManagerConfig> Configs => _configs;
        public GameManagerConfig CurrentConfig { get => _currentConfig; set => _currentConfig = value; }
        public int CurrentIndex { get => _currentIndex; set => _currentIndex = value; }

        private void Start()
        {
            SSM = new SpawnerStateMachine<SpawnManager>(new SpawnerStateIdle(this), new SpawnerStateWork(this));
            SSM.SwitchState<SpawnerStateIdle>();
        }

        public Enemy InstantiateEnemy()
        {
            var randWithinCircle = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * _spawnRadius;
            Enemy enemy = Instantiate(_currentConfig.Tamplate, randWithinCircle, Quaternion.identity).GetComponent<Enemy>();
            enemy.OnUnitDiesEvent += _itemsManager.OnUnitDies;
            enemy.name = _enemies.Count.ToString();
            enemy.Init(_player);
            return enemy;
        }
        private void OnDisable()
        {
            foreach(var enemy in _enemies)
                enemy.OnUnitDiesEvent -= _itemsManager.OnUnitDies;
        }
    }
}
