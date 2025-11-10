using BepInEx;
using BepInEx.Logging;

namespace NoStageEffects;

[BepInPlugin("avgduck.plugins.llb.nostageeffects", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource LogGlobal { get; private set; }
    private void Awake()
    {
        LogGlobal = this.Logger;
        HarmonyPatches.PatchAll();
    }
}