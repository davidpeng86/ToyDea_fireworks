using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool zoomReady = true;
    Camera camera;
    bool enter;
    bool exit;
    void Start()
    {
        zoomReady = true;
        camera = Camera.main;
        enter = false;
        exit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(enter){
            //計時realtime並slerp至transform
            //zoom in
            enter = false;
        }

        if(exit){
            // slerp至(0,0)
            //zoom out
            exit = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(zoomReady){
            zoomReady = false;
            enter = true;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime *= 0.2f;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        exit = true;
        Time.timeScale = 1f;
        Time.fixedDeltaTime *= 5f;
    }
}
