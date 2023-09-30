using Assets.Script.Controllers;
using Script.Configurations;
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

        public Action OnRespawnEnemyEvent;

        private void Start()
        {
            SetConfig(_currentIndex);
        }

        private void SetConfig(int index)
        {
            _currentConfig = _configs[index];
        }
        private void Update()
        {
            if (_currentConfig == null) return;

            if (_spawned >= _configs.Count)
            {
                StartCoroutine(DelayForRespawn(_currentConfig.DelayForRespawn));
                _spawned = 0;
                _currentConfig = null;
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
            
            yield return new WaitForSeconds(delay);
            OnRespawnEnemyEvent?.Invoke();
            _currentIndex++;
            if (_currentIndex > _configs.Count)
            {
                EditorApplication.isPaused = true;
                _currentIndex = 0;
                yield break;
            }
            Debug.Log("Respawn!!!!!!!");
        }
       
        private Enemy InstantiateEnemy()
        {
            var randWithinCircle = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * _spawnRadius;
            Enemy enemy = Instantiate(_currentConfig.Tamplate, randWithinCircle, Quaternion.identity).GetComponent<Enemy>();
            enemy.OnUnitDiesEvent += _itemsManager.OnUnitDies;
            enemy.name = _enemies.Count.ToString();
            enemy.Init(_player);
            return enemy;
        }
    }
}
