using System.ComponentModel;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmiLAXR.MRTK2.Listeners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <ButtonConfigHelper> Button Listener (MRTK2)"),
    Description("Provides all <ButtonConfigHelper> components to pipeline.")]
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
