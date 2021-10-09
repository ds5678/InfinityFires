using AlternativeActionUtilities;
using MelonLoader;
using System;

namespace InfinityFires
{
	[RegisterTypeInIl2Cpp]
	internal class AlternativeFireAction : AlternativeAction
	{
		public AlternativeFireAction(IntPtr intPtr) : base(intPtr) { }

		public override void ExecuteSecondary()
		{
			Fire fire = this.gameObject.GetComponent<Fire>();
			
			if (fire) fire.m_IsPerpetual = !fire.m_IsPerpetual;
			else
			{
				fire = this.gameObject.GetComponentInChildren<Fire>();
				if (fire) fire.m_IsPerpetual = !fire.m_IsPerpetual;
				else MelonLoader.MelonLogger.Error("Attached object doesn't have a fire component.");
			}
		}

		public override void ExecuteTertiary()
		{
			Fire fire = this.gameObject.GetComponent<Fire>();

			if (fire is null) fire = this.gameObject.GetComponentInChildren<Fire>();
			
			if (fire is null) MelonLoader.MelonLogger.Error("Attached object doesn't have a fire component.");
			else
			{
				if (fire.IsBurning())
				{
					float overTheMax = fire.m_MaxOnTODSeconds + 3600 - GetMaxFireDuration();
					if (overTheMax <= 0) fire.m_MaxOnTODSeconds += 3600;
					else
					{
						fire.m_MaxOnTODSeconds = GetMaxFireDuration();
						fire.m_ElapsedOnTODSeconds = System.Math.Max(0, fire.m_ElapsedOnTODSeconds - overTheMax);
					}
				}
			}
		}

		private static float GetMaxFireDuration() => GameManager.GetFireManagerComponent().m_MaxDurationHoursOfFire * 3600;
	}
}
