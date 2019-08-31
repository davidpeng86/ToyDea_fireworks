using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.position.x<=0){
            rb.AddForce(new Vector2(20,0));
        }
        else{
            rb.AddForce(new Vector2(-20,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
