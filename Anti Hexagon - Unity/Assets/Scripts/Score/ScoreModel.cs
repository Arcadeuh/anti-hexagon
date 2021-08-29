using UnityEngine;
using UnityEngine.Events;

public class ScoreModel : MonoBehaviour
{
    [SerializeField] private int multiplierDelta = 10;
    [SerializeField] private int maxMultiplier = 10;
    [SerializeField] private int scoreDeltaSpeedup = 1000;
    [SerializeField] private int mode = 1;
    private int scoreToReach = 500;
    [SerializeField] private UnityEvent onScoreReached;
    [SerializeField] private UnityEvent onOneMultiplierGain;
    [SerializeField] private UnityEvent onSpeedup;
    private int score = 0;
    private int combo = 0;
    private int multiplier = 1;
    private int speedupCount = 0;
    [SerializeField] private TextDisplay scoreDisplay;
    [SerializeField] private TextDisplay comboDisplay;
    [SerializeField] private ScoreView scoreView;

    private bool scoreBeaten = false;

    private void Start()
    {
        SaveObject saveObject = SaveSystem.load();
        if (saveObject==null)
        {
            Debug.Log("No save files"); 
            return; 
        }
        switch (mode)
        {
            case 1:
                scoreToReach = saveObject.bestScoreMode1;
                break;
            case 2:
                scoreToReach = saveObject.bestScoreMode2;
                break;
            default:
                break;
        };
        scoreToReach = saveObject.bestScoreMode1;
    }

    // Unity Methods
    void Update()
    {
        scoreDisplay.setTMP(score.ToString());
        comboDisplay.setTMP("+" + multiplier.ToString());

        if (score >= scoreToReach && !scoreBeaten)
        {
            scoreBeaten = true;
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
        int lastModulo = score % scoreDeltaSpeedup;
        score += multiplier;
        if (lastModulo >= score % scoreDeltaSpeedup && speedupCount<4)
        {
            speedupCount++;
            onSpeedup.Invoke();
        }
    }

    public void addOneCombo()
    {
        combo += 1;
        if (combo % multiplierDelta == 0 && multiplier < maxMultiplier)
        {
            onOneMultiplierGain.Invoke();
            multiplier += 1;
            if (multiplier < 5)
            {
                scoreView.playComboRaise();
            }
            else if(multiplier < maxMultiplier)
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
        combo = 0;
        multiplier = 1;
    }

    public void saveBestScore()
    {
        if (scoreBeaten)
        {
            SaveObject saveObject = SaveSystem.load();
            if (saveObject == null)
            {
                Debug.Log("No save files");
                return;
            }
            switch (this.mode){
                case 1:
                    saveObject.bestScoreMode1 = score;
                    break;
                case 2:
                    saveObject.bestScoreMode2 = score;
                    break;
                default:
                    break;
            };
            SaveSystem.save(saveObject);
            GameObject.Find("TileBestscore").GetComponent<BestscoreTile>().updateText();
        }
    }
}
