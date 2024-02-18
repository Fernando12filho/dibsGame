using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletRb;
    [SerializeField] private int bulletSpeed = 2;
    private float timeAlive = 0;
    [SerializeField] private float despawnTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * bulletSpeed;
        timeAlive += Time.deltaTime;
        if(timeAlive > despawnTime) 
        {
            Destroy(gameObject);
        }

    }
}
