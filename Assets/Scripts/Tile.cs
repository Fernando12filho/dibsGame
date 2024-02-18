using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer toRender;
    [SerializeField] private GameObject highlight1;
    [SerializeField] private GameObject highlight2;
    [SerializeField] private GameObject highlight3;
    [SerializeField] private GameObject highlight4;
    public Vector2 tilePos1 = new Vector2();
    public Vector2 tilePos2 = new Vector2();
    public Vector2 tilePos3 = new Vector2();
    public Vector2 tilePos4 = new Vector2();

    public void Init(bool isOffset)
    {
        toRender.color = isOffset ? offsetColor : baseColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDropper1"))
        {
            highlight1.SetActive(true);
            tilePos1 = collision.transform.position;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper2"))
        {
            highlight2.SetActive(true);
            tilePos2 = collision.transform.position;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper3"))
        {
            highlight3.SetActive(true);
            tilePos3 = collision.transform.position;
        }
        else if (collision.gameObject.CompareTag("PlayerDropper4"))
        {
            highlight4.SetActive(true);
            tilePos4 = collision.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDropper1"))
            highlight1.SetActive(false);
        else if (collision.gameObject.CompareTag("PlayerDropper2"))
            highlight2.SetActive(false);
        else if (collision.gameObject.CompareTag("PlayerDropper3"))
            highlight3.SetActive(false);
        else if (collision.gameObject.CompareTag("PlayerDropper4"))
            highlight4.SetActive(false);
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
