using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject Player;
    private Vector3 Offset;

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;
    float PosX;
    float PosY;

    // Use this for initialization
    void Start () {
        Offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //Debug.Log(Mathf.Clamp(transform.position.x, MinX, MaxX));
        //Debug.Log(Mathf.Clamp(transform.position.y, MinY, MaxY));
        if(Player != null)
        {
            transform.position = Player.transform.position + Offset;

            Vector3 TargetPos = new Vector3();
            TargetPos.x = Mathf.Clamp(transform.position.x, MinX, MaxX);
            TargetPos.y = Mathf.Clamp(transform.position.y, MinY, MaxY);
            TargetPos.z = -2;

            transform.position = TargetPos;
        }
        
    }
}

