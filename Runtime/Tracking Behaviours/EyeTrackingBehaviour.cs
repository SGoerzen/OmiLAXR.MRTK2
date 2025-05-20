#if IMPLEMENTED_EYETRACKING
using Microsoft.MixedReality.Toolkit.Input;
using OmiLAXR.TrackingBehaviours;
using UnityEngine;
using UnityEngine.Events;

public class EyeTrackingBehaviour : TrackingBehaviour
{
    public TrackingBehaviourEvent<EyeTrackingTarget> eyeTrackingTargetOnLookAtStart = new TrackingBehaviourEvent<EyeTrackingTarget>();
    public TrackingBehaviourEvent<EyeTrackingTarget> eyeTrackingTargetOnLookAway = new TrackingBehaviourEvent<EyeTrackingTarget>();
    public TrackingBehaviourEvent<EyeTrackingTarget> eyeTrackingTargetOnDwell = new TrackingBehaviourEvent<EyeTrackingTarget>();
    
    
    public TrackingBehaviourEvent<GazeDetection, GameObject> gazeDetectionOnLookAtStart = new TrackingBehaviourEvent<GazeDetection, GameObject>();
    public TrackingBehaviourEvent<GazeDetection, GameObject> gazeDetectionOnLookAtEnd = new TrackingBehaviourEvent<GazeDetection, GameObject>();
    public TrackingBehaviourEvent<GazeDetection, GameObject> gazeDetectionOnDwell = new TrackingBehaviourEvent<GazeDetection, GameObject>();

    protected override void AfterFilteredObjects(Object[] objects)
    {
        var eyeTrackingTargetSelectables = Select<EyeTrackingTarget>(objects);

        foreach (var selectable in eyeTrackingTargetSelectables)
        {
            eyeTrackingTargetOnLookAtStart.Bind(selectable.OnLookAtStart, () => { eyeTrackingTargetOnLookAtStart.Invoke(this, selectable); });
            eyeTrackingTargetOnLookAway.Bind(selectable.OnLookAway, () => { eyeTrackingTargetOnLookAway.Invoke(this, selectable); });
            eyeTrackingTargetOnDwell.Bind(selectable.OnDwell, () => { eyeTrackingTargetOnLookAway.Invoke(this, selectable); });
        }
        
        var gazeDetectionSelectables = Select<GazeDetection>(objects);
        
        foreach (var selectable in gazeDetectionSelectables)
        {
            gazeDetectionOnLookAtStart.Bind(selectable.onLookAtStart, (gazeTarget) => { gazeDetectionOnLookAtStart.Invoke(this, selectable, gazeTarget); });
            gazeDetectionOnLookAtEnd.Bind(selectable.onLookAtEnd, (gazeTarget) => { gazeDetectionOnLookAtEnd.Invoke(this, selectable, gazeTarget); });
            gazeDetectionOnDwell.Bind(selectable.onDwell, (gazeTarget) => { gazeDetectionOnDwell.Invoke(this, selectable, gazeTarget); });
        }
    }
}
#endif