using RimWorld;
using Verse;

namespace ETH_Smokeleaf_Expanded
{
    [StaticConstructorOnStartup]
    // ReSharper disable once InconsistentNaming
    public class ModExtension_DamageWorkerOptions : DefModExtension
    {
        public float addHediffChance = 1f;
        public HediffDef hediffToAdd;
        public float severity = .5f;
        // public StatDef hediffMitigationStat;
    }
}   