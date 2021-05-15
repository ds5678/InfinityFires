using ModComponentAPI;
using System;

namespace InfinityFires
{
	internal class AlternativeFireAction : AlternativeAction
	{
		public AlternativeFireAction(IntPtr intPtr) : base(intPtr) { }

		public override void Execute()
		{
			Fire fire = this.gameObject.GetComponent<Fire>();

			if (fire) fire.m_IsPerpetual = !fire.m_IsPerpetual;
			else
			{
				fire = this.gameObject.GetComponentInChildren<Fire>();
				if (fire) fire.m_IsPerpetual = !fire.m_IsPerpetual;
				else MelonLoader.MelonLogger.LogError("Attached object doesn't have a fire component.");
			}
		}
	}
}
