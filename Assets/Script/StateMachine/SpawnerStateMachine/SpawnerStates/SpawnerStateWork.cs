using PoketZone;
using Script.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.StateMachine
{
    [CreateAssetMenu(fileName = "SpawnerStateWork", menuName = "State/SpawnerState/SpawnerStateWork")]
    public class SpawnerStateWork: SpawnerState
    {
        private int _spawned = 0;
        private float _timeAfterLastSpawn = 0;
        private List<Enemy> _enemies = new();

        public override async void Update()
        {
            if (CurrentConfig == null) return;

            if (_spawned >= Count)
            {
                CurrentConfig = null;
                await Task.Delay(TimeSpan.FromSeconds(CurrentConfig.Delay));
                NeedTransition = true;
                return;
            }

            _timeAfterLastSpawn += Time.deltaTime;

            if (_timeAfterLastSpawn >= CurrentConfig.Delay)
            {
                _enemies.Add(Manager.InstantiateEnemy());
                _spawned++;
                _timeAfterLastSpawn = 0;
            }
        }

        public override void Exit()
        {
            base.Exit();
            _spawned = 0;
            CurrentIndes++;
            if (CurrentIndes == Count && _enemies.Count == 0)
            {
                EditorApplication.isPaused = true;
                Debug.Log("Игрок победил!!");
            }
            
        }
    }
}
