using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 minConstraints, maxConstraints;

    void Update()
    {
        //y-Axis movement
        if (player != null 
            && player.transform.position.x > minConstraints.x
            && player.transform.position.x < maxConstraints.x) 

        { transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z); }
        //x-Axis movement
        if (player != null
            && player.transform.position.y > minConstraints.y
            && player.transform.position.y < minConstraints.y)

        { transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); }
    }
}
