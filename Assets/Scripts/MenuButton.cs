using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public Stages[] buttons = new Stages[6];

    Vector3 mousePreviousPOS = Vector3.zero;
    bool track;
    int onSelected = 0;
    // Start is called before the first frame update
    void Start()
    {
        onSelected = 0;
        track = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            track = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            track = false;
        }
        if (track == true)
        {
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
