using System.ComponentModel;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmiLAXR.MRTK2.Listeners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <ObjectManipulator> Listener (MRTK2)"),
    Description("Provides all <ObjectManipulator> components to pipeline.")]
    public class ObjectManipulatorListener : Listener
    {
        public bool includeInactive = true;
    
        public override void StartListening()
        {
            var selectables = FindObjectsOfType<ObjectManipulator>(includeInactive);
            Found(selectables);
        
        }
    }
}