using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DustStormController : MonoBehaviour
{
    public PostProcessProfile dustStormProfile;
    public AudioSource windSound;
    public AudioSource dustSound;

    private PostProcessVolume postProcessVolume;

    private void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile = dustStormProfile;

        StartCoroutine(StartDustStorm());
    }

    private IEnumerator StartDustStorm()
    {
        windSound.Play();
        dustSound.Play();

        // Gradually increase the intensity of post-processing effects
        for (float t = 0; t < 5f; t += Time.deltaTime)
        {
            ColorGrading colorGradingLayer;
            if (postProcessVolume.profile.TryGetSettings(out colorGradingLayer))
            {
                colorGradingLayer.saturation.value = Mathf.Lerp(1f, 0.5f, t / 5f);
            }

            yield return null;
        }
    }
}