using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rythm : MonoBehaviour
{
    public float rythm = 0.25f;
    public UnityEvent clock;
    
    private bool coroutineLaunched = false;

    private IEnumerator RythmCoroutine()
    {
        yield return new WaitForSeconds(rythm);
        clock.Invoke();
        coroutineLaunched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!coroutineLaunched)
        {
            coroutineLaunched = true;
            StartCoroutine("RythmCoroutine");
        }
    }
}
