using Timberborn.AssetSystem;
using Timberborn.SingletonSystem;
using TimberbornAPI;
using TimberbornAPI.AssetLoaderSystem.AssetSystem;
using UnityEngine;

namespace Hytone.TinyWarehouse
{
    public class TinyWarehouse : ILoadableSingleton
    {
        private readonly IAssetLoader _assetLoader;
        private readonly IResourceAssetLoader _resourceAssetLoader;

        public TinyWarehouse(IAssetLoader assetLoader, IResourceAssetLoader resourceAssetLoader)
        {
            _assetLoader = assetLoader;
            _resourceAssetLoader = resourceAssetLoader;
        }

        public void Load()
        {
            var platformModel = _resourceAssetLoader.Load<GameObject>("Buildings/Paths/Platform/Platform.Full.Folktails");
            var shader = platformModel.GetComponent<MeshRenderer>().materials[0].shader;

            AddBuilding("TinyWarehouse.Folktails", shader);
            AddBuilding("TinyWarehouse.IronTeeth", shader);

            TinyWarehousePlugin.Log.LogInfo($"Loaded TinyWarehouse!");
        }

        private void AddBuilding(string name, Shader shader)
        {
            var building = _assetLoader.Load<GameObject>("TinyWarehouse", $"boxstorage.bundle/{name}");

            FixMaterialShader(building, shader);
            TimberAPI.CustomObjectRegistry.AddGameObject(building);
        }

        private static void FixMaterialShader(GameObject obj, Shader shader)
        {
            var meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                foreach (var mat in meshRenderer.materials)
                {
                    mat.shader = shader;
                }
            }

            foreach (Transform child in obj.transform)
            {
                if (child.gameObject)
                {
                    FixMaterialShader(child.gameObject, shader);
                }
            }
        }
    }
}
