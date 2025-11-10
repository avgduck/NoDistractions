using HarmonyLib;
using LLScreen;
using StageBackground;

namespace NoStageEffects;

public static class HarmonyPatches
{
    public static void PatchAll()
    {
        Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        
        harmony.PatchAll(typeof(GamePause));
        harmony.PatchAll(typeof(ScreenEffects));

        if (Plugin.DEBUG_FREEZEBG)
        {
            harmony.PatchAll(typeof(PatchFreezeBackgrounds));
        }
        else
        {
            harmony.PatchAll(typeof(PatchKeepAnimations));
        }
    }

    private static class GamePause
    {
        [HarmonyPatch(typeof(OGONAGCFDPK), nameof(OGONAGCFDPK.PFDNCNGCEDB))]
        [HarmonyPostfix]
        private static void SetTimePause_Postfix(bool LHMJELLIJDP)
        {
            Plugin.Instance.IsGamePaused = LHMJELLIJDP;
        }
    }

    private static class ScreenEffects
    {
        [HarmonyPatch(typeof(BG), nameof(BG.SetState))]
        [HarmonyPrefix]
        private static bool SetState_Prefix(BGState state)
        {
            if (state == BGState.ECLIPSE || state == BGState.HEAVEN)
            {
                return false;
            }

            return true;
        }
        
        [HarmonyPatch(typeof(PostFXCircle), nameof(PostFXCircle.CStartWave), MethodType.Enumerator)]
        [HarmonyPrefix]
        private static void CStartWave_Prefix()
        {
            if (!Plugin.DEBUG_FREEZEBG) return;
            
            BG.timeScale = Plugin.Instance.GetBGTimeScale();
        }
        
        [HarmonyPatch(typeof(PostFXCircle), nameof(PostFXCircle.CStartWave), MethodType.Enumerator)]
        [HarmonyPostfix]
        private static void CStartWave_Postfix()
        {
            if (!Plugin.DEBUG_FREEZEBG) return;
            
            BG.timeScale = 0f;
        }
    }
}