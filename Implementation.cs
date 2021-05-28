using Harmony;
using MelonLoader;
using UnityEngine;

namespace InfinityFires
{
	public static class BuildInfo
	{
		public const string Name = "InfinityFires"; // Name of the Mod.  (MUST BE SET)
		public const string Description = "A mod to make fires last forever."; // Description for the Mod.  (Set as null if none)
		public const string Author = "ds5678"; // Author of the Mod.  (MUST BE SET)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "1.1.0"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}
	public class Implementation : MelonMod
	{
		public override void OnApplicationStart()
		{
			Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");

			UnhollowerRuntimeLib.ClassInjector.RegisterTypeInIl2Cpp<AlternativeFireAction>();
		}
	}

	[HarmonyPatch(typeof(Fire), "Awake")]
	internal static class Fire_Awake
	{
		private static void Postfix(Fire __instance)
		{
			ModComponentUtils.ComponentUtils.GetOrCreateComponent<AlternativeFireAction>(__instance);
		}
	}

	[HarmonyPatch(typeof(WoodStove), "Awake")]
	internal static class WoodStove_Awake
	{
		private static void Postfix(Fire __instance)
		{
			ModComponentUtils.ComponentUtils.GetOrCreateComponent<AlternativeFireAction>(__instance);
		}
	}
}
