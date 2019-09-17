using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour {

    GameObject Explosion;

	// Use this for initialization
	void Start () {
        Explosion = this.gameObject;
        StartCoroutine(DestroyExplosion());
        
        StartCoroutine(ColliderSize());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator DestroyExplosion()
    {
        yield return new WaitForSeconds(2f);

        Destroy(Explosion);
    }

    IEnumerator ColliderSize()
    {
        yield return new WaitForSeconds(1f);
        var collidersize = this.gameObject.GetComponent<BoxCollider2D>();
        collidersize.size = new Vector2(0.5f, 0.5f);
    }
}
