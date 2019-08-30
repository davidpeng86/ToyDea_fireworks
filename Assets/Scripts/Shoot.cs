using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab;

    public float force = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.parent = null;
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            //Destroy(obj,3);
        }
    }
}
