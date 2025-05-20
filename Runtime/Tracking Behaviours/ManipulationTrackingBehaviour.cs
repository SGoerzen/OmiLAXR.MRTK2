using System.ComponentModel;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR.TrackingBehaviours;
using UnityEngine;
using Object = UnityEngine.Object;

namespace OmiLAXR.MRTK2.TrackingBehaviours
{
    [AddComponentMenu("OmiLAXR / 3) Tracking Behaviours / Manipulation Tracking Behaviour (MRTK2)"), 
     Description("Tracks manipulation events of <ObjectManipulator> components.")]
    public class ManipulationTrackingBehaviour : TrackingBehaviour
    {
        public TrackingBehaviourEvent<ObjectManipulator, ManipulationEventData> OnManipulationStarted = new TrackingBehaviourEvent<ObjectManipulator, ManipulationEventData>();
        public TrackingBehaviourEvent<ObjectManipulator, ManipulationEventData> OnManipulationEnded = new TrackingBehaviourEvent<ObjectManipulator, ManipulationEventData>();

    
        protected override void AfterFilteredObjects(Object[] objects)
        {
            var selectables = Select<ObjectManipulator>(objects);
                
            foreach (var selectable in selectables)
            {
                OnManipulationStarted.Bind(selectable.OnManipulationStarted, (evenData) => { OnManipulationStarted.Invoke(this, selectable, evenData); });
                OnManipulationEnded.Bind(selectable.OnManipulationEnded, (evenData) => { OnManipulationEnded.Invoke(this, selectable, evenData); });
            }
        
        }
    }
}