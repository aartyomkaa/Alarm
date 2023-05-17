using System;
using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _clip;

    private IEnumerator GradualSound(float startVolume, float targetVolume)
    {
        float duration = 20f;
        var waitForSeconds = new WaitForSeconds(0.5f);

        for (int i = 0; i <= duration; i++) 
        {
            _clip.volume = Mathf.MoveTowards(startVolume, targetVolume, i / duration);

            yield return waitForSeconds;
        }
    }

    public void StartPlay()
    {
        float startVolume = 0f; 
        float targetVolume = 1.0f;

        _clip.Play();
        var gradualSound = StartCoroutine(GradualSound(startVolume, targetVolume));

        if (_clip.volume == targetVolume)
        {
            StopCoroutine(gradualSound);
        }
    }

    public void StopPlay()
    {
        float startVolume = 1.0f;
        float targetVolume = 0f;
        var gradualSound = StartCoroutine(GradualSound(startVolume, targetVolume));

        if (_clip.volume == targetVolume)
        {
            StopCoroutine(gradualSound);
            _clip.Stop();
        }
    }
}
