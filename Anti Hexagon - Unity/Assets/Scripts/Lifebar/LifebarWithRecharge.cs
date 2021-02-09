using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifebarWithRecharge : MonoBehaviour
{
    [SerializeField] private int nbPVMax = 8;
    [SerializeField] private float recoverySpeed = 0.1f;
    [SerializeField] private ScoreModel score;
    [SerializeField] private UnityEvent whenPVAtZero;

    private int nbPV;
    private float originalScale;
    // Start is called before the first frame update
    void Start()
    {
        nbPV = nbPVMax;
        originalScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(nbPV < nbPVMax && nbPV>=0)
        {
            transform.localScale = new Vector3(transform.localScale.x + transform.localScale.x * recoverySpeed * Time.deltaTime, transform.localScale.y, transform.localScale.z);
            if(transform.localScale.x >= (nbPV+1) * originalScale / nbPVMax) { nbPV++; }
            if (nbPV == 0)
            {
                whenPVAtZero.Invoke();
            }
        }
    }

    public void getHit()
    {
        if (nbPV == 0) { return; }
        nbPV -= 1;
        transform.localScale = new Vector3(originalScale / nbPVMax * nbPV, transform.localScale.y, transform.localScale.z);
        score.resetComboVariables();
    }

}
