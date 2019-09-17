using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerStartMenu : MonoBehaviour
{

    public float MoveSpeed;
    public int power;
    public GameObject Bomb;
    public GameObject BombReset;
    public Transform Player;
    GameObject PlayerPrefab;
    float VelocityX;
    float VelocityY;
    public float RefillTime = 3.7f;
    public int BombCapacity = 1;
    public int BombPlaced = 0;
    Rigidbody2D RigidBody;
    Vector3 Floor;
    FloorCollider floorCollider;
    public Collider2D col;
    Animator PlayerAnim;


    void Start()
    {
        PlayerPrefab = GameObject.FindGameObjectWithTag("Player");
        RigidBody = PlayerPrefab.GetComponent<Rigidbody2D>();
        //Debug.Log("Bomb Power is " + power);
        col = this.GetComponent<BoxCollider2D>();
        PlayerAnim = this.GetComponent<Animator>();
    }

    void Update()
    {
        VelocityX = CrossPlatformInputManager.GetAxisRaw("Horizontal");

        //Move the player
        RigidBody.velocity += new Vector2(VelocityX * MoveSpeed, 0);

        if (VelocityX > 0.05)
        {
            PlayerAnim.Play("PlayerWalkingRight");
        }
        else if (VelocityX < -0.05)
        {
            PlayerAnim.Play("PlayerWalkingLeft");
        }
        else
        {
            //VelocityY = 0;
            //VelocityX = 0;
            PlayerAnim.Play("PlayerStill");
        }

        //Debug.Log(VelocityX + "," + VelocityY);

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
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

                StartCoroutine(ChangeScene());
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
            Debug.Log(Floor);
        }
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(3.5f);

        SceneManager.LoadScene("Main");
    }
}
