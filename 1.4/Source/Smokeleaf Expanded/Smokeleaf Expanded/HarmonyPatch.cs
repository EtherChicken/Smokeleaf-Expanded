using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace ETH_Smokeleaf_Expanded;

[StaticConstructorOnStartup]
internal static class DoPatching
{
    static DoPatching()
    {
        new Harmony("Ether.SmokeleafExpanded.").PatchAll();
    }
}

[HarmonyPatch(typeof(Toils_Ingest), "FinalizeIngest")]
public static class IngestPatch
{

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        var codes = new List<CodeInstruction>(instructions);
        for (var i = 0; i < codes.Count; i++)
        {
            if (codes[i].opcode == OpCodes.Ret)
            {
                
            }
        }
    }

    /*public static void Postfix(TargetIndex ingestibleInd)
    {
        ThingDef def = ingestibleInd.ChangeType<ThingDef>();

        

        List<CompProperties> compslist = def.comps;
        bool reusable = def.HasComp(typeof(CompProperties_Reusable));

        foreach (var VARIABLE in compslist)
        {
            
        }
        if (reusable)
        {
            
        }
    }*/
}