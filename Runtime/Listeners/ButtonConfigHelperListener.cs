using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmilLAXR.LIsteners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <ButtonConfigHelper> Button Listener")]
    public class ButtonConfigHelperListener : Listener
    {
        public bool includeInactive = true;
    
        public override void StartListening()
        {
            var selectables = FindObjectsOfType<ButtonConfigHelper>(includeInactive);
            Found(selectables);
        
        }
    }
}
