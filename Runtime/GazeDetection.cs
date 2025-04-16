using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;
using UnityEngine.Events;

public class GazeDetection : MonoBehaviour
{
    public float dwellTime = 0.8f;
    public float maxGazeDistance = 10f;
    public bool onlyConsiderEyeTrackingTargets = false;
    public bool outputToDebugLog = false;
    private GameObject currentTarget;
    private float currentDwellTime;
    private bool isDwelling;
    
    public UnityEvent<GameObject> onLookAtStart = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> onLookAtEnd = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> onDwell = new UnityEvent<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        if (outputToDebugLog)
        {
            onLookAtStart.AddListener(debugLogOnLookAtStart);
            onLookAtEnd.AddListener(debugLogOnLookAtEnd);
            onDwell.AddListener(debugLogOnDwell);
        }
    }

    // Update is called once per frame
    void Update()
    {
        DetectGaze();
    }

    private void DetectGaze()
    {
        if (CoreServices.InputSystem.EyeGazeProvider.IsEyeTrackingEnabledAndValid)
        {
            
            // Get gaze ray
            Vector3 gazeDirection = CoreServices.InputSystem.EyeGazeProvider.GazeDirection;
            Vector3 gazeOrigin = CoreServices.InputSystem.EyeGazeProvider.GazeOrigin;
            
            Ray gazeRay = new Ray(gazeOrigin, gazeDirection);
            
            if (Physics.Raycast(gazeRay, out RaycastHit hit, maxGazeDistance))
            {
                //Looking at an object
                GameObject hitObject = hit.collider.gameObject;

                if (onlyConsiderEyeTrackingTargets)
                {
                    // Check if the hit object is an EyeTrackingTarget
                    hitObject.TryGetComponent(out EyeTrackingTarget eyeTrackingTarget);
                    if (eyeTrackingTarget == null)
                    {
                        OnNotLookingAtObject();
                        return;
                    }
                }
                OnLookingAtObject(hitObject);
            }
            else
            {
                // Looking at no virtual object
                OnNotLookingAtObject();
            }
        }
    }

    //Called when no raycast target was found, or it did not have the EyeTrackingTarget component whilst onlyConsiderEyeTrackingTargets is true
    private void OnNotLookingAtObject()
    {
        if (currentTarget != null)
        {
            onLookAtEnd.Invoke(currentTarget);
            currentTarget = null;
            currentDwellTime = 0f;
            isDwelling = false;
        }
    }

    //Called when a valid object is being looked at
    private void OnLookingAtObject(GameObject hitObject)
    {
        if (currentTarget != hitObject)
        {
            if(currentTarget != null) onLookAtEnd.Invoke(currentTarget);
            onLookAtStart.Invoke(hitObject);
            currentTarget = hitObject;
            currentDwellTime = 0f;
            isDwelling = false;
        }
        else
        {
            currentDwellTime += Time.deltaTime;
            if (!isDwelling && currentDwellTime > dwellTime)
            {
                isDwelling = true;
                onDwell.Invoke(currentTarget);
            }
        }
    }

    private void debugLogOnDwell(GameObject target)
    {
        Debug.Log("User is dwelling on: " + target.name);
    }
    
    private void debugLogOnLookAtStart(GameObject target)
    {
        Debug.Log("User started looking at: " + target.name);
    }
    
    private void debugLogOnLookAtEnd(GameObject target)
    {
        Debug.Log("User stopped looking at: " + target.name);
    }
}
