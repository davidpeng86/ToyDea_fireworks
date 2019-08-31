using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class firework : MonoBehaviour
{
    ScoreTracker scoreTracker;
    Rigidbody2D body;
    Transform transformedCamera;
    bool canExplode = true;
    [SerializeField]
    public GameObject blast;
    SpriteRenderer starRenderer;
    Sequence s ;
    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence();
        ZoomTrigger.zoomReady = true;
        scoreTracker = FindObjectOfType<ScoreTracker>();
        transformedCamera = Camera.main.transform;
        body = GetComponent<Rigidbody2D>();
        starRenderer = GetComponent<SpriteRenderer>();
        Shoot.shootNum ++;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y <= 0f && canExplode == true){

            //DOTween.CompleteAll();
            scoreTracker.reduceStars();
            s.Append(transformedCamera.DOShakePosition(0.2f,new Vector2(0.4f,0.6f),20,60)).OnComplete(() => 
                transformedCamera.position = Vector2.Lerp(transformedCamera.position,Vector2.zero,0.5f));
            transformedCamera.DOShakePosition(0.2f,new Vector2(0.4f,0.6f),20,60).OnComplete(() => 
                transformedCamera.transform.position = new Vector3(0,0,-10));
            transformedCamera.DOShakePosition(0.2f,new Vector2(0.4f,0.6f),20,60);
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
            starRenderer.color = Color.red;
            canExplode = false;
            Destroy(gameObject,3);
        }
    }
}
