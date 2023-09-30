using Assets.Script.Interfaces;
using Assets.StorageService;
using PoketZone;
using Script.Configurations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.Controllers
{
    public class StorageManager: MonoBehaviour
    {
        [SerializeField] Button _loadConfigurationButton;
        [SerializeField] PlayerController _player;
        private IStorageService _storageService;
        private const string key = "playerConfiguration";

        private void Start()
        {
            _loadConfigurationButton.onClick.AddListener(LoadDataButtonClick);
            _storageService = new JsonToFileStorageService();
        }

        private void LoadDataButtonClick()
        {
            _storageService.Load<PlayerConfiguration>(key, data =>
            {
                _player.Init(data);
            });
        }

        public void SaveData(object data)
        {
            _storageService.Save(key, data);
        }
    }
}
