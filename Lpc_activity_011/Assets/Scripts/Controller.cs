using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public int totalScore;
    public Text scoreText;
    public GameObject gameOver;

    public static Controller Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void UpdateScoreText(){
        scoreText.text = totalScore.ToString(); 
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName){
        SceneManager.LoadScene(lvlName);
    }
}
