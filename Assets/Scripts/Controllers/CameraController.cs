using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Character;
    Vector3 startPosition;
     

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Character.transform.position.x > startPosition.x)
        //{
        //    transform.position = new Vector3(Character.transform.position.x,
        //        transform.position.y, transform.position.z);
        //}
    
    }
}
