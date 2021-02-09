using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierFeedback : MonoBehaviour
{
    [SerializeField] private AnimationCurve bumpCurve;
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
        doItOnce = false;
    }

    private void Update()
    {
        int multiplier = scoreGameObject.GetComponent<ScoreModel>().getMultiplier();

        if (multiplier == 1)
        {
            scoreGameObject.transform.Find("Combo").localScale = comboScaleInit;
            scoreGameObject.transform.Find("Score").localScale = scoreScaleInit;
            speedLines.GetComponent<Animator>().ResetTrigger("EnterTrigger");
            centerAnimatedPart.GetComponent<Animator>().Play("Null");
            caches.GetComponent<Animator>().Play("Null");
            speedLines.GetComponent<Animator>().SetBool("EnterTrigger", false);
        }

        if (multiplier >= 5)
        {
            centerAnimatedPart.GetComponent<Animator>().Play("Colorful");
            caches.GetComponent<Animator>().Play("Colorful");
        }

        if (multiplier >= 9)
        {
            speedLines.GetComponent<Animator>().SetBool("EnterTrigger",true);
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

                if(multiplier >= 2)
                {
                    scoreGameObject.transform.Find("Combo").localScale = comboScaleInit * currentBumpValue;
                    scoreGameObject.transform.Find("Score").localScale = scoreScaleInit * currentBumpValue;
                }
                if (multiplier >= 3 && !doItOnce)
                {
                    allCorridorsView.alternateColor();
                }
                
                if (multiplier >= 10)
                {
                    //to complete
                }
                doItOnce = true;
            }
        }
        
    }

}
