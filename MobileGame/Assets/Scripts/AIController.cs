using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    float movement = 0f;
    int moveLoop;
    bool moveBool = false;
    GameObject enemy;
    public GameObject Bomb;
    public float MoveSpeed;
    public LayerMask Ray;
    public GameObject[] RaycastCheckArray = new GameObject[4];
    //public List<tilerow> tilerow = new List<tilerow>();
    public GameObject[,] arena = new GameObject[13, 11];
    public GameObject[] test = new GameObject[13];
    //public GameObject[] collum = new;
    int random;
    RaycastHit2D NearCrate;
    Rigidbody2D EnemyRigid;
    Vector3 Floor;
    public int BombCapacity = 1;
    public int BombPlaced = 0;
    public GameObject ClosestCollection;
    public GameObject ArrayStart;

    // Use this for initialization
    void Start ()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyRigid = enemy.GetComponent<Rigidbody2D>();

        StartCoroutine(Loop());
        StartCoroutine(CheckMovement());
        
        enabled = false;

        //for (int p = 0; p < 13; p++)
        //{
        //    RaycastHit2D arenacheck = Physics2D.Linecast(new Vector2(ArrayStart.transform.position.x + (p * 1.26f), ArrayStart.transform.position.y), new Vector2(ArrayStart.transform.position.x + (p * 1.27f), ArrayStart.transform.position.y));
        //    test[p] = arenacheck.transform.gameObject;
        //}

        for (int z = 0; z < 11; z++)
        {
            for (int i = 0; i < 13; i++)
            {
                RaycastHit2D arenacheck = Physics2D.Linecast(new Vector2(ArrayStart.transform.position.x + (i * 1.26f), ArrayStart.transform.position.y - (z * 1.26f)), new Vector2(ArrayStart.transform.position.x + (i * 1.27f), ArrayStart.transform.position.y - (z * 1.27f)));
                arena[i, z] = arenacheck.transform.gameObject;
            } 
        }

        //test
        for (int l = 0; l < 10; l++)
        {
            int x = Random.Range(1, 13);
            int y = Random.Range(1, 11);
            Debug.Log(x + ", " + y + " = " + arena[x, y]);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (movement == 1f) //Walk to crate
        {
            //Debug.Log(NearCrate.transform.tag);

            if ((NearCrate.transform.tag != "WoodCrate") || (NearCrate.transform.tag != "IronCrate") || (NearCrate.transform.tag != "TNTCrate"))
            {
                if (random == 0)
                {
                    Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y + 0.4f), new Vector2(this.transform.position.x, this.transform.position.y + 0.41f), Color.red);
                    NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 0.4f), new Vector2(this.transform.position.x, this.transform.position.y + 0.41f));
                    EnemyRigid.velocity += new Vector2(0, 1 * MoveSpeed);
                }
                else if (random == 1)
                {
                    Debug.DrawLine(new Vector2(this.transform.position.x + 0.6f, this.transform.position.y), new Vector2(this.transform.position.x + 0.61f, this.transform.position.y), Color.red);
                    NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x + 0.6f, this.transform.position.y), new Vector2(this.transform.position.x + 0.61f, this.transform.position.y));
                    EnemyRigid.velocity += new Vector2(1 * MoveSpeed, 0);
                }
                else if (random == 2)
                {
                    Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y - 0.8f), new Vector2(this.transform.position.x, this.transform.position.y - 0.81f), Color.red);
                    NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 0.8f), new Vector2(this.transform.position.x, this.transform.position.y - 0.81f));
                    EnemyRigid.velocity += new Vector2(0, -1 * MoveSpeed);
                }
                else if (random == 3)
                {
                    Debug.DrawLine(new Vector2(this.transform.position.x - 0.6f, this.transform.position.y), new Vector2(this.transform.position.x - 0.61f, this.transform.position.y), Color.red);
                    NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x - 0.6f, this.transform.position.y), new Vector2(this.transform.position.x - 0.61f, this.transform.position.y));
                    EnemyRigid.velocity += new Vector2(-1 * MoveSpeed, 0);
                }
            }

            else
            {
                Loop();
            }

            if((NearCrate.transform.tag == "WoodCrate") || (NearCrate.transform.tag == "IronCrate") || (NearCrate.transform.tag == "TNTCrate"))
            {
                PlaceBomb();

                //movement = 0;
            }
        }

        if(movement == 2f) //Walking to collection point
        {
            //Debug.Log("move 2.1");
            if(ClosestCollection.name == "BombPickup")
            {
                Debug.DrawLine(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x - 1.25f, this.transform.position.y - 0.2f), Color.red);
                RaycastHit2D collectionPLeft = Physics2D.Linecast(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x - 1.25f, this.transform.position.y - 0.2f));
                Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.25f), Color.red);
                RaycastHit2D collectionPUp = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.25f));
                Debug.DrawLine(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x + 1.25f, this.transform.position.y - 0.2f), Color.red);
                RaycastHit2D collectionPRight = Physics2D.Linecast(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x + 1.25f, this.transform.position.y - 0.2f));
                Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y - 1.4f), new Vector2(this.transform.position.x, this.transform.position.y - 1.45f), Color.red);
                RaycastHit2D collectionPDown = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 1.4f), new Vector2(this.transform.position.x, this.transform.position.y - 1.45f));

                Debug.Log("Up " + collectionPUp.transform.tag);
                Debug.Log("Left " + collectionPLeft.transform.tag);
                Debug.Log("Down " + collectionPDown.transform.tag);
                Debug.Log("Right " + collectionPRight.transform.tag);

                //Debug.Log("move 2.2 " + movement);

                //EnemyRigid.velocity += new Vector2(0, 1 * MoveSpeed);

                //var smallCol = enemy.GetComponentInChildren<BoxCollider2D>();
                //var CollectionPointone = GameObject.Find("Collection Point Bomb 1").GetComponent<BoxCollider2D>();
                //var CollectionPointtwo = GameObject.Find("Collection Point Bomb 2").GetComponent<BoxCollider2D>();

                //if ((smallCol == CollectionPointone) || (smallCol == CollectionPointtwo))
                //{
                //    Loop();
                //}

                //if(this.transform.position ==  )

                float dist = Vector2.Distance(enemy.transform.position, ClosestCollection.transform.position);
                //Debug.Log(dist);

                if (dist <= 5.8)
                {
                    Debug.Log(dist);
                    BombPlaced = 0;
                    StartCoroutine(wait(1f));
                }

                if (collectionPUp.transform.tag == "WoodCrate")
                {
                    if ((collectionPLeft.transform.tag == "Undestructable") && (collectionPRight.transform.tag == "Undestructable"))
                    {
                        EnemyRigid.velocity += new Vector2(0, -1 * MoveSpeed);
                        //Debug.Log(EnemyRigid.velocity);
                    }
                }

                else if (collectionPUp.transform.tag == "Bomb")
                {
                    if ((collectionPLeft.transform.tag == "Undestructable") && (collectionPRight.transform.tag == "Undestructable"))
                    {
                        EnemyRigid.velocity += new Vector2(0, -1 * MoveSpeed);
                        //Debug.Log(EnemyRigid.velocity);
                    }
                    else if (collectionPLeft.transform.tag == "Floor")
                    {
                        EnemyRigid.velocity += new Vector2(-1 * MoveSpeed, 0);
                    }
                }

                else if ((collectionPLeft.transform.tag == "Undestructable") && (collectionPUp.transform.tag == "Undestructable"))
                {
                    EnemyRigid.velocity += new Vector2(-1 * MoveSpeed, 1 * MoveSpeed);
                }
                else if (collectionPLeft.transform.tag == "Undestructable")
                {
                    EnemyRigid.velocity += new Vector2(0, 1 * MoveSpeed);
                }
                else if (collectionPUp.transform.tag == "Undestructable")
                {
                    EnemyRigid.velocity += new Vector2(-1 * MoveSpeed, 0);
                }
                else if ((collectionPUp.transform.tag == "Undestructable") && (collectionPLeft.transform.tag == "Undestructable"))
                {
                    EnemyRigid.velocity += new Vector2(1 * MoveSpeed, 0);
                }
                else if ((collectionPUp.transform.tag == "WoodCrate") && (collectionPLeft.transform.tag == "Undestructable") && (collectionPRight.transform.tag == "Undestructable"))
                {
                    EnemyRigid.velocity += new Vector2(0, -1 * MoveSpeed);
                }
                else
                {
                    EnemyRigid.velocity += new Vector2(0, 1 * MoveSpeed);
                }
            }


            else if (ClosestCollection.name == "BombPickup-Enemy")
            {
                Debug.DrawLine(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x - 1.25f, this.transform.position.y - 0.2f), Color.red);
                RaycastHit2D collectionPLeft = Physics2D.Linecast(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x - 1.25f, this.transform.position.y - 0.2f));
                Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.25f), Color.red);
                RaycastHit2D collectionPUp = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.25f));
                Debug.DrawLine(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x + 1.25f, this.transform.position.y - 0.2f), Color.red);
                RaycastHit2D collectionPRight = Physics2D.Linecast(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y - 0.2f), new Vector2(this.transform.position.x + 1.25f, this.transform.position.y - 0.2f));
                Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y - 1.4f), new Vector2(this.transform.position.x, this.transform.position.y - 1.45f), Color.red);
                RaycastHit2D collectionPDown = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 1.4f), new Vector2(this.transform.position.x, this.transform.position.y - 1.45f));

                //Debug.Log("Up " + collectionPUp.transform.tag);
                //Debug.Log("Left " + collectionPLeft.transform.tag);
                //Debug.Log("Down " + collectionPDown.transform.tag);
                //Debug.Log("Right " + collectionPRight.transform.tag);

                //Debug.Log("Hi");

                float dist = Vector2.Distance(enemy.transform.position, ClosestCollection.transform.position);
                //Debug.Log(dist);

                if (dist >= 5.55)
                {
                    //Debug.Log("Reset Bomb");
                    //Debug.Log(dist);
                    BombPlaced = 0;
                    StartCoroutine(wait(1f));
                }

                if ((collectionPLeft.transform.tag == "Undestructable") && (collectionPRight.transform.tag == "Undestructable") || (collectionPRight.transform.tag == "Undestructabe"))
                {
                    if (collectionPDown.transform.tag == "Floor" || collectionPDown.transform.tag == "BombPickup")
                    {
                        EnemyRigid.velocity += new Vector2(0, -1 * MoveSpeed);
                    }

                    else if (collectionPUp.transform.tag == "Floor")
                    {
                        EnemyRigid.velocity += new Vector2(0, 1 * MoveSpeed);
                    }
                }

                else if ((collectionPUp.transform.tag == "Undestructable") && (collectionPDown.transform.tag == "Undestructable") || (collectionPDown.transform.tag == "Undestructable"))
                {
                    if (collectionPRight.transform.tag == "Floor" || collectionPRight.transform.tag == "BombPickup")
                    {
                        EnemyRigid.velocity += new Vector2(1 * MoveSpeed, 0);
                    }
                }

                else if ((collectionPRight.transform.tag == "Undestructable") && (collectionPDown.transform.tag == "Undestructable"))
                {
                    EnemyRigid.velocity += new Vector2(1 * MoveSpeed, 0);
                }
            }


        }

        if(movement == 3f)
        {

        }
    }

    private void OnTriggerStay2D(Collider2D floor)
    {
        if (floor.gameObject.tag == "Floor")
        {
            Floor = new Vector3(floor.gameObject.transform.position.x, floor.gameObject.transform.position.y, -0.5f);
            //Debug.Log(Floor);
            //floor.gameObject.name 
        }

        
    }

    IEnumerator Loop()
    {
        yield return new WaitForSeconds(0.1f);

        RaycastCheck();
        Think();

        
    }

    public void RaycastCheck()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 15f, Ray);
        RaycastCheckArray[0] = hitUp.transform.gameObject;
        //Debug.Log(hitUp.transform.gameObject);

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 15f, Ray);
        RaycastCheckArray[1] = hitRight.transform.gameObject;
        //Debug.Log(hitRight.transform.gameObject);

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position, -Vector2.up, 15f, Ray);
        RaycastCheckArray[2] = hitDown.transform.gameObject;
        //Debug.Log(hitDown.transform.gameObject);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -Vector2.right, 15f, Ray);
        RaycastCheckArray[3] = hitLeft.transform.gameObject;
        //Debug.Log(hitLeft.transform.gameObject);
    }

    public void Think()
    {
        random = Random.Range (0, RaycastCheckArray.Length);

        //Debug.Log(random);

        //for(int i = 0; i < 4; i++)
        //{
        //    Debug.Log(RaycastCheckArray[i]);
        //}

        if ((RaycastCheckArray[random].transform.tag == "WoodCrate") || (RaycastCheckArray[random].transform.tag == "IronCrate") || (RaycastCheckArray[random].transform.tag == "TNTCrate"))
        {
            //Debug.Log("Test " + RaycastCheckArray[random]);
            FoundCrate();
        }

        if ((RaycastCheckArray[random].gameObject.tag == "Undestructable") && ((RaycastCheckArray[0].gameObject.tag != "Undestructable") || (RaycastCheckArray[1].gameObject.tag != "Undestructable") || (RaycastCheckArray[2].gameObject.tag != "Undestructable") || (RaycastCheckArray[2].gameObject.tag != "Undestructable")))
        {
            //Debug.Log("Hello");
            RepeatLoop();
        }

        if (RaycastCheckArray[random].gameObject.tag == "Bomb")
        {
            //Debug.Log("Hello");
            RepeatLoop();
        }
    }

    public void FoundCrate()
    {
        NearCrate = Physics2D.Linecast(this.transform.position, this.transform.position);

        if (random == 0)
        {
            Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y + 0.4f), new Vector2(this.transform.position.x, this.transform.position.y + 0.41f), Color.red);
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 0.4f), new Vector2(this.transform.position.x, this.transform.position.y + 0.41f));
        }
        else if(random == 1)
        {
            Debug.DrawLine(new Vector2(this.transform.position.x + 0.6f, this.transform.position.y), new Vector2(this.transform.position.x + 0.61f, this.transform.position.y), Color.red);
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x + 0.6f, this.transform.position.y), new Vector2(this.transform.position.x + 0.61f, this.transform.position.y));
        }
        else if(random == 2)
        {
            Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y - 0.8f), new Vector2(this.transform.position.x, this.transform.position.y - 0.81f), Color.red);
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 0.8f), new Vector2(this.transform.position.x, this.transform.position.y - 0.81f));
        }
        else if(random == 3)
        {
            Debug.DrawLine(new Vector2(this.transform.position.x - 0.6f, this.transform.position.y), new Vector2(this.transform.position.x - 0.61f, this.transform.position.y), Color.red);
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x - 0.6f, this.transform.position.y), new Vector2(this.transform.position.x - 0.61f, this.transform.position.y));
        }

        //Debug.Log(RaycastCheckArray[random]);

        enabled = true;
        movement = 1;
        //Update();
    }

    public void Movement()
    {
        //Debug.Log("Hello");
        //Debug.Log(random);
        //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, RaycastCheckArray[random].transform.position, 0.1f);

        if(random == 0)
        {
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 0.7f), new Vector2(this.transform.position.x, this.transform.position.y + 1f));
            EnemyRigid.velocity += new Vector2(1 * MoveSpeed, 0);
        }
        else if(random == 1)
        {
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x + 0.7f, this.transform.position.y), new Vector2(this.transform.position.x + 1f, this.transform.position.y));
            EnemyRigid.velocity += new Vector2(0, 1 * MoveSpeed);
        }
        else if (random == 2)
        {
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 0.7f), new Vector2(this.transform.position.x, this.transform.position.y - 1f));
            EnemyRigid.velocity += new Vector2(-1 * MoveSpeed, 0);
        }
        else if (random == 3)
        {
            NearCrate = Physics2D.Linecast(new Vector2(this.transform.position.x - 0.7f, this.transform.position.y), new Vector2(this.transform.position.x - 1f, this.transform.position.y));
            EnemyRigid.velocity += new Vector2(0, -1 * MoveSpeed);
        }

        FoundCrate();
    }

    public void PlaceBomb()
    {
        if(BombPlaced < BombCapacity)
        {
            movement = 0;
            //enabled = false;
            //Debug.Log("Hi");

            Instantiate(Bomb, Floor, new Quaternion());
            BombPlaced++;

            StartCoroutine(UpdateMapArray());
            GoToCollection();
        }

       else
        {
            movement = 0;
            GoToCollection();
        }
    }

    public void GoToCollection()
    {
        if (BombPlaced >= BombCapacity)
        {
            GameObject[] Collection = new GameObject[2];
            Collection = GameObject.FindGameObjectsWithTag("BombPickup");
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject point in Collection)
            {
                Vector3 diff = point.transform.position - position;
                float CurrentDistance = diff.sqrMagnitude;
                if (CurrentDistance < distance)
                {
                    closest = point;
                    distance = CurrentDistance;
                }
            }
            ClosestCollection = closest;

            //Debug.Log(ClosestCollection.name);
            //Debug.Log("Hi");

            //enabled = true;
            movement = 2;
            Update();
        }

        //enabled = true;
        //movement = 3;
        //Update();
    }

    public void RepeatLoop()
    {
        //if(enabled == true)
        //{
        //    enabled = false;
        //}

        StartCoroutine(Loop());
    }

    void OnTriggerEnter2D(Collider2D floor)
    {
    //    if (floor.gameObject.tag == "BombPickup")
    //    {
    //        Debug.Log("hey");
    //        BombPlaced = 0;
    //        StartCoroutine(wait());
    //    }
    } 

    IEnumerator wait(float wait)
    {
        yield return new WaitForSeconds(wait);
        movement = 0;
        StartCoroutine(Loop());
    } 

    IEnumerator CheckMovement()
    {
        Vector2 Before = enemy.transform.position;
        yield return new WaitForSeconds(3f);
        Vector2 After = enemy.transform.position;

        if(After == Before)
        {
            StartCoroutine(Loop());
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(CheckMovement());
    }
    
    IEnumerator UpdateMapArray()
    {
        yield return new WaitForSeconds(3.6f);

        for (int z = 0; z < 11; z++)
        {
            for (int i = 0; i < 13; i++)
            {
                RaycastHit2D arenacheck = Physics2D.Linecast(new Vector2(ArrayStart.transform.position.x + (i * 1.26f), ArrayStart.transform.position.y - (z * 1.26f)), new Vector2(ArrayStart.transform.position.x + (i * 1.27f), ArrayStart.transform.position.y - (z * 1.27f)));
                arena[i, z] = arenacheck.transform.gameObject;
            }
        }

        //test
        //for (int l = 0; l < 10; l++)
        //{
        //    int x = Random.Range(1, 13);
        //    int y = Random.Range(1, 11);
        //    Debug.Log(x + ", " + y + " = " + arena[x, y]);
        //}

    }
}
