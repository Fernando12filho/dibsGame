using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GroundBehavior : MonoBehaviour
{

    public Transform parent;
    private Vector3 offset = new Vector3(0,-0.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = parent.transform.position + offset;
    }
}
