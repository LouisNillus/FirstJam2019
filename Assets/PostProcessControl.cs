using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessControl : MonoBehaviour
{

    public PostProcessVolume volume;
    private Vignette vignette;
    private Bloom bloom;
    private ChromaticAberration chromAb;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out bloom);
        volume.profile.TryGetSettings(out chromAb);
        vignette.color.value = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator BloomTransition(float initialValue, float finalValue, float inDuration, float outDuration)
    {
        float time = 0.0f;

        while (time < inDuration)
        {
            bloom.intensity.value = Mathf.Lerp(initialValue, finalValue, time/inDuration);
            time += Time.deltaTime;
            yield return null;
        }

        bloom.intensity.value = finalValue;

        time = 0.0f;

        while (time < outDuration)
        {
            bloom.intensity.value = Mathf.Lerp(finalValue, initialValue, time / outDuration);
            time += Time.deltaTime;
            yield return null;
        }

        bloom.intensity.value = initialValue;
    }
}
