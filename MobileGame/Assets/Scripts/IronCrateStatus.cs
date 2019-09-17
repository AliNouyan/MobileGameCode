using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronCrateStatus : MonoBehaviour {

    public Sprite IronCrate2;
    public bool IronStatus = false;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if (IronStatus == true)
        {
            spriteRenderer.sprite = IronCrate2;
        }
	}
}
