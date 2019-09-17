using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class BombExplosion : MonoBehaviour {

    Animator anim;
    float ExplosionTime = 3.5f;
    public int power;
    public GameObject Explosion;
    public GameObject Bomb;
    public GameObject BombTNT;
    public BoxCollider2D physical;
    public GameObject Player;
    public GameObject ExplosionTile;
    public GameObject ExplosionEnd;
    Vector3 BombPos;

    // Use this for initialization
    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (this.gameObject.tag == "Bomb")
        {
            power = Player.GetComponentInChildren<PlayerController>().power;
        }
        else
        {
            power = 2;
        }
        

        //Debug.Log("Right after getting the float value power is " + power);

        anim = GetComponent<Animator>();
        anim.Play("Bomb Explosion");

        StartCoroutine(Explode());
        if(physical != null)
        {
            physical.enabled = false;
        }
        
        BombPos = new Vector3(Bomb.transform.position.x, Bomb.transform.position.y, -0.5f);

        
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerExit2D(Collider2D Player)
    {        
        if(physical != null)
        {
            physical.enabled = true;
        }
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(3.5f);

        //Debug.Log("Explosion");
        Instantiate(Explosion, BombPos, new Quaternion());
        //Destroy(Bomb);
        Explosion = this.gameObject;

        //power = Player.GetComponent<PlayerController>().BombPower;

        //Debug.Log("power value inside the IEnumerator is " + power);
        if (power == 1)
        {
            //Debug.Log(power);
            for (int count = 0; count <= 3; count++)
            {
                if (count == 0)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y + 1.2f), new Vector2(this.transform.position.x, this.transform.position.y + 1.4f));
                    //Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                    }
                }

                if (count == 1)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 1.2f), new Vector2(this.transform.position.x, this.transform.position.y - 1.4f));
                    //Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
                    }
                }

                if (count == 2)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y), new Vector2(this.transform.position.x - 1.4f, this.transform.position.y));
                    //Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
                    }
                }

                if (count == 3)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y), new Vector2(this.transform.position.x + 1.4f, this.transform.position.y));
                    //Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                    }
                }
            }
        }
        else
        {
            for (int count = 0; count <= 3; count++)
            {
                //Debug.Log(Explosion.transform.position);
                if (count == 0)
                {
                    //Debug.DrawLine(new Vector3(Explosion.transform.position.x, Explosion.transform.position.y, -0.7f), new Vector3(Explosion.transform.position.x, Explosion.transform.position.y + 1.275f, -0.7f));
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(Explosion.transform.position.x, Explosion.transform.position.y + 1.2f), new Vector2(Explosion.transform.position.x, Explosion.transform.position.y + 1.4f));
                    Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject Tile = Instantiate(ExplosionTile, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                        Tile.GetComponent<ExplosionController>().Dir = ExplosionDirection.Up;
                    }
                 
                    //GameObject Tile = Instantiate(ExplosionTile, new Vector3(this.transform.position.x, this.transform.position.y + 1.275f, -0.5f), Quaternion.Euler(0, 0, 270));
                    //Tile.GetComponent<ExplosionController>().Dir = ExplosionDirection.Up;
                }
                if (count == 1)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y - 1.2f), new Vector2(this.transform.position.x, this.transform.position.y - 1.4f));
                    //Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject Tile = Instantiate(ExplosionTile, new Vector3(this.transform.position.x, this.transform.position.y - 1.275f, -0.5f), Quaternion.Euler(0, 0, 90));
                        Tile.GetComponent<ExplosionController>().Dir = ExplosionDirection.Down;
                    }                       
                }
                if (count == 2)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x - 1.2f, this.transform.position.y), new Vector2(this.transform.position.x - 1.4f, this.transform.position.y ));
                    //Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject Tile = Instantiate(ExplosionTile, new Vector3(this.transform.position.x - 1.275f, this.transform.position.y, -0.5f), new Quaternion());
                        Tile.GetComponent<ExplosionController>().Dir = ExplosionDirection.Left;
                    }
                        
                }
                if (count == 3)
                {
                    RaycastHit2D WallCheck = Physics2D.Linecast(new Vector2(this.transform.position.x + 1.2f, this.transform.position.y), new Vector2(this.transform.position.x + 1.4f, this.transform.position.y));
                    //Debug.Log(WallCheck.collider.name);
                    if (WallCheck.collider.tag == "Undestructable")
                    {
                        //Debug.Log("This block cannot be destroyed");
                    }
                    else if (WallCheck.collider.tag == "WoodCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        //Debug.Log("Found Crate");
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else if (WallCheck.collider.tag == "IronCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
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
                    }
                    else if (WallCheck.collider.tag == "TNTCrate")
                    {
                        GameObject TileEnd = Instantiate(ExplosionEnd, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        GameObject bombTNT = Instantiate(BombTNT, new Vector3(WallCheck.transform.position.x, WallCheck.transform.position.y, -0.4f), new Quaternion());
                        //Debug.Log("Found Crate " + WallCheck.transform.gameObject);
                        Destroy(WallCheck.transform.gameObject);
                    }
                    else
                    {
                        GameObject Tile = Instantiate(ExplosionTile, new Vector3(this.transform.position.x + 1.275f, this.transform.position.y, -0.5f), Quaternion.Euler(0, 0, 180));
                        Tile.GetComponent<ExplosionController>().Dir = ExplosionDirection.Right;
                    }
                }
            }
        }

        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
