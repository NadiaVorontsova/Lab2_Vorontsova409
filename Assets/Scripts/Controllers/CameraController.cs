using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject Character;
    //Vector3 startPosition;

    public Transform Player;

    public Transform CameraLeftWall;
    public Transform CameraRightWall;

  
    public float fovDefault = 90f;

    void Start()
    {
        //startPosition = transform.position;
    }

    void Update()
    {
        //transform.position = player.transform.position + new Vector3(0, 0, -5);

        if (transform.position.x > CameraLeftWall.position.x && transform.position.x < CameraRightWall.position.x) 
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, -5);

        }
        else if(transform.position.x < Player.position.x && transform.position.x <CameraLeftWall.position.x )
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, -5);

        }
        else if (transform.position.x > Player.position.x && transform.position.x > CameraRightWall.position.x)
        {
            transform.position = new Vector3(Player.position.x, transform.position.y, -5);

        }
   
       
        Debug.Log(Camera.main.orthographicSize);
        //Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
        //0.1
        //0
        //-0.1
        if (Camera.main.orthographicSize < 5 && Camera.main.orthographicSize > 1)
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");
        }
        else if (Camera.main.orthographicSize >= 5 && Input.GetAxis("Mouse ScrollWheel") == 0.1f)
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");

        }
        else if (Camera.main.orthographicSize <= 1 && Input.GetAxis("Mouse ScrollWheel") == -0.1f)
        {
            Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel");

        }

       
    }

}
