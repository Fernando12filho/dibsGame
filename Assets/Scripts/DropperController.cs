using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperController : MonoBehaviour
{
    [SerializeField] private int playerNum;
    [SerializeField] private Rigidbody2D moverRb;

    private void Awake()
    {
        transform.position = new Vector2(1, 1);
    }

    private void Update()
    {

        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(7 * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-7 * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 7 * Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -7 * Time.deltaTime, 0);
        }
    }

}
