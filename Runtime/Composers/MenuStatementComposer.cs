using System.ComponentModel;
using OmiLAXR.Composers;
using OmiLAXR.MRTK2.TrackingBehaviours;
using OmiLAXR.xAPI.Composers;
using UnityEngine;

namespace OmiLAXR.MRTK2.Composers
{
    [AddComponentMenu("OmiLAXR / 4) Composers / Menu Statement Composer (MRTK2)"), 
     Description("Creates statements:\\n- actor pressed uiElement with vrObjectName(String), uiElementType(String)")]
    public class MenuStatementComposer : xApiComposer<MenuTrackingBehaviour>
    {
        public override Author GetAuthor()
            => new Author("Felix Meinhardt", "felix.meinhardt@rwth-aachen.de");
    

        protected override void Compose(MenuTrackingBehaviour tb)
        {
            tb.OnClickedButton.AddHandler((_, button) =>
            {
                var buttonName = button.gameObject.GetTrackingName();
                
                var stmt = actor.Does(xapi.virtualReality.verbs.pressed)
                    .WithExtension(xapi.virtualReality.extensions.activity
                        .uiElementType("button")
                        .vrObjectName(buttonName))
                    .Activity(xapi.virtualReality.activities.uiElement);
                SendStatement(stmt);
            });
        }
    }

}
