using System;
using Verse;
using RimWorld;

namespace ETH_Smokeleaf_Expanded
{
    [StaticConstructorOnStartup]
    // ReSharper disable once InconsistentNaming
    public class Projectile_Smokeleaf : Projectile_Explosive
    {
        public ModExtension_ProjectileSmokeleaf Props => def.GetModExtension<ModExtension_ProjectileSmokeleaf>();

        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            base.Impact(hitThing, blockedByShield);
            if (Props == null || hitThing is not Pawn hitPawn) return;
            var rand = Rand.Value;
            if (rand <= Props.addHediffChance)
            {
                Messages.Message(
                    "ETH_Projectile_Smokeleaf_SuccessMessage".Translate(this.launcher.Label, hitPawn.Label),
                    MessageTypeDefOf.NeutralEvent);
                var pawnIsHigh = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(Props.hediffToAdd);
                var randomSeverity = Rand.Range(0.15f, 0.30f);
                if (pawnIsHigh != null)
                {
                    pawnIsHigh.Severity += randomSeverity;
                }
                else
                {
                    var hediff = HediffMaker.MakeHediff(Props.hediffToAdd, hitPawn);
                    hediff.Severity = randomSeverity;
                    hitPawn.health?.AddHediff(hediff);
                }
            }
            else
            {
                MoteMaker.ThrowText(hitThing.PositionHeld.ToVector3(), hitThing.MapHeld, "ETH_Projectile_Smokeleaf_FailureMote".Translate(Props.addHediffChance), 12f);
            }
        }
    }
    
}