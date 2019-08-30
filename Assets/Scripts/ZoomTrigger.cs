using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool zoomReady = true;
    void Start()
    {
        zoomReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(zoomReady){
            zoomReady = false;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime *= 0.2f;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= 5f;
    }
}
