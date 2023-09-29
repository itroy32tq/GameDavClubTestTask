using Assets.Script.Interfaces;
using Assets.StorageService;
using Script.Configurations;
using UnityEngine;

namespace Assets.Script.Controllers
{
    public class StorageManager: MonoBehaviour
    {
        [SerializeField] PlayerConfiguration _playerConfiguration;
        private IStorageService _storageService;
        private const string key = "playerConfiguration";

        private void Start()
        {
            _storageService = new JsonToFileStorageService();
           // _storageService.Save(key, _playerConfiguration);
        }

        public void SaveData(object data)
        {
            _storageService.Save(key, data);
        }
    }
}
