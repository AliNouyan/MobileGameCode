using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public GameObject HealthGUI;
    public GameObject Player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Player = GameObject.FindGameObjectWithTag("PlayerCollider");
        var playerScript = Player.GetComponent<PlayerController>();
        int health = playerScript.lives;
        HealthGUI = GameObject.Find("Lives");
        var healthGUI = HealthGUI.GetComponent<Text>();
        healthGUI.text = ("lives: " + health.ToString());

        if (health <= 0) //if player health is 0 or less
        {
            Death(); //call death function
        }
        else
        {
            var DeathImage = GameObject.Find("DeathScreen").GetComponent<Image>().enabled = false; //disable the death screen
            var DeathText = GameObject.Find("DeathText").GetComponent<Text>().enabled = false; //disable the death screen
            var DeathButtonImage = GameObject.Find("DeathButton").GetComponent<Image>().enabled = false;
            var DeathButton = GameObject.Find("DeathButton").GetComponent<Button>().enabled = false;
            var DeathButtonText = GameObject.Find("DeathButton").GetComponentInChildren<Text>().enabled = false;
        }
    }

    void Death() //death function
    {
        var DeathImage = GameObject.Find("DeathScreen").GetComponent<Image>().enabled = true;
        var DeathText = GameObject.Find("DeathText").GetComponent<Text>().enabled = true;
        var DeathButtonImage = GameObject.Find("DeathButton").GetComponent<Image>().enabled = true;
        var DeathButton = GameObject.Find("DeathButton").GetComponent<Button>().enabled = true;
        var DeathButtonText = GameObject.Find("DeathButton").GetComponentInChildren<Text>().enabled = true;

        if (CrossPlatformInputManager.GetButtonDown("Button Press"))
        {
            Debug.Log("Button Pressed");
            SceneManager.LoadScene("Start Menu");
            CrossPlatformInputManager.SetButtonUp("Button Press");
        }
    }
}
