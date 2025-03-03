﻿using UniversalTweaks.Properties;

namespace UniversalTweaks;

internal class TweaksSnowShelter
{
    [HarmonyPatch(typeof(SnowShelterManager), nameof(SnowShelterManager.GetPlayerOccupiedSnowShelter))]
    private static class SnowShelterDecayRate
    {
        private static void Postfix(ref SnowShelter __result)
        {
            __result.m_DailyDecayHP = Settings.Instance.CheatingTweaks ? Settings.Instance.SnowShelterDailyDecayRate : 100;
        }
    }
}