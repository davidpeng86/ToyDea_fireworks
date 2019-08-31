using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class firework : MonoBehaviour
{
    ScoreTracker scoreTracker;
    Rigidbody2D body;
    Transform camera;
    bool explode = true;
    [SerializeField]
    GameObject blast;
    SpriteRenderer renderer;
    Sequence s ;
    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        ZoomTrigger.zoomReady = true;
        scoreTracker = FindObjectOfType<ScoreTracker>();
        camera = Camera.main.transform;
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        Shoot.shootNum ++;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y <= 0f && explode == true){
            
            //DOTween.CompleteAll();
            s.Append(camera.DOShakePosition(0.2f,new Vector2(0.4f,0.6f),20,60)).OnComplete(() => 
            camera.position = Vector2.Lerp(camera.position,Vector2.zero,0.5f));
            
            scoreTracker.reduceStars();
            camera.DOShakePosition(0.2f,new Vector2(0.4f,0.6f),20,60).OnComplete(() => 
                camera.transform.position = new Vector3(0,0,-10));
            blast.SetActive(true);
            blast.transform.parent = null;
            Destroy(blast,3);            
            print(scoreTracker.getStars());
            Destroy(gameObject);
            scoreTracker.doFinish();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        scoreTracker.reduceStars();
        if(other.gameObject.tag == "obstacles"){
            renderer.color = Color.red;
            explode = false;
            Destroy(gameObject,3);
        }
    }
}
