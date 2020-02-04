using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameControp : MonoBehaviour {
    public Text timeRemainingdisplay;
    public Transform answerButtonParent;
    public Text questionText;
    public SimpleObject answerButtonObjectPool; 
    public Game1 dataControler;
    public Text scoreDisplayText;
    public Text questionDisplayText;
    public GameObject questiondisplay;
    public GameObject rounEnddisplay;

    private Round currentroundata;
    private Soalnya[] questionPool;

    private bool isRoundActived;
    private float timeRemaining;
    private int QuestionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();


	// Use this for initialization
	void Start () {

        UpdateTimeRemainDisplay();
        dataControler = FindObjectOfType<Game1>();
        currentroundata = dataControler.GetCurrentRoundData();
        questionPool = currentroundata.question;
        timeRemaining = currentroundata.timeLimit;

        playerScore = 0;
        QuestionIndex = 0;
        ShowQuestion();
        isRoundActived = true;

    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentroundata.pointforcorrecrt;
            scoreDisplayText.text = "Score : " + playerScore.ToString(); 
        }
        if (questionPool.Length > QuestionIndex + 1)
        {
            QuestionIndex++;
            ShowQuestion();
        }
        else
        {
            endRound();
        }
    }

    public void endRound()
    {
        isRoundActived = false;
        questiondisplay.SetActive(false);
        rounEnddisplay.SetActive(true);
    }

    private void ShowQuestion()
    {
        RemoveButton();
        Soalnya questionData = questionPool[QuestionIndex];
        questionText.text = questionData.qouestion;

        for( int i = 0; i < questionData.answer.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);
            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answer[i]);
        }

    }

    private void RemoveButton ()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }
    	

    public void returnmenu()
    {
        SceneManager.LoadScene("gameplay");
    }
	// Update is called once per frame

      private void UpdateTimeRemainDisplay()
    {
        timeRemainingdisplay.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }
	void Update () {
        if (isRoundActived)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainDisplay();
            if(timeRemaining <= 0f)
            {
                endRound();
            }
        }
       }
}
