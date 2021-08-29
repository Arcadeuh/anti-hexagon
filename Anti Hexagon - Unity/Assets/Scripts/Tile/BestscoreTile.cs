using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestscoreTile : MonoBehaviour
{
    [SerializeField] private TextDisplay bestscoreDisplay;
    [SerializeField] private int modeNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    public void updateText()
    {
        SaveObject save = SaveSystem.load();
        if (save == null)
        {
            return;
        }
        Debug.Log(modeNumber);
        switch (modeNumber)
        {
            case 1:
                bestscoreDisplay.setTMP(save.bestScoreMode1.ToString());
                break;
            case 2:
                bestscoreDisplay.setTMP(save.bestScoreMode2.ToString());
                break;
            default:
                bestscoreDisplay.setTMP("ERROR");
                break;
        }
    }
}
