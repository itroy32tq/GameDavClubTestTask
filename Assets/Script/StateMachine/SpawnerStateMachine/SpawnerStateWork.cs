using Assets.Script.Interfaces;
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
    public class SpawnerStateWork : SpawnerState, ITickable
    {
        private int _spawned = 0;
        private float _timeAfterLastSpawn = 0;
        private readonly List<Enemy> _enemies = new();
        private float _delay;

        public SpawnerStateWork(SpawnManager initializer) : base(initializer)
        {

        }
        public async void Tick()
        {
            if (CurrentConfig == null) return;

            if (_spawned >= Count)
            {
                CurrentConfig = null;
                await Task.Delay(TimeSpan.FromSeconds(_delay));
                Initializer.SSM.SwitchState<SpawnerStateIdle>();
                return;
            }
            _timeAfterLastSpawn += Time.deltaTime;

            if (_timeAfterLastSpawn >= CurrentConfig.Delay)
            {
                _enemies.Add(Initializer.CreateUnit());
                _spawned++;
                _timeAfterLastSpawn = 0;
            }
        }
        public override void OnEnter()
        {
            base.OnEnter();
            _delay = CurrentConfig.Delay;
        }

        public override void OnExit()
        {
            base.OnExit();
            _spawned = 0;
            CurrentIndex++;
            if (CurrentIndex >= Configs.Count)
            {
                if (_enemies.Count == 0)
                {
                    EditorApplication.isPaused = true;
                    Debug.Log("Игрок победил!!");
                }

            }
        }
    }
}
