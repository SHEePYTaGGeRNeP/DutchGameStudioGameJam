using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFreezer : MonoBehaviour {

    private bool isFrozen;

	public void Go(int frames)
    {
        if (isFrozen) return;
        StartCoroutine(Freeze(frames));
    }

    private IEnumerator Freeze(int frames)
    {
        isFrozen = true;
        float timeScale = Time.timeScale;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(frames);
        Time.timeScale = timeScale;
        isFrozen = false;
    }
}
