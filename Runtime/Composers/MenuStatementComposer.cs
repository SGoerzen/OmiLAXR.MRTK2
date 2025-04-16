using System.Collections;
using System.Collections.Generic;
using OmiLAXR;
using OmiLAXR.Composers;
using OmiLAXR.xAPI.Composers;
using UnityEngine;

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
