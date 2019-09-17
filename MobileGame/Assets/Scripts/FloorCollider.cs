using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour {

    public GameObject Floor;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            Floor = this.gameObject;
            Debug.Log(Floor);
        }
    }
}
