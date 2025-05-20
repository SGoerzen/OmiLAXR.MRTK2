using System.ComponentModel;
using OmiLAXR.Listeners;
using UnityEngine;

namespace OmiLAXR.MRTK2.Listeners
{
    [AddComponentMenu("OmiLAXR / 1) Listeners / <GazeDetection> Gaze Detection Listener (MRTK2)"),
    Description("Provides all <GazeDetection> components to pipeline.")]
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