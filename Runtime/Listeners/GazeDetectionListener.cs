using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmilLAXR.Listeners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <GazeDetection> Gaze Detection Listener")]
    public class GazeDetectionListener : Listener
    {
        public bool includeInactive = true;
    
        public override void StartListening()
        {
            var selectables = FindObjectsOfType<GazeDetection>(includeInactive);
            Found(selectables);
        
        }
    }
}