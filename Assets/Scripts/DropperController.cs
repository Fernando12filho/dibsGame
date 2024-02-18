using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropperController : MonoBehaviour
{
    [SerializeField] private int playerNum;
    [SerializeField] private Rigidbody2D moverRb;
    public GameObject[] playerObstacles = new GameObject[6];
    public GameObject selectedObject;
    private int randSelect;

    private void Awake()
    {
        transform.position = new Vector2(0, 0);
        selectNewObject();
    }

    private void OnEnable()
    {
        selectNewObject();
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
        }
    }

    public void selectNewObject()
    {
        randSelect = Random.Range(0, 6);
        selectedObject = playerObstacles[randSelect];
        gameObject.GetComponent<SpriteRenderer>().sprite = selectedObject.GetComponent<SpriteRenderer>().sprite;
    }
}   
