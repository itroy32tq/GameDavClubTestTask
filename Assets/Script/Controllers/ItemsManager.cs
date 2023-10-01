using Assets.Script.Controllers;
using Script.Configurations;
using Script.ItemSpace;
using Script.Structs;
using Script.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PoketZone
{
    public class ItemsManager : MonoBehaviour 
    {
        [SerializeField] private PlayerController _player;
        [SerializeField] private ItemController _itenOnMapPrefab;
        [SerializeField, Range(1f, 5f)] private float _dropRadius = 1.5f;
        private List<ItemInfo> _assetsList = new();

        public static ItemsManager Instance;

        private void Awake()
        {
            Instance = this;
            LoadItemAsset();
        }
        private void LoadItemAsset()
        {
            ItemInfo[] assets = Resources.LoadAll<ItemInfo>("Item");

            foreach (var asset in assets)
            {
                _assetsList.Add(asset);
            }
        }
        public ItemInfo GetAssetForId(string id)
        {
            return _assetsList.Find(asset => asset.Id == id);
        }
        private ItemInfo GetRandomAsset()
        {
            var index = Random.Range(0, _assetsList.Count);
            return _assetsList[index];
        }
        public void OnCreateItemOnMap(object sender, Item item)
        {
            //todo
            var unit = sender as Unit;
            if (unit == null) return;
            var circle = Random.insideUnitCircle + new Vector2(_dropRadius, 0);
            var pos = (Vector2)unit.transform.position + circle;
            var itemController = Instantiate(_itenOnMapPrefab, pos, Quaternion.identity);
            itemController.Init(item);
        }
        public void OnUnitDies(Unit unit)
        {
            OnCreateItemOnMap(unit, new Item(GetRandomAsset()));
        }
    }
}
