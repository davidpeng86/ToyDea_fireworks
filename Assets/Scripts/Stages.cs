using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stages : MonoBehaviour
{
    // Start is called before the first frame update
    public int stageNum;
    public int angle;
    bool isPlaying = false;
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
            if(!isPlaying){
                isPlaying = true;
                FindObjectOfType<AudioManager>().play("Geta");
            }
        }
        else{
            isPlaying = false;
            transform.localScale = Vector3.one;
        }
    }
}
