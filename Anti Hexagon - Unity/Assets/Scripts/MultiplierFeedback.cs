using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierFeedback : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Color baseColor1;
    [SerializeField] private Color alterColor1;
    [SerializeField] private Color baseColor2;
    [SerializeField] private Color alterColor2;
    [SerializeField] private Color baseColor3;
    [SerializeField] private Color alterColor3;
    [SerializeField] private Color baseColor4;
    [SerializeField] private Color alterColor4;

    [Header("Resources")]
    [SerializeField] private GameObject scoreGameObject;
    [SerializeField] private GameObject centerAnimatedPart;
    [SerializeField] private GameObject caches;
    [SerializeField] private AllCorridorsView allCorridorsView;
    [SerializeField] private Animator speedLines;
    //[SerializeField] private GameObject shockwaveParent;

    private List<bool> multiplierFlags = new List<bool>();

    public void resetFlags()
    {
        for (int i = 0; i < multiplierFlags.Count; i++)
        {
            multiplierFlags[i] = false;
        }
    }

    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            multiplierFlags.Add(false);
        }
    }

    private void Update()
    {
        int multiplier = scoreGameObject.GetComponent<ScoreModel>().getMultiplier();
        caches.GetComponent<Animator>().SetInteger("Multiplier", multiplier);
        Debug.Log(caches.GetComponent<Animator>().GetInteger("Multiplier"));

        if (multiplier == 1)
        {
            centerAnimatedPart.GetComponent<Animator>().Play("Null");
            //caches.GetComponent<Animator>().Play("Null");
            allCorridorsView.reinitColor();
            speedLines.SetBool("EnterTrigger", false);
            resetFlags();
        }

        if (multiplier >= 2 && !multiplierFlags[0])
        {
            allCorridorsView.changeColor(alterColor1, baseColor1);
            multiplierFlags[0] = true;
        }

        if (multiplier >= 4 && !multiplierFlags[1])
        {
            allCorridorsView.changeColor(alterColor2, baseColor2);
            multiplierFlags[1] = true;
        }

        if (multiplier >= 6 && !multiplierFlags[2])
        {
            allCorridorsView.changeColor(alterColor3, baseColor3);
            multiplierFlags[2] = true;
        }

        if (multiplier >= 8 && !multiplierFlags[3])
        {
            allCorridorsView.changeColor(alterColor4, baseColor4);
            multiplierFlags[3] = true;
            speedLines.SetBool("EnterTrigger", true);
            centerAnimatedPart.GetComponent<Animator>().Play("Colorful");
        }
        
    }

}
