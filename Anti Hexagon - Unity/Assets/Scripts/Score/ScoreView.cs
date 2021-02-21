using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private GameObject score;
    [SerializeField] private GameObject combo;

    public void playComboBroken()
    {
        combo.GetComponent<Animator>().Play("Null");
        combo.GetComponent<Animator>().Play("ComboBroken");
    }

    public void playComboRaise()
    {
        combo.GetComponent<Animator>().Play("ComboRaise");
    }

    public void playBigComboRaise()
    {
        combo.GetComponent<Animator>().Play("BigComboRaise");
    }

    public void playMaxCombo()
    {
        combo.GetComponent<Animator>().Play("Null");
        combo.GetComponent<Animator>().Play("BigComboRaise");
    }
}
