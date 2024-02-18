using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperController : MonoBehaviour
{
    [SerializeField] private int playerNum;
    [SerializeField] private Rigidbody2D moverRb;
    private Tile tileManager;

    private void Awake()
    {
        transform.position = new Vector2(1, 1);
        tileManager = new Tile();
    }

    private void Update()
    {
        if (this.CompareTag("PlayerDropper1") || this.CompareTag("PlayerDropper3"))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(7 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-7 * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 7 * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, -7 * Time.deltaTime, 0);
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log(tileManager.getTilePos1());
            }
        }
        else if (this.CompareTag("PlayerDropper2") || this.CompareTag("PlayerDropper4"))
        {
                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += new Vector3(7 * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    transform.position += new Vector3(-7 * Time.deltaTime, 0, 0);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += new Vector3(0, 7 * Time.deltaTime, 0);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    transform.position += new Vector3(0, -7 * Time.deltaTime, 0);
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                Debug.Log(tileManager.getTilePos1());
            }
        }
    }
}   
