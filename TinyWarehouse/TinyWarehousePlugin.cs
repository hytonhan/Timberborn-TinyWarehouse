using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Timberborn.BlockObjectTools;
using Timberborn.BlockSystem;
using Timberborn.FactionSystemGame;
using TimberbornAPI;
using TimberbornAPI.Common;

namespace Hytone.TinyWarehouse
{
    [BepInPlugin("hytone.plugins.tinywarehouse", "TinyWarehouse", "1.0.0")]
    [BepInDependency("com.timberapi.timberapi")]
    [HarmonyPatch]
    public class TinyWarehousePlugin : BaseUnityPlugin
    {
        internal static ManualLogSource Log;

        public void Awake()
        {
            Log = Logger;
            new Harmony("hytone.plugins.tinywarehouse").PatchAll();

            //TimberAPI.Localization.AddLabel("TinyWarehouseName", "Tiny Warehouse");
            //TimberAPI.Localization.AddLabel("TinyWarehouseDescription", "Stores a tiny amount of goods.");
            //TimberAPI.Localization.AddLabel("TinyWarehouseFlavor", "Effective space usage is essential for survival.");

            //var loc = new string[] { "storageassets" };
            //TimberAPI.AssetRegistry.AddSceneAssets("TinyWarehouse", SceneEntryPoint.Global, loc);
            TimberAPI.AssetRegistry.AddSceneAssets("TinyWarehouse", SceneEntryPoint.Global);

            //TimberAPI.DependencyRegistry.AddConfiguratorBeforeLoad(new TextureConfigurator(), SceneEntryPoint.Global);

            Log.LogInfo("Loaded TinyWarehouse.");
        }
    }

    //[HarmonyPatch(typeof(BlockObjectToolGroupFactory), nameof(BlockObjectToolGroupFactory.Create))]
    //public static class BlockObjectToolGroupFactoryPatch
    //{
    //    /// <summary>
    //    /// TimberAPI adds the buildings for every faction. This removes other faction's tiny
    //    /// warehouses from other factions
    //    /// </summary>
    //    /// <param name="blockObjects"></param>
    //    public static void Prefix(ref IEnumerable<PlaceableBlockObject> blockObjects)
    //    {
    //        var factionService = TimberAPI.DependencyContainer.GetInstance<FactionService>();

    //        foreach (var item in blockObjects.Reverse())
    //        {
    //            if (item.name.Contains("TinyWarehouse"))
    //            {
    //                var currFaction = factionService.Current.Id;
    //                var factionFromItem = item.name.Split(".").Last();

    //                if (factionFromItem != currFaction)
    //                {
    //                    blockObjects = blockObjects.ToList().Where(x => x.name != item.name);
    //                }
    //            }
    //        }
    //    }
    //}
}
