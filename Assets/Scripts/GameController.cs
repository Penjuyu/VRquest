using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public Text scoresText;
    int scores;
    public static GameController instance;
    public Text endText;
    public Text WinText;
    public void Lose()

    {
        endText.text = "Game Over";
        endText.color = Color.red;

        StartCoroutine(Restart());



    }
    public void Win()
    {
        endText.text = "Win";
        endText.color = new Color(0, 1, 0);
        StartCoroutine(Restart());
    }
    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start ()
    {
        instance = this;
	}
	
	
	public void ChangeScore (int score)
    {
        scores += score;
        scoresText.text = scores.ToString();
	}
    
}
