using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    private int score;
    private int highScore;

    public GameObject highScorePanelHomeScreen;
    public GameObject ScorePanelHomeScreen;

    public Text highScoreHomeScreen;
    public Text scoreHomeScreen;
    public Text scoreEndScreen;
    public Text highScoreEndScreen;


    public void incrementScore()
    {
        score++;
        scoreHomeScreen.text = score.ToString();

        if(score > highScore)
        {
            highScoreHomeScreen.text = score.ToString();
            highScoreHomeScreen.color = Color.green;
            scoreHomeScreen.color = Color.green;
        }

        if(score % 15 == 0)
        {
            randomAsteroid.instance.speed *= 1.2f;
            randomAsteroid.instance.radius *= 0.8f;
        }
    }


    
    public int getScore()
    {
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        score = 0;
        highScore = 0;
        highScore = PlayerPrefs.GetInt("highscore",highScore);

        highScoreHomeScreen.text = highScore.ToString();
        scoreHomeScreen.text = score.ToString();
    }

    public void endGame() {
        highScorePanelHomeScreen.SetActive(false);
        ScorePanelHomeScreen.SetActive(false);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
            highScoreEndScreen.color = Color.green;
            scoreEndScreen.color = Color.green;
        }
        scoreEndScreen.text = score.ToString();
        highScoreEndScreen.text = highScore.ToString();
    }

        // Update is called once per frame
    void Update()
    {
        
    }
}
