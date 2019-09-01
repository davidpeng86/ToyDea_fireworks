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
    [SerializeField]
    GameObject blast;
    public static int shootNum = 0;
    [SerializeField]
    float force = 10;
    Transform camera;
    Sequence s ;

    public Animator doge;
    float timer = 0;
    float barkTime = 0f;
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
        if(Input.GetMouseButtonDown(0) && timer > coolDown)
        {
            //transform.DoMove().SetEase(Ease.)
            timer = 0;
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.parent = null;
            DOTween.CompleteAll();
            s.Append(
                camera.DOMove(new Vector3(0,0.5f,-10),0.05f,false).OnComplete(() =>
                camera.DOMove(new Vector3(0,0,-10),0.05f,false)));
            //     camera.DOShakePosition(0.15f,new Vector2(0.2f,0.6f),6,0)).OnComplete(() => 
            // camera.position = new Vector3(0,0,-10));
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            doge.SetTrigger("woof");
            barkTime = 0f;
            GameObject burst = Instantiate(blast, transform);
            Destroy(burst,1f);
        }
        timer += Time.deltaTime;
        barkTime += Time.deltaTime;
        if(timer<coolDown+1 && barkTime>1){
            barkTime = 0f;
            doge.SetTrigger("woof");
        }
        
    }
}
