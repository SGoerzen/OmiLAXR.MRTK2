using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmilLAXR.Listeners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <ObjectManipulator> Manipulatable Object Listener")]
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