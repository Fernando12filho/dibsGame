using System.Collections;
using System.Collections.Generic;
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

    public void Init(bool isOffset)
    {
        toRender.color = isOffset ? offsetColor : baseColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayerDropper1"))
            highlight1.SetActive(true);
        if (collision.gameObject.CompareTag("PlayerDropper2"))
            highlight2.SetActive(true);
        if (collision.gameObject.CompareTag("PlayerDropper3"))
            highlight3.SetActive(true);
        if (collision.gameObject.CompareTag("PlayerDropper4"))
            highlight4.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerDropper1"))
            highlight1.SetActive(false);
        if (collision.gameObject.CompareTag("PlayerDropper2"))
            highlight2.SetActive(false);
        if (collision.gameObject.CompareTag("PlayerDropper3"))
            highlight3.SetActive(false);
        if (collision.gameObject.CompareTag("PlayerDropper4"))
            highlight4.SetActive(false);
    }
}
