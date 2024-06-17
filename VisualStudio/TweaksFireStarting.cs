﻿namespace UniversalTweaks;

internal class TweaksFireStarting
{
    [HarmonyPatch(typeof(Panel_FeedFire), nameof(Panel_FeedFire.RefreshFuelSources))]
    private static class RemoveUnresearchedBooksFromFeedingFires
    {
        private static void Postfix(Panel_FeedFire __instance)
        {
            for (int i = 0; i < __instance.m_FuelSourcesList.Count; i++)
            {
                if (__instance.m_FuelSourcesList[i].m_ResearchItem != null && !__instance.m_FuelSourcesList[i].m_ResearchItem.IsResearchComplete())
                {
                    __instance.m_FuelSourcesList.RemoveAt(i);
                }
            }

            // The following below works, as the object reference is no longer thrown if there is only unresearched books in the players inventory.
            // However, the 'None' doesn't show up in the list - it's just blank. Will need to fix in another update as it's not a game breaking issue.
            __instance.m_FuelScrollList.CleanUp();

            if (__instance.m_FuelSourcesList.Count > 0)
            {                
                __instance.m_FuelScrollList.CreateList(__instance.m_FuelSourcesList.Count);
            }
        }
    }

    [HarmonyPatch(typeof(Panel_FireStart), nameof(Panel_FireStart.RefreshList))]
    private static class RemoveUnresearchedBooksFromFireStarting
    {
        private static void Postfix(Panel_FireStart __instance)
        {
            for (int i = 0; i < __instance.m_FuelList.Count; i++)
            {
                if (__instance.m_FuelList[i].m_ResearchItem != null && !__instance.m_FuelList[i].m_ResearchItem.IsResearchComplete())
                {
                    __instance.m_FuelList.RemoveAt(i);
                }
            }
        }
    }
}