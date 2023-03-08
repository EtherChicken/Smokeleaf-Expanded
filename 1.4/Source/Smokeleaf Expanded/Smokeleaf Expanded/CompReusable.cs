using System.Collections.Generic;
using RimWorld;
using Verse;

namespace ETH_Smokeleaf_Expanded;

public class CompReusable : ThingComp//, IVerbOwner
{
    public override void PostPostMake()
    {
        base.PostPostMake();
        remainingCharges = MaxCharges;
    }
    
    public override void PostExposeData()
    {
        base.PostExposeData();
        Scribe_Values.Look(ref remainingCharges, "remainingCharges", -999);
        //Scribe_Deep.Look(ref verbTracker, "verbTracker", this);
        if (Scribe.mode == LoadSaveMode.PostLoadInit && remainingCharges == -999)
        {
            remainingCharges = MaxCharges;
        }
    }

    public void UsedOnce()
    {
        ThingDef def = DefDatabase<ThingDef>.GetRandom();
        var hello = def.GetCompProperties<CompProperties_Reusable>();
        if (remainingCharges > 0)
        {
            remainingCharges--;
        }

        if (Props.destroyOnEmpty && remainingCharges == 0 && !parent.Destroyed)
        {
            parent.Destroy();
        }
    }
    private int remainingCharges;
    public CompProperties_Reusable Props => props as CompProperties_Reusable;
    public int RemainingCharges => remainingCharges;
    public int MaxCharges => Props.maxCharges;
    public bool CanBeUsed => remainingCharges > 0;
    
    
    /*public string UniqueVerbOwnerID()
    {
        throw new System.NotImplementedException();
    }
    public bool VerbsStillUsableBy(Pawn p)
    {
        throw new System.NotImplementedException();
    } 
    public Pawn Wearer => ReloadableUtility.WearerOf(this);
    private VerbTracker verbTracker;
    public VerbTracker VerbTracker
    {
        get
        {
            if (verbTracker == null)
            {
                verbTracker = new VerbTracker(this);
            }
    
            return verbTracker;
        }
    }
    public List<VerbProperties> VerbProperties => parent.def.Verbs;
    public List<Tool> Tools => parent.def.tools;
    public ImplementOwnerTypeDef ImplementOwnerTypeDef => ImplementOwnerTypeDefOf.NativeVerb;
    public Thing ConstantCaster => Wearer;*/
}