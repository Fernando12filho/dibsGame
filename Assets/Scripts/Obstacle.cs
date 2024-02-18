using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Obstacle : MonoBehaviour
{

    Vector3 hitPosition;
    public float speed = 10.0f;
    private bool isStuck = false;
    private InputSystemEditable playerControl;
    private PlayerController playerController;

    private void Awake()
    {
        playerControl = new InputSystemEditable();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if (isStuck)
        {
            gameObject.transform.position = hitPosition;
            //lock rotation
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (gameObject.CompareTag("Player1"))
            {
                if (playerControl.Player1.LowFire.triggered || playerControl.Player1.MidFire.triggered || playerControl.Player1.HighFire.triggered)
                    isStuck = false;
            }
            else if(gameObject.CompareTag("Player2"))
            {
                if (playerControl.Player2.LowFire.triggered || playerControl.Player2.MidFire.triggered || playerControl.Player2.HighFire.triggered)
                    isStuck = false;
            }
        }
    }




    //Detect 2d collision between player and spike, destroy player
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            Debug.Log("Player hit obstacle: " + col.gameObject.name);
            //destroy player
            Destroy(gameObject);
        }

        //if player collides with 2d slime, player gets stuck and can't move for 2 seconds
        if (col.gameObject.tag == "Slime")
        {
            //player freezes for 2 seconds when colliding with slime and cant move 
            hitPosition = gameObject.transform.position;
            isStuck = true;
        }
    }

    IEnumerator Stuck()
    {
        yield return new WaitForSeconds(2);
        isStuck = false;
    }

}
