using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMovement : MonoBehaviour
{
    Rigidbody2D rb;
    int x;
    int y;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(transform.position.y<2){
            y = 5;
        }
        else{
            y = 3;
        }
        if(transform.position.x<0){
            x = 2;
        }
        else{
            x = -2;
        }
        rb.AddForce(new Vector2(x,y), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
