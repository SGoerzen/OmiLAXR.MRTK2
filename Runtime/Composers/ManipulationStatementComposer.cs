using System.ComponentModel;
using OmiLAXR.Composers;
using OmiLAXR.MRTK2.TrackingBehaviours;
using OmiLAXR.xAPI.Composers;
using UnityEngine;

namespace OmiLAXR.MRTK2.Composers
{
    [AddComponentMenu("OmiLAXR / 4) Composers / Manipulation Statement Composer (MRTK2)"), 
     Description("Creates statements:\\n- actor moved vrObject with actionName('manipulation started' | 'manipulation ended'), vrObjectName(String) and result position(Vector3), scale(Vector3), rotation(Vector3)")]
    public class ManipulationStatementComposer : xApiComposer<ManipulationTrackingBehaviour>
    {
        public override Author GetAuthor()
            => new Author("Felix Meinhardt", "felix.meinhardt@rwth-aachen.de");

        protected override void Compose(ManipulationTrackingBehaviour tb)
        {
            tb.OnManipulationStarted.AddHandler((_, sender, eventData) =>
            {
                var objectName = sender.gameObject.GetTrackingName();
                
                var stmt = actor.Does(xapi.virtualReality.verbs.moved)
                    .WithExtension(xapi.virtualReality.extensions.activity
                        .actionName("manipulation started")
                        .vrObjectName(objectName))
                    .WithResult(xapi.virtualReality.extensions.result
                        .position(eventData.ManipulationSource.transform.position)
                        .scale(eventData.ManipulationSource.transform.localScale)
                        .rotation(eventData.ManipulationSource.transform.rotation))
                    .Activity(xapi.virtualReality.activities.vrObject);
                SendStatement(stmt);
            });
            
            tb.OnManipulationEnded.AddHandler((_, sender, eventData) =>
            {
                var objectName = sender.gameObject.GetTrackingName();
                
                var stmt = actor.Does(xapi.virtualReality.verbs.moved)
                    .WithExtension(xapi.virtualReality.extensions.activity
                        .actionName("manipulation ended")
                        .vrObjectName(objectName))
                    .WithResult(xapi.virtualReality.extensions.result
                        .position(eventData.ManipulationSource.transform.position)
                        .scale(eventData.ManipulationSource.transform.localScale)
                        .rotation(eventData.ManipulationSource.transform.rotation))
                    .Activity(xapi.virtualReality.activities.vrObject);
                SendStatement(stmt);
            });
        }
    }
}
