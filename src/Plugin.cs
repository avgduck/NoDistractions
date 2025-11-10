using BepInEx;
using BepInEx.Logging;

namespace NoStageEffects;

[BepInPlugin("avgduck.plugins.llb.nostageeffects", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        HarmonyPatches.PatchAll();
    }
}