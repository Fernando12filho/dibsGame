using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanBehavior : MonoBehaviour
{
    public int fanStrength;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player1") || other.CompareTag("Player2") || other.CompareTag("Player"))
            other.GetComponent<Rigidbody2D>().AddForce(transform.up * fanStrength, ForceMode2D.Force);
    }

}
