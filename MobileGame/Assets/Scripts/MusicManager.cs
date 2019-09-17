using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public GameObject music;
    public GameObject spawnmusic;

	// Use this for initialization
	void Start () {
        music = GameObject.FindGameObjectWithTag("GameMusic");

        if (music == null)
        {
            Instantiate(spawnmusic);
        }
        else
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
        
        
	}
}
