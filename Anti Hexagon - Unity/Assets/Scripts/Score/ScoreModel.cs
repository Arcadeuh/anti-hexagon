using UnityEngine;
using UnityEngine.Events;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private int multiplierDelta = 10;
    [SerializeField] private int scoreToReach = 4000;
    [SerializeField] private UnityEvent onScoreReached;
    private int score = 0;
    private int combo = 0;
    private int multiplier = 1;
    [SerializeField] private TextDisplay scoreDisplay;
    [SerializeField] private TextDisplay comboDisplay;
    [SerializeField] private ScoreView scoreView;

    private bool doItOnce = false;

    // Unity Methods
    void Update()
    {
        scoreDisplay.setTMP(score.ToString());
        comboDisplay.setTMP("X" + multiplier.ToString());

        if (score >= scoreToReach && !doItOnce)
        {
            doItOnce = true;
            onScoreReached.Invoke();
        }
    }

    //~~~~~~Getters~~~~~~

    public int getMultiplier()
    {
        return multiplier;
    }


    //~~~~~~Variables manipulation~~~~~~
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
        scoreView.playComboBroken();
        combo = Mathf.FloorToInt(combo/2);
        multiplier = 1;
    }
}
