using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleWall : MonoBehaviour
{
    [SerializeField]
    GameObject wall;

    private void OnCollisionEnter(Collision collision) //sending info to wall controller
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wall.GetComponent<WallController>().UnFreeze();
        }
    }
}
