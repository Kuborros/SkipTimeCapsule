using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace SkipTimeCapsule
{
    [BepInPlugin("com.kuborro.plugins.fp2.skipcapsules", "SkipCapsuleScene", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            var harmony = new Harmony("com.kuborro.plugins.fp2.playablespade");
            harmony.PatchAll(typeof(PatchFPEventSequence));
        }
    }

    class PatchFPEventSequence
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(FPEventSequence),"Start",MethodType.Normal)]
        static void PatchCapsuleSprite(FPEventSequence __instance)
        {
            if (__instance != null)
            {
                if (__instance.transform.parent.gameObject.name == "Event")
                {
                    __instance.currentEvent = 21;
                }
            }
        }
    }
}
