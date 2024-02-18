using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer toRender;
    [SerializeField] private GameObject highlight1;
    [SerializeField] private GameObject highlight2;
    [SerializeField] private GameObject highlight3;
    [SerializeField] private GameObject highlight4;
    public Vector2 tilePos1;
    public Vector2 tilePos2;
    public Vector2 tilePos3;
    public Vector2 tilePos4;
    [SerializeField] private bool isOccupied = false;
    [SerializeField] private bool playerHovering1 = false;
    [SerializeField] private bool playerHovering2 = false;
    [SerializeField] private bool playerHovering3 = false;
    [SerializeField] private bool playerHovering4 = false;
    public GameObject dropperController1;
    public GameObject dropperController2;


    public void Awake()
    {
        dropperController1 = GameObject.Find("PlayerDropper");
        dropperController2 = GameObject.Find("PlayerDropper2");
    }

    public void Init(bool isOffset)
    {
        toRender.color = isOffset ? offsetColor : baseColor;
    }

    private void Update()
    {
        if(playerHovering1 && !isOccupied)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Instantiate(dropperController1.GetComponent<DropperController>().selectedObject, new Vector3(tilePos1.x,tilePos1.y), Quaternion.identity);
                isOccupied = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDropper1"))
        {
            highlight1.SetActive(true);
            tilePos1 = new Vector2(this.transform.position.x, this.transform.position.y);
            playerHovering1 = true;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper2"))
        {
            highlight2.SetActive(true);
            tilePos2 = collision.transform.position;
            playerHovering2 = true; 
        }
        else if (collision.gameObject.CompareTag("PlayerDropper3"))
        {
            highlight3.SetActive(true);
            tilePos3 = collision.transform.position;
            playerHovering3 = true;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper4"))
        {
            highlight4.SetActive(true);
            tilePos4 = collision.transform.position;
            playerHovering4 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDropper1"))
            { 
            highlight1.SetActive(false);
            playerHovering1 = false;
            }
        else if (collision.gameObject.CompareTag("PlayerDropper2"))
        {
            highlight2.SetActive(false);
            playerHovering2 = false;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper3"))
        {
            highlight3.SetActive(false);
            playerHovering3 = false;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper4"))
        {
            highlight4.SetActive(false);
            playerHovering4 = false;
        }
    }
    public Vector2 getTilePos1()
    {
        return tilePos1;
    }
    public Vector2 getTilePos2()
    {
        return tilePos2;
    }
    public Vector2 getTilePos3()
    {
        return tilePos3;
    }
    public Vector2 getTilePos4()
    {
        return tilePos4;
    }
}
