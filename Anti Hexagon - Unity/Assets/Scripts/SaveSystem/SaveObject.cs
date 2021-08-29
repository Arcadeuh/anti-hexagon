using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveObject
{
    public int bestScoreMode1;
    public int bestScoreMode2;

    public SaveObject(int bestScoreMode1, int bestScoreMode2)
    {
        this.bestScoreMode1 = bestScoreMode1;
        this.bestScoreMode2 = bestScoreMode2;
    }

}
