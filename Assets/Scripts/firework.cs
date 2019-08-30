using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firework : MonoBehaviour
{
    Rigidbody2D body;
    public GameObject blast;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y <= 0f){
            blast.SetActive(true);
        }
    }
}
