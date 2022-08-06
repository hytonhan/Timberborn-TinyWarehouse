using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using TimberbornAPI;
using TimberbornAPI.Common;

namespace Hytone.TinyWarehouse
{
    [BepInPlugin("hytone.plugins.tinywarehouse", "TinyWarehouse", "1.1.0")]
    [BepInDependency("com.timberapi.timberapi")]
    [HarmonyPatch]
    public class TinyWarehousePlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;

        public void Awake()
        {
            Log = Logger;
            new Harmony("hytone.plugins.tinywarehouse").PatchAll();

            TimberAPI.AssetRegistry.AddSceneAssets("TinyWarehouse", SceneEntryPoint.Global);

            Log.LogInfo("Loaded TinyWarehouse.");
        }
    }
}
