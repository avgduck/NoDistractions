using BepInEx;
using BepInEx.Logging;

namespace NoStageEffects;

[BepInPlugin(GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency("fr.glomzubuk.plugins.llb.llbml", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("no.mrgentle.plugins.llb.modmenu", BepInDependency.DependencyFlags.SoftDependency)]
public class Plugin : BaseUnityPlugin
{
    public const string GUID = "avgduck.plugins.llb.nostageeffects";
    public static Plugin Instance { get; private set; }
    internal static ManualLogSource LogGlobal { get; private set; }
    private void Awake()
    {
        Instance = this;
        LogGlobal = this.Logger;
        
        Configs.Init();
        HarmonyPatches.PatchAll();
    }
}