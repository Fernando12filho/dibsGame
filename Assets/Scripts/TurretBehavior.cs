using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    private float timePassed;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireRate;

    private void Awake()
    {
        float timePassed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > fireRate)
        {
            Instantiate(bullet, transform.position, this.transform.rotation);
            timePassed = 0f;
        }
    }
}
