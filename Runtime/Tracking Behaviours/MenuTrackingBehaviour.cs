using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.MixedReality.Toolkit.UI;
using OmiLAXR;
using OmiLAXR.TrackingBehaviours;
using UnityEngine;
using Object = UnityEngine.Object;

public class MenuTrackingBehaviour : TrackingBehaviour
{

    [Gesture("UI"), Action("Click")]
    public TrackingBehaviourEvent<ButtonConfigHelper> OnClickedButton = new TrackingBehaviourEvent<ButtonConfigHelper>();
    
    protected override void AfterFilteredObjects(Object[] objects)
    {
        var selectables = objects
            .Where(o => o.GetType() == typeof(ButtonConfigHelper) || o.GetType().IsSubclassOf(typeof(ButtonConfigHelper)))
            .Select(o => o as ButtonConfigHelper).ToArray();
        foreach (var selectable in selectables)
        {
            
            OnClickedButton.Bind(selectable.OnClick, () => { OnClickedButton.Invoke(this, selectable); });
        }
        
    }
}
