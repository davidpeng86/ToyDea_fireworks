using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Shoot : MonoBehaviour
{
    //public ScoreTracker scoreTracker;
    [SerializeField]
    GameObject prefab;
    public static int shootNum = 0;
    [SerializeField]
    float force = 10;
    Transform transformedCamera;
    // Start is called before the first frame update
    void Start()
    {
        transformedCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this->shootNum++;
            GameObject obj = Instantiate(prefab, transform);
            obj.transform.parent = null;
            transformedCamera.DOShakePosition(0.15f, new Vector2(0.2f, 0.6f), 6, 0);
            Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
    }
}
