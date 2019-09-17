using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

    Animator anim;
    //public GameObject Powerup;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.enabled = true;
    }

    void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "PlayerCollider")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
