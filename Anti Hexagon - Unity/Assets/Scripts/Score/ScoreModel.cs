using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private int multiplierDelta = 10;
    private int score = 0;
    private int combo = 0;
    private int multiplier = 1;
    [SerializeField] private TextDisplay scoreDisplay;
    [SerializeField] private TextDisplay comboDisplay;
    [SerializeField] private ScoreView scoreView;

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.setTMP(score.ToString());
        comboDisplay.setTMP("X" + multiplier.ToString());
    }

    public void addScore(int scoreAdded)
    {
        score += scoreAdded * multiplier;
    }

    public void addOneScore()
    {
        score += multiplier;
    }

    public void addOneCombo()
    {
        combo += 1;
        if (combo % multiplierDelta == 0 && multiplier < 10)
        {
            multiplier += 1;
            if (multiplier < 5)
            {
                scoreView.playComboRaise();
            }
            else if(multiplier < 10)
            {
                scoreView.playBigComboRaise();
            }
            else
            {
                scoreView.playMaxCombo();
            }
            
        }
    }

    public void resetComboVariables()
    {
        Debug.Log("Multiplier and combo reset");
        scoreView.playComboBroken();
        combo = 0;
        multiplier = 1;
    }
}
