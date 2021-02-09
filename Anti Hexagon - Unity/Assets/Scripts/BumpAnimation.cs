using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve bumpCurve;

    private float stopTime;
    private float currentTime;
    private bool onTimePassed = false;
    private Vector3 scaleInit;

    // Start is called before the first frame update
    void Start()
    {
        stopTime = bumpCurve[bumpCurve.length - 1].time;
        currentTime = 0.0f;
        scaleInit = transform.localScale;
    }

    public void playBump()
    {
        currentTime = 0.0f;
        onTimePassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!onTimePassed)
        {
            currentTime += Time.deltaTime;
            if (currentTime > stopTime)
            {
                onTimePassed = true;
            }
            else
            {
                float currentBumpValue = bumpCurve.Evaluate(currentTime);
                transform.localScale = scaleInit * currentBumpValue;
            }
        }
    }
}
