﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {

    public Text answerText;
    private Game2 answerData;
    private GameControp gameControler;
	// Use this for initialization


	void Start () {
        gameControler = FindObjectOfType<GameControp>();
	}
	public void Setup(Game2 data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }
	// Update is called once per frame
	/*void Update () {
		
	}*/
    public void HandleClick()
    {
        gameControler.AnswerButtonClicked(answerData.IsCoreect);

    }
}
