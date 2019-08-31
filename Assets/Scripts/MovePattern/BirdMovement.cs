using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.position.x<=0){
            transform.localScale = new Vector3(-1,1,1);
            rb.velocity = new Vector2(3,0);
        }
        else{
            transform.localScale = new Vector3(1,1,1);
            rb.velocity = new Vector2(-3,0);
        }

        if(transform.position.y<=2){
            rb.gravityScale = -0.1f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
