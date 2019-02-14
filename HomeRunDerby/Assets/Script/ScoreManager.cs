using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
	int currentScore = 0;

	// Use this for initialization
	void Start () {
		currentScoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	public void AddScore(){
		currentScore++;
		currentScoreText.text = currentScore.ToString();
	}
}
