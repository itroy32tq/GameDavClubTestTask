using UnityEngine;

namespace Assets.Script.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameManagerConfig", menuName = "Configurations/GameManagerConfig")]
    public class GameManagerConfig: ScriptableObject
    {
        [SerializeField] private GameObject _tamplate;
        [SerializeField] private float _delay;
        [SerializeField] int _count;

        public GameObject Tamplate => _tamplate;
        public float Delay => _delay;
        public int Count => _count;
        public Transform[] SpawnPoint { get; set; } 
    }
}
