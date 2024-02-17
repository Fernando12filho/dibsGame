using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    //instantiate different obstacles objects, Slime and Spikes to start
    public GameObject slime;
    public GameObject spikes;

    Vector3 hitPosition;
    public float speed = 10.0f;

    private bool isStuck = false;


    // Update is called once per frame
    void Update()
    {
        if (isStuck)
        {
            gameObject.transform.position = hitPosition;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Player is now free to move");
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
