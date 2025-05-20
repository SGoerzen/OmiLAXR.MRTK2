using System.Collections;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SceneSystem;
using OmiLAXR;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReenablePipelinesOnSceneLoad : MonoBehaviour
{
    private SceneManager sceneManager;
    private Pipeline[] pipelines;
    void Start()
    {
        FindPipelines();

        IMixedRealitySceneSystem sceneSystem = MixedRealityToolkit.Instance.GetService<IMixedRealitySceneSystem>();
        sceneSystem.OnSceneLoaded += RestartPipelines;
    }

    public void FindPipelines()
    {
        pipelines = FindObjectsOfType<Pipeline>(false);
        if (pipelines.Length == 0)
        {
            Debug.LogWarning("No pipelines found");
        }
    }

    public void RestartPipelines(string sceneName)
    {
        foreach (var pipeline in pipelines)
        {
            pipeline.StopPipeline();
            pipeline.StartPipeline();
            //StartCoroutine(RestartHelper(pipeline));
        }
    }

    private IEnumerator RestartHelper(Pipeline pipeline)
    {
        yield return null;
        pipeline.StartPipeline();
    }

    
}
