using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class firework : MonoBehaviour
{
    Rigidbody2D body;
    Transform transformedCamera;
    bool canExplode = true;
    [SerializeField]
    GameObject blast;
    SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        ZoomTrigger.zoomReady = true;
        transformedCamera = Camera.main.transform;
        body = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
        Shoot.shootNum ++;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y <= 0f && canExplode){
            transformedCamera.DOShakePosition(0.2f, new Vector2(0.4f, 0.6f), 20, 60);
            blast.SetActive(true);
            blast.transform.parent = null;
            if (Shoot.shootNum > 3 || Shoot.shootNum < 0)
                ScoreTracker.stars = 0;
            else
                ScoreTracker.stars = 4 - Shoot.shootNum;
            print(ScoreTracker.stars);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "obstacles"){
            canExplode = false;
            Destroy(gameObject, 3);
        }
    }
}
