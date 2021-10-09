using HarmonyLib;
using MelonLoader;

namespace InfinityFires
{
	public static class BuildInfo
	{
		public const string Name = "InfinityFires"; // Name of the Mod.  (MUST BE SET)
		public const string Description = "A mod to make fires last forever."; // Description for the Mod.  (Set as null if none)
		public const string Author = "ds5678"; // Author of the Mod.  (MUST BE SET)
		public const string Company = null; // Company that made the Mod.  (Set as null if none)
		public const string Version = "1.2.0"; // Version of the Mod.  (MUST BE SET)
		public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
	}
	internal class Implementation : MelonMod
	{
	}

	[HarmonyPatch(typeof(Fire), "Awake")]
	internal static class Fire_Awake
	{
		private static void Postfix(Fire __instance)
		{
			var _ = __instance.GetComponent<AlternativeFireAction>() ?? __instance.gameObject.AddComponent<AlternativeFireAction>();
		}
	}

	[HarmonyPatch(typeof(WoodStove), "Awake")]
	internal static class WoodStove_Awake
	{
		private static void Postfix(Fire __instance)
		{
			var _ = __instance.GetComponent<AlternativeFireAction>() ?? __instance.gameObject.AddComponent<AlternativeFireAction>();
		}
	}
}
