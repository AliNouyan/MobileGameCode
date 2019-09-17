using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    float directionX;
    float directionY;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(CrossPlatformInputManager.GetAxis("Horizontal"));
        directionX = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity += new Vector2(directionX * 10, 0);

        //Debug.Log(CrossPlatformInputManager.GetAxis("Vertical"));
        directionY = CrossPlatformInputManager.GetAxis("Vertical");
        rb.velocity += new Vector2(directionY * 0, 10);
    }



}
