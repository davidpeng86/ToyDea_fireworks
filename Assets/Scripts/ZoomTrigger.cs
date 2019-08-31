using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ZoomTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool zoomReady = true;
    Camera mainCamera;
    bool enter;
    bool exit;
    Sequence s ;
    void Start()
    {
        DOTween.useSmoothDeltaTime = true;
        s = DOTween.Sequence();
        zoomReady = true;
        mainCamera = Camera.main;
        enter = false;
        exit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enter == true)
        {
            //計時realtime並slerp至transform
            //zoom in
            DOTween.CompleteAll();
            mainCamera.transform.DOMove(new Vector3(transform.position.x,transform.position.y,-10), 0.3f, false);
            mainCamera.DOOrthoSize(2f,0.4f);
            enter = false;
        }

        if (exit == true)
        {
            // slerp至(0,0)
            //zoom out
            mainCamera.transform.DOMove(new Vector3(0,0, -10), 0.3f, false);
            mainCamera.DOOrthoSize(5f,0.5f).OnComplete(() => 
            DOTween.CompleteAll());
            exit = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (zoomReady == true && other.tag!="obstacles")
        {
            zoomReady = false;
            enter = true;
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime =Time.timeScale*0.02f;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag!="obstacles"){
            exit = true;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale*0.02f;
        }
    }
}
