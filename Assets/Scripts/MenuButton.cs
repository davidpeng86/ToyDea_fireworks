using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public Stages[] buttons = new Stages[6];

    Vector3 mousePreviousPOS = Vector3.zero;
    bool track;
    int selected = 0;
    // Start is called before the first frame update
    void Start()
    {
        selected = 0;
        track = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            track = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            track = false;
        }
        if(track == true){
            TrackMouse();
        }   
        
    }

    void TrackMouse(){
        float difference = Input.mousePosition.x - mousePreviousPOS.x;
            if(Mathf.Abs(difference)> 10)
            {
                if(selected >= 0 && selected <= 5){
                    if(difference > 0 && selected < 5)
                            selected++;
                    if(difference < 0 && selected > 0)
                            selected--;
                }
                for(int i = 0; i < buttons.Length; i++){
                    if(i == selected){
                        buttons[i].isSelected = true;
                        transform.rotation = Quaternion.Euler(0,0,buttons[i].angle);
                    }
                    else{
                        buttons[i].isSelected = false;
                    }
                }
                // if(Mathf.Cos(Mathf.Deg2Rad*transform.eulerAngles.z) > Mathf.Cos(Mathf.Deg2Rad*16) ) 
                // {
                //     transform.Rotate(0f,0f,-5f*Mathf.Sign(difference),Space.World);
                // }
            }
            mousePreviousPOS = Input.mousePosition;
            
    }

    
}
