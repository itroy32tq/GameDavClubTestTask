using Assets.Script.Controllers;
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

        private GameManagerConfig _currentConfig;
        private int _currentIndex = 0;
        private float _timeAfterLastSpawn;
        private int _spawned = 0;
        private List<Enemy> _enemies = new();

        protected SpawnerStateMachine SSM { get; private set; }

        public Action OnRespawnEnemyEvent;
        public List<GameManagerConfig> Configs => _configs;
        public GameManagerConfig CurrentConfig { get => _currentConfig; set => _currentConfig = value; }

        private void Start()
        {
            SSM = new SpawnerStateMachine();
        }

        private void Update()
        {
            if (SSM != null)
            {
                var state = SSM.CurrentState as SpawnerState;
                state.Manager = this;
                SSM.CurrentState.Update();

                if (SSM.CurrentState.NeedTransition)
                {
                    SSM.SetCurrentState(SSM.CurrentState.TargetState);
                }
            }
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
