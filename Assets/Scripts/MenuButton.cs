using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public Stages[] buttons = new Stages[6];

    Vector3 mousePreviousPOS = Vector3.zero;
    bool track;
    int selected = 0;

    private float pressTime,startTime,endTime;
    // Start is called before the first frame update
    void Start()
    {
        pressTime = 0f; 
        startTime = 0f;
        endTime = 0f;
        selected = 0;
        track = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startTime  = Time.time;
            
            
        }
        if(Input.GetMouseButton(0)){
            pressTime += Time.deltaTime;
            print(pressTime);
            if(pressTime > 0.1f){
                print("isTrack");
                track = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            endTime = Time.time;
            if(endTime - startTime < 0.1f){
                for(int i = 0; i < buttons.Length; i++){
                    if(i == selected && buttons[i].stageName != ""){
                        SceneManager.LoadScene(buttons[i].stageName); 
                    }
                }
            }
            track = false;
        }

        if(track == true){
            TrackMouse();
        }

    }

    void TrackMouse()
    {
        float difference = Input.mousePosition.x - mousePreviousPOS.x;
        if (Mathf.Abs(difference) > 10)
        {
            if (onSelected >= 0 && onSelected <= 5)
            {
                if (difference > 0 && onSelected < 5)
                    onSelected++;
                if (difference < 0 && onSelected > 0)
                    onSelected--;
            }
            for (int i = 0; i < buttons.Length; i++)
                buttons[i].isSelected = false;  //return all seleted to zero

            buttons[onSelected] = true;
            transform.rotation = Quaternion.Euler(0, 0, buttons[onSelected].angle);
            // if(Mathf.Cos(Mathf.Deg2Rad*transform.eulerAngles.z) > Mathf.Cos(Mathf.Deg2Rad*16) ) 
            // {
            //     transform.Rotate(0f,0f,-5f*Mathf.Sign(difference),Space.World);
            // }
        }
        mousePreviousPOS = Input.mousePosition;

    }


}
