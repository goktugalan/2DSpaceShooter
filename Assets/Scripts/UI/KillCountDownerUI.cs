using System.IO;
using UnityEngine;
using TMPro;

[System.Serializable]
public class HighScoreData
{
    public int highScore;
    public int highEnemy1Count;
    public int highEnemy2Count;
}

public class KillCountDownerUI : MonoBehaviour
{
    // In-game TextMeshPro references
    public TextMeshProUGUI enemy1CountdownText;
    public TextMeshProUGUI enemy2CountdownText;
    public TextMeshProUGUI scoreText;

    // End-game panel TextMeshPro references
    public TextMeshProUGUI endGameEnemy1Text;
    public TextMeshProUGUI endGameEnemy2Text;
    public TextMeshProUGUI endGameScoreText;

    private int enemy1KillCountdown = 0;
    private int enemy2KillCountdown = 0;
    private int score = 0;

    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/highscore.json";
    }

    public void IncrementKillCount(string enemyTag)
    {
        if (enemyTag == "Enemy 1")
        {
            enemy1KillCountdown++;
            enemy1CountdownText.text = ": " + enemy1KillCountdown;
            score += 25;
            scoreText.text = "Score: " + score;
        }
        else if (enemyTag == "Enemy")
        {
            enemy2KillCountdown++;
            enemy2CountdownText.text = ": " + enemy2KillCountdown;
            score += 10;
            scoreText.text = "Score: " + score;
        }
    }

    public void SaveHighScore()
    {
        HighScoreData data = LoadHighScore();

        if (score > data.highScore)
        {
            data.highScore = score;
            data.highEnemy1Count = enemy1KillCountdown;
            data.highEnemy2Count = enemy2KillCountdown;

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(savePath, json);
        }
    }

    public HighScoreData LoadHighScore()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<HighScoreData>(json);
        }
        else
        {
            return new HighScoreData();
        }
    }

    public void DisplayEndGameScores()
    {
        // Display high scores in the end-game panel
        HighScoreData data = LoadHighScore();
        endGameEnemy1Text.text = ":" + data.highEnemy1Count.ToString();
        endGameEnemy2Text.text = ":" + data.highEnemy2Count.ToString();
        endGameScoreText.text = ":" + data.highScore.ToString();
    }

}
