using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Harmony;

namespace InfinityFires
{
    public class Implementation : MelonMod
    {
        public override void OnApplicationStart()
        {
            Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");

            UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<AlternativeFireAction>();
        }
    }

    [HarmonyPatch(typeof(Fire),"Awake")]
    internal static class Fire_Awake
    {
        private static void Postfix(Fire __instance)
        {
            ModComponentMapper.ComponentUtils.GetOrCreateComponent<AlternativeFireAction>(__instance);
        }
    }

    [HarmonyPatch(typeof(WoodStove), "Awake")]
    internal static class WoodStove_Awake
    {
        private static void Postfix(Fire __instance)
        {
            ModComponentMapper.ComponentUtils.GetOrCreateComponent<AlternativeFireAction>(__instance);
        }
    }
}
