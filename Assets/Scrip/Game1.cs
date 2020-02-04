using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;



//Data Controler
//Data Controler

public class Game1 : MonoBehaviour {

    public Round[] allrounded;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("SampleScene");
	}

    // Update is called once per frame
    public Round GetCurrentRoundData()
    {
        return allrounded[0];
    }
	void Update () {
		
	}
}
