using System;
using Verse;
using RimWorld;

namespace ETH_Smokeleaf_Expanded
{
    /*[StaticConstructorOnStartup]
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
    }*/
    public class DamageWorker_HediffMelee : DamageWorker_Cut
    {
        public override DamageResult Apply(DamageInfo dinfo, Thing victim)
        {
            float addHediffChance = 1f;
            HediffDef hedifftoAdd = null;
            var severity = .5f;
            ModExtension_DamageWorkerOptions properties = dinfo.Def.GetModExtension<ModExtension_DamageWorkerOptions>();
            if (properties != null)
            {
                addHediffChance = properties.addHediffChance;
                hedifftoAdd = properties.hediffToAdd;
                severity = properties.severity;
            }

            if (victim is Pawn pawn)
            {
                Hediff hediff = HediffMaker.MakeHediff(hedifftoAdd, pawn, null);
                hediff.Severity = severity;
                pawn.health.AddHediff(hedifftoAdd,null, new DamageInfo?(dinfo), null);
            }
            

            DamageResult damageResult = base.Apply(dinfo, victim);

            /*if (pawn != null && hedifftoAdd != null && !damageResult.deflected && Rand.Chance(addHediffChance))
            {
                Hediff hediff;
                float severity = properties.severity;
                if (properties.hediffMitigationStat != null)
                {
                    float statValue = pawn.GetStatValue(properties.hediffMitigationStat);
                    if (properties.hediffMitigationStat.defaultBaseValue > 0f)
                    {
                        severity *= statValue;
                    }
                    else
                    {
                        severity *= (1 - statValue);
                    }
                }

                if (severity > 0f)
                {
                    if (options.hediffSeverityVariesByBodySize)
                    {
                        severity /= pawn.BodySize;
                    }

                    if (options.hediffAppliedToWholeBody)
                    {

                    }
                    else
                    {
                        foreach (BodyPartRecord bodyPart in damageResult.parts)
                        {
                            hediff = HediffMaker.MakeHediff(hediffDef, pawn, bodyPart);
                            hediff.Severity = severity;
                            pawn.health.AddHediff(hediff, bodyPart, dinfo);
                        }
                    }
                }
            }*/

            return damageResult;
        }
    }
}
