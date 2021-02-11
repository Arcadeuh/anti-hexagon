using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierFeedback : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private AnimationCurve bumpCurve;
    [SerializeField] private Color baseCorridorColorMulti2;
    [SerializeField] private Color alterCorridorColorMulti2;

    [Header("Resources")]
    [SerializeField] private GameObject scoreGameObject;
    [SerializeField] private GameObject centerAnimatedPart;
    [SerializeField] private GameObject caches;
    [SerializeField] private AllCorridorsView allCorridorsView;
    [SerializeField] private GameObject speedLines;

    private float stopTime;
    private float currentTime;
    private bool onTimePassed = false;
    private bool doItOnce = false;

    private Vector3 comboScaleInit;
    private Vector3 scoreScaleInit;
    private Vector3 centerScaleInit;

    private void Start()
    {
        stopTime = bumpCurve[bumpCurve.length - 1].time;
        currentTime = stopTime + 1;

        comboScaleInit = scoreGameObject.transform.Find("Combo").localScale;
        scoreScaleInit = scoreGameObject.transform.Find("Score").localScale;
        centerScaleInit = centerAnimatedPart.transform.localScale;
    }

    public void playBump()
    {
        currentTime = 0.0f;
        onTimePassed = false;
    }

    private void Update()
    {
        int multiplier = scoreGameObject.GetComponent<ScoreModel>().getMultiplier();

        if (multiplier == 1)
        {
            scoreGameObject.transform.Find("Combo").localScale = comboScaleInit;
            scoreGameObject.transform.Find("Score").localScale = scoreScaleInit;
            centerAnimatedPart.GetComponent<Animator>().Play("Null");
            caches.GetComponent<Animator>().Play("Null");
            speedLines.GetComponent<Animator>().SetBool("EnterTrigger", false);
            allCorridorsView.reinitColor();
            doItOnce = false;
        }

        if (multiplier >= 5 && !doItOnce)
        {
            allCorridorsView.changeColor(baseCorridorColorMulti2, alterCorridorColorMulti2);
            doItOnce = true;
        }

        if (multiplier >= 7)
        {
            speedLines.GetComponent<Animator>().SetBool("EnterTrigger",true);
        }

        if (multiplier >= 10)
        {
            centerAnimatedPart.GetComponent<Animator>().Play("Colorful");
            caches.GetComponent<Animator>().Play("Colorful");
        }

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
                centerAnimatedPart.transform.localScale = centerScaleInit * currentBumpValue;
                
                if (multiplier >= 3)
                {
                    scoreGameObject.transform.Find("Combo").localScale = comboScaleInit * currentBumpValue;
                    scoreGameObject.transform.Find("Score").localScale = scoreScaleInit * currentBumpValue;
                }
                
            }
        }
        
    }

}
