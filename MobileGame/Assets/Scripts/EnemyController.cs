using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject Player;
    public GameObject Bomb;
    GameObject This;
    Vector3 Floor;
    public int BombCapacity = 1;
    public int BombPlaced = 0;
    RaycastHit2D Rayup;
    RaycastHit2D Raydown;
    RaycastHit2D Rayleft;
    RaycastHit2D Rayright;
    int randomRay;
    Rigidbody2D EnemyRigidBody;
    public float MoveSpeed;
    

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        This = GameObject.FindGameObjectWithTag("Enemy");
        EnemyRigidBody = This.GetComponent<Rigidbody2D>();

        StartCoroutine(Loop());
    }
	
	// Update is called once per frame
	void Update () {

        //Rayup = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 0.5f), new Vector2(this.transform.position.x, this.transform.position.y + 10f));
        //Raydown = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 0.5f), new Vector2(this.transform.position.x, this.transform.position.y - 10f));
        //Rayleft = Physics2D.Linecast(new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), new Vector2(this.transform.position.x + 10f, this.transform.position.y));
        //Rayright = Physics2D.Linecast(new Vector2(this.transform.position.x - 0.5f, this.transform.position.y), new Vector2(this.transform.position.x - 10f, this.transform.position.y));

        //if (Vector2.Distance(Player.transform.position, This.transform.position) < 6 && Vector2.Distance(Player.transform.position, This.transform.position) > 3)
        //{
        //    This.transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, 0.1f);
        //}
        //else if(Vector2.Distance(Player.transform.position, This.transform.position) < 3)
        //{
        //    if (BombPlaced < BombCapacity)
        //    {
        //        Instantiate(Bomb, Floor, This.transform.rotation);
        //
        //        BombPlaced++;
        //    }
        //}
    }

    private void OnTriggerStay2D(Collider2D floor)
    {
        if (floor.gameObject.tag == "Floor")
        {
            Floor = new Vector3(floor.gameObject.transform.position.x, floor.gameObject.transform.position.y, -0.5f);
            //Debug.Log(Floor);
        }
    }

    public IEnumerator Loop()
    {
        while (true)
        {
            Rayup = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.3f));
            Raydown = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 1.2f), new Vector2(this.transform.position.x, this.transform.position.y - 1.3f));
            Rayleft = Physics2D.Linecast(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y), new Vector2(this.transform.position.x + 1.3f, this.transform.position.y));
            Rayright = Physics2D.Linecast(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y), new Vector2(this.transform.position.x - 1.3f, this.transform.position.y));

            Debug.Log(Rayup.collider.tag);
            Debug.Log(Raydown.collider.tag);
            Debug.Log(Rayleft.collider.tag);
            Debug.Log(Rayright.collider.tag);

            randomRay = Random.Range(1, 5);
            Debug.Log(randomRay);

            if(randomRay == 1)
            {
                //Rayup = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.3f));

                if(Rayup.collider.tag == "Undestructable")
                {
                    DetectedDestructable(Rayup);
                    yield return null;
                }

                else if (Rayup.collider.tag == "Floor")
                {
                    Walk(Rayup);
                    yield return null;
                }

                //yield return null;
            }

            if(randomRay == 2)
            {
                //Raydown = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 1.2f), new Vector2(this.transform.position.x, this.transform.position.y - 1.3f));

                if (Raydown.collider.tag == "Undestructable")
                {
                    DetectedDestructable(Raydown);
                    yield return null;
                }

                else if (Raydown.collider.tag == "Floor")
                {
                    Walk(Raydown);
                    yield return null;
                }

                //yield return null;
            }

            if(randomRay == 3)
            {
                //Rayleft = Physics2D.Linecast(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y), new Vector2(this.transform.position.x + 1.3f, this.transform.position.y));

                if (Rayleft.collider.tag == "Undestructable")
                {
                    DetectedDestructable(Rayleft);
                    yield return null;
                }

                else if (Rayleft.collider.tag == "Floor")
                {
                    Walk(Rayleft);
                    yield return null;
                }

                //yield return null;
            }

            if(randomRay == 4)
            {
                //Rayright = Physics2D.Linecast(new Vector2(this.transform.position.x -1.2f, this.transform.position.y), new Vector2(this.transform.position.x - 1.3f, this.transform.position.y));

                if (Rayright.collider.tag == "Undestructable")
                {
                    DetectedDestructable(Rayright);
                    yield return null;
                }

                else if (Rayright.collider.tag == "Floor")
                {
                    Walk(Rayright);
                    yield return null;
                }

                //yield return null;
            }
            else
            {
                //yield return null;
            }
        }
    }

    void DetectedDestructable(RaycastHit2D Ray)
    {
        Debug.Log(Ray.collider.tag);
    }

    void Walk(RaycastHit2D Ray)
    {
        if (Ray == Rayright)
        {
            EnemyRigidBody.velocity += new Vector2(MoveSpeed, 0);
        }
        if (Ray == Rayleft)
        {
            EnemyRigidBody.velocity += new Vector2(-MoveSpeed, 0);
        }
        if (Ray == Rayup)
        {
            EnemyRigidBody.velocity += new Vector2(0, MoveSpeed);
        }
        if (Ray == Raydown)
        {
            EnemyRigidBody.velocity += new Vector2(0, -MoveSpeed);
        }
    }
}

//Coding AI

//Raycast 360 30 units (or something)
//Find nearest Crate and destroy it
//If powerup is detected, pick it up

//raycast 360 20 units (or something)
//If player spotted then chase/place a bomb

//LineCast 20 Units (or something)
//If bomb spotted then run away
