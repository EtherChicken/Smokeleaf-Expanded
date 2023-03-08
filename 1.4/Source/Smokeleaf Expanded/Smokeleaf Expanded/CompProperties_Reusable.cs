using RimWorld;
using Verse;

namespace ETH_Smokeleaf_Expanded;

public class CompProperties_Reusable : CompProperties
{
    public int maxCharges = 1;
    public bool destroyOnEmpty;
    
    public CompProperties_Reusable()
    {
        compClass = typeof(CompReusable);
    }
}