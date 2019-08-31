using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject spawnee;
    float timer = 0;
    int randTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        randTime = (int)Random.Range(1f,3f);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>=randTime){
            Spawn();
        }
    }
    void Spawn(){
        GameObject born = Instantiate(spawnee,transform);
        born.transform.parent = null;
        timer = 0;
        randTime = (int)Random.Range(3f,5f);
        Destroy(born,20);
    }
}
