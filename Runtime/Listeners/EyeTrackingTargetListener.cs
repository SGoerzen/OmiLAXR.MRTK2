#if IMPLEMENTED_EYETRACKING
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmilLAXR.Listeners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <EyeTrackingTarget> Eye Tracking Target Listener")]
    public class EyeTrackingTargetListener : Listener
    {
        public bool includeInactive = true;
    
        public override void StartListening()
        {
            var selectables = FindObjectsOfType<EyeTrackingTarget>(includeInactive);
            Found(selectables);
        
        }
    }
}
#endif