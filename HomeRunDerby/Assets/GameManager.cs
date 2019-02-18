using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject PanelGame, PanelMainMenu,PanelGameOver, currentScore, heart1, heart2, heart3;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
       PanelMainMenu.SetActive(true);  
       currentScore.SetActive(false);
       health = 3;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 3)
		health = 3;

		switch(health){
			case 3:
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(true);
			heart3.gameObject.SetActive(true);
			break;
			case 2:
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(true);
			heart3.gameObject.SetActive(false);
			break;
			case 1:
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(false);
			heart3.gameObject.SetActive(false);
			break;
			case 0:
			heart1.gameObject.SetActive(false);
			heart2.gameObject.SetActive(false);
			heart3.gameObject.SetActive(false);
			PanelGameOver.SetActive(true);
			currentScore.SetActive(true);
			PanelGame.SetActive(false);
			Time.timeScale = 1;
			break;
			
		}
    }

    public void PanelGameActive()
    {
        PanelMainMenu.SetActive(false);
        PanelGame.SetActive(true);
        currentScore.SetActive(true);
    }

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    
}
