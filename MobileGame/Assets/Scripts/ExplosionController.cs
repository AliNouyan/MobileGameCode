using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    int power;
    float SpawnTile = 1.275f;
    float LineMin = 1.25f;
    float LineMax = 1.3f;
    public ExplosionDirection Dir;
    public GameObject nextTile;
    public GameObject player;
    public GameObject Bomb;
    public GameObject BombTNT;
    GameObject BombTNTCheck;
    public GameObject ExplosionEnd;
    public Sprite IronCrate2;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        BombTNTCheck = GameObject.FindGameObjectWithTag("BombTNT");

        if (BombTNTCheck != null)
        {
            power = 2;
        }
        else
        {
            power = player.GetComponentInChildren<PlayerController>().power;
        }
        

        Debug.Log("power is " + power);

        bool StopUp = false;
        bool StopDown = false;
        bool StopLeft = false;
        bool StopRight = false;

        for (int count = 1; count < power; count++)
        {
            Debug.Log("Count is " + count);

            if (power - count == 1)
            {
                SpawnTile = count * SpawnTile;
                LineMin = count * LineMin;
                LineMax = count * LineMax;

                //Debug.Log("SpawnTile value is " + SpawnTile);

                if (Dir == ExplosionDirection.Up)
                {
                    if (StopUp == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + LineMin), new Vector2(this.transform.position.x, this.transform.position.y + LineMax));
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopUp = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopUp = true;
                        }
                        else
                        {
                            Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                        }
                    }        
                }

                if (Dir == ExplosionDirection.Down)
                {
                    if (StopDown == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - LineMin), new Vector2(this.transform.position.x, this.transform.position.y - LineMax));
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopDown = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopDown = true;
                        }
                        else
                        {
                            Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                        }
                    }    
                }

                if (Dir == ExplosionDirection.Left)
                {
                    if (StopLeft == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x - LineMin, this.transform.position.y), new Vector2(this.transform.position.x - LineMax, this.transform.position.y));
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopLeft = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopLeft = true;
                        }
                        else
                        {
                            Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                        }
                    }   
                }

                if (Dir == ExplosionDirection.Right)
                {
                    if (StopRight == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x + LineMin, this.transform.position.y), new Vector2(this.transform.position.x + LineMax, this.transform.position.y));
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopRight = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopRight = true;
                        }
                        else
                        {
                            Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        }
                    }
                }

                SpawnTile = 1.275f;
                LineMin = 1.25f;
                LineMax = 1.3f;
            }
            else
            {

                SpawnTile = count * SpawnTile;
                LineMin = count * LineMin;
                LineMax = count * LineMax;

                //Debug.Log("SpawnTile value is " + SpawnTile);
                if (Dir == ExplosionDirection.Up)
                {
                    if (StopUp == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + LineMin), new Vector2(this.transform.position.x, this.transform.position.y + LineMax));
                        //Debug.Log(WallCheck.collider.name);
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            StopUp = true;
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                            StopUp = true;
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopUp = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopUp = true;
                        }
                        else
                        {
                            Instantiate(nextTile, new Vector3(this.transform.position.x, this.transform.position.y + SpawnTile, -0.5f), Quaternion.Euler(0, 0, 270));
                        }
                    }
                }

                if (Dir == ExplosionDirection.Down)
                {
                    if (StopDown == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - LineMin), new Vector2(this.transform.position.x, this.transform.position.y - LineMax));
                        //Debug.Log(WallCheck.collider.name);
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            StopDown = true;
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                            StopDown = true;
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopDown = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                        }
                        else
                        {
                            Instantiate(nextTile, new Vector3(this.transform.position.x, this.transform.position.y - SpawnTile, -0.5f), Quaternion.Euler(0, 0, 90));
                        }
                    }  
                }

                if (Dir == ExplosionDirection.Left)
                {
                    if (StopLeft == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x - LineMin, this.transform.position.y), new Vector2(this.transform.position.x - LineMax, this.transform.position.y));
                        //Debug.Log(WallCheck.collider.name);
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            StopLeft = true;
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                            StopLeft = true;
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopLeft = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopLeft = true;
                        }
                        else
                        {
                            Instantiate(nextTile, new Vector3(this.transform.position.x - SpawnTile, this.transform.position.y, -0.5f), new Quaternion());
                        }
                    }
                }

                if (Dir == ExplosionDirection.Right)
                {
                    if (StopRight == false)
                    {
                        RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x + LineMin, this.transform.position.y), new Vector2(this.transform.position.x + LineMax, this.transform.position.y));
                        //Debug.Log(WallCheck.collider.name);
                        if (WallCheck.collider.tag == "Undestructable")
                        {
                            StopRight = true;
                            //Debug.Log("This block cannot be destroyed");
                        }
                        else if (WallCheck.collider.tag == "WoodCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                            //Debug.Log("Found Crate");
                            Destroy(WallCheck.transform.gameObject);
                            StopRight = true;
                        }
                        else if (WallCheck.collider.tag == "IronCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            bool IronStatus = WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus;
                            if (IronStatus == false)
                            {
                                WallCheck.transform.gameObject.GetComponent<IronCrateStatus>().IronStatus = true;
                            }
                            else
                            {
                                Destroy(WallCheck.transform.gameObject);
                            }
                            StopRight = true;
                        }
                        else if (WallCheck.collider.tag == "TNTCrate")
                        {
                            GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                            GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                            //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                            Destroy(WallCheck.transform.gameObject);
                            StopRight = true;
                        }
                        else
                        {
                            Instantiate(nextTile, new Vector3(this.transform.position.x + SpawnTile, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        }
                    }
                }

                SpawnTile = 1.275f;
                LineMin = 1.25f;
                LineMax = 1.3f;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

public enum ExplosionDirection
{
    Up, Down, Left, Right
}
