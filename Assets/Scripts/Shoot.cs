using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Shoot : MonoBehaviour
{
    public int coolDown = 4;
    //public ScoreTracker scoreTracker;
    [SerializeField]
    GameObject prefab;
    public static int shootNum = 0;
    [SerializeField]
    float force = 10;
    Transform camera;
    Sequence s ;

    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        s = DOTween.Sequence( );
        camera = Camera.main.transform;
        timer = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && timer>coolDown)
        {
            timer = 0;
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.parent = null;
            DOTween.CompleteAll();
            s.Append(camera.DOShakePosition(0.15f,new Vector2(0.2f,0.6f),6,0)).OnComplete(() => 
            camera.position = Vector2.Lerp(camera.position,Vector2.zero,0.5f));
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        timer += Time.deltaTime;

    }
}
