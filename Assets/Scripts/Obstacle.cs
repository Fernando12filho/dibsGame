using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Obstacle : MonoBehaviour
{
    private bool isRespawning = false;
    Vector3 hitPosition;
    public float speed = 10.0f;
    private bool isStuck = false;
    private InputSystemEditable playerControl;
    private PlayerController playerController;

    [SerializeField] private Vector3 respawnPoint;

    [SerializeField] private Rigidbody2D playerRb;

    private void Awake()
    {
        playerControl = new InputSystemEditable();
        playerRb = new Rigidbody2D();
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

        if (isRespawning) 
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }




    //Detect 2d collision between player and spike, destroy player
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Spike")
        {
            gameObject.transform.position = respawnPoint;
            StartCoroutine(Respawning());
            
            //destroy player
            
        }

        //if player collides with 2d slime, player gets stuck and can't move for 2 seconds
        if (col.gameObject.tag == "Slime")
        {
            //player freezes for 2 seconds when colliding with slime and cant move 
            hitPosition = gameObject.transform.position;
            isStuck = true;
        }
    }

    IEnumerator Respawning()
    {
        isRespawning = true;  
        yield return new WaitForSeconds(2);
        isRespawning = false;
        
        
    }

    IEnumerator Stuck()
    {
        yield return new WaitForSeconds(2);
        isStuck = false;
    }

}
