using HarmonyLib;
using LLScreen;
using StageBackground;

namespace NoStageEffects;

public class PatchFreezeBackgrounds
{
    [HarmonyPatch(typeof(BG), nameof(BG.Update))]
    [HarmonyPrefix]
    private static void Update_Prefix()
    {
        BG.timeScale = 0f;
    }
        
    [HarmonyPatch(typeof(ScreenGameHud), nameof(ScreenGameHud.CShowSpeedChange), MethodType.Enumerator)]
    [HarmonyPrefix]
    private static void CShowSpeedChange_Prefix()
    {
        BG.timeScale = Plugin.Instance.GetBGTimeScale();
    }
        
    [HarmonyPatch(typeof(ScreenGameHud), nameof(ScreenGameHud.CShowSpeedChange), MethodType.Enumerator)]
    [HarmonyPostfix]
    private static void CShowSpeedChange_Postfix()
    {
        BG.timeScale = 0f;
    }
}