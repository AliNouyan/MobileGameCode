using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed;
    public int power;
    public GameObject Bomb;
    public GameObject BombReset;
    public Transform Player;
    GameObject PlayerPrefab;
    float VelocityX;
    float VelocityY;
    //Refill time = ExplosionTime(from BombExplosion Script) + 0.2f 
    public float RefillTime = 3.7f;
    public int BombCapacity = 1;
    public int BombPlaced = 0;
    Rigidbody2D RigidBody;
    Vector3 Floor;
    FloorCollider floorCollider;
    public Collider2D col;
    Animator PlayerAnim;
    public int lives = 3;
    
	void Start ()
    {
        PlayerPrefab = GameObject.FindGameObjectWithTag("Player");
        RigidBody = PlayerPrefab.GetComponent<Rigidbody2D>();
        //Debug.Log("Bomb Power is " + power);
        col = this.GetComponent<BoxCollider2D>();
        PlayerAnim = this.GetComponent<Animator>();
	}
	
	void Update ()
    {
        VelocityX = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        VelocityY = CrossPlatformInputManager.GetAxisRaw("Vertical");

        //Move the player
        RigidBody.velocity += new Vector2(VelocityX * MoveSpeed, 0);
        RigidBody.velocity += new Vector2(0, VelocityY * MoveSpeed);

        if(VelocityX > 0.05)
        {
            PlayerAnim.Play("PlayerWalkingRight");
        }
        else if (VelocityX < -0.05)
        {
            PlayerAnim.Play("PlayerWalkingLeft");
        }
        else if (VelocityY > 0.05)
        {
            PlayerAnim.Play("PlayerWalkingUp");
        }
        else if (VelocityY < -0.05)
        {
            PlayerAnim.Play("PlayerWalkingDown");
        }
        else
        {
            //VelocityY = 0;
            //VelocityX = 0;
            PlayerAnim.Play("PlayerStill");
        }

        //Debug.Log(VelocityX + "," + VelocityY);

        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            //Debug.Log("Button Pressed");
            if (BombPlaced < BombCapacity)
            {
                //Pos = new Vector2(Player.position.x, Player.position.y);
                //float posX = (Pos.x / 50) + 25;
                //float posY = (Pos.y / 50) + 25;
                //Pos.x = posX;
                //Pos.y = posY;

                //Debug.Log("Button Press");
                Instantiate(Bomb, Floor, Player.rotation);

                BombPlaced++;
            }
        CrossPlatformInputManager.SetButtonUp("Fire1");
        }

        //floorCollider = gameObject.GetComponent<FloorCollider>();
        //floor = floorCollider.Floor;

        //Debug.Log(floor);
    }


    private void OnTriggerStay2D(Collider2D floor)
    {
        if (floor.gameObject.tag == "Floor")
        {
            Floor = new Vector3(floor.gameObject.transform.position.x, floor.gameObject.transform.position.y, -0.5f);
            //Debug.Log(Floor);
        }
    }

    private void OnTriggerEnter2D(Collider2D Death)
    {
        if (Death.gameObject.tag == "Explosion")
        {
            lives = lives - 1;
            Debug.Log(lives);
        }
    }
}
