using Assets.Script.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PoketZone
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] private List<GameManagerConfig> _configs;
        [SerializeField] private PlayerController _player;
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
            SetStartConfig(_currentIndex);
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
