using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour
{
    // Start is called before the first frame update
    public int stageNum;
    public int angle;

    public bool isSelected = false;
    
    void Start()
    {
        isSelected = false;
        if(stageNum == 0){
            isSelected = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected){
            transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            FindObjectOfType<AudioManager>().play("Geta");
        }
        else{
            transform.localScale = Vector3.one;
        }

        
    }
}
