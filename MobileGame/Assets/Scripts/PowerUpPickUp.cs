using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour {

    int power;
    float MoveSpeed;
    int BombCapacity;
    int BombPlaced;
    GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("PlayerCollider");
        power = Player.gameObject.GetComponent<PlayerController>().power;
        BombCapacity = Player.gameObject.GetComponent<PlayerController>().BombCapacity;
        BombPlaced = Player.gameObject.GetComponent<PlayerController>().BombPlaced;
        MoveSpeed = Player.gameObject.GetComponent<PlayerController>().MoveSpeed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D Pickups)
    {
        if (Pickups.gameObject.tag == "BombPickup")
        {
            Debug.Log("Reset Bombs");
            Player.gameObject.GetComponent<PlayerController>().BombPlaced = 0;
        }

        if (Pickups.gameObject.tag == "BombPlusOne")
        {
            Player.gameObject.GetComponent<PlayerController>().BombCapacity++;
            Debug.Log("Bomb capacity is " + BombCapacity);
        }

        if (Pickups.gameObject.tag == "BombPowerup")
        {
            Player.gameObject.GetComponent<PlayerController>().power++;
            Debug.Log("Bomb Power is " + power);
        }

        if (Pickups.gameObject.tag == "SpeedPower")
        {
            MoveSpeed = Player.gameObject.GetComponent<PlayerController>().MoveSpeed = MoveSpeed + 3f;
            Debug.Log("Move speed is " + MoveSpeed);
        }
    }
}
