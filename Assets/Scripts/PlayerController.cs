using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;

public class PlayerController : MonoBehaviour
{   
    private InputSystemEditable playerControls;

    public float hitStrengthLow = 10f;
    public float hitStrengthMid = 15f;
    public float hitStrengthHigh = 20f;

    public Rigidbody2D playerRb;

    public CircleCollider2D playerCollider;
    public CircleCollider2D groundCollider;

    private bool doubleJump;
    public bool isGrounded;



    private void Awake()
    {
        playerControls = new InputSystemEditable();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable() 
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {   
        Vector2 move = playerControls.Player.Move.ReadValue<Vector2>();
        Debug.Log(isGrounded);

        if(isGrounded)
        {
            if(playerControls.Player.LowFire.triggered)
            {
                playerRb.AddForce(move * hitStrengthLow,ForceMode2D.Impulse);
            }
            if(playerControls.Player.MidFire.triggered)
            {
                playerRb.AddForce(move * hitStrengthMid,ForceMode2D.Impulse);
            }
            if(playerControls.Player.HighFire.triggered)
            {
                playerRb.AddForce(move * hitStrengthHigh,ForceMode2D.Impulse);
            }
        }
        else if(doubleJump)
        {
            if(playerControls.Player.LowFire.triggered)
            {
                playerRb.AddForce(move * hitStrengthLow,ForceMode2D.Impulse);
                doubleJump = false;
            }
            if(playerControls.Player.MidFire.triggered)
            {
                playerRb.AddForce(move * hitStrengthMid,ForceMode2D.Impulse);
                doubleJump = false;
            }
            if(playerControls.Player.HighFire.triggered)
            {
                playerRb.AddForce(move * hitStrengthHigh,ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Ground"))
        {
            isGrounded = true;
            doubleJump = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isGrounded = false;
    }
    
}


