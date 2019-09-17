using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCrateScript : MonoBehaviour {

    float RandomCrate;
    float RandomPickUp;
    float RandomPickUpObject;
    public GameObject IronCrate;
    public GameObject TNTCrate;
    public GameObject BombPlusOne;
    public GameObject BombPower;
    public GameObject Speed;
    GameObject WoodCrate;

	// Use this for initialization
	void Start () {
        RandomCrate = Random.Range(0f, 100f);

        WoodCrate = this.gameObject;

		if(RandomCrate < 20f)
        {
            GameObject Iron = Instantiate(IronCrate, WoodCrate.transform.position, new Quaternion());
            Destroy(WoodCrate);
        }
        else if (RandomCrate > 21f && RandomCrate < 35f)
        {
            GameObject TNT = Instantiate(TNTCrate, WoodCrate.transform.position, new Quaternion());
            Destroy(WoodCrate);
        }

        RandomPickUp = Random.Range(0f, 100f);
        RandomPickUpObject = Random.Range(0f, 100f);

        if(RandomPickUp < 33f)
        {
            if(RandomPickUpObject < 33.3f)
            {
                GameObject BombPlusOnePickUp = Instantiate(BombPlusOne, new Vector3(WoodCrate.transform.position.x, WoodCrate.transform.position.y, -0.04f), new Quaternion());
            }
            if (RandomPickUpObject > 33.4f && RandomPickUpObject < 66.6f)
            {
                GameObject BombPowerPickUp = Instantiate(BombPower, new Vector3(WoodCrate.transform.position.x, WoodCrate.transform.position.y, -0.04f), new Quaternion());
            }
            if (RandomPickUpObject > 66.7f && RandomPickUpObject < 100f)
            {
                GameObject SpeedPickUp = Instantiate(Speed, new Vector3(WoodCrate.transform.position.x, WoodCrate.transform.position.y, -0.04f), new Quaternion());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
