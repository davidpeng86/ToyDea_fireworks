using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private int stars;
    public Image star1, star2, star3;
    private bool isFinish = false;
    // Start is called before the first frame update
    void Start()
    {
        stars = 4;
        isFinish = false;
    
    }
    public void reduceStars()
    {
        if(stars > 0)
            stars -= 1;
    }
    public int getStars()
    {
        return stars;
    }
    // Update is called once per frame
    void Update()
    {
        if (isFinish)
        {
            showScore();
        }
    }
    public void doFinish()
    {
        isFinish = true;
    }
    void showScore()
    {
        if(stars == 1)
            star1.color = Color.yellow;
        else if(stars == 2)
            star1.color = star2.color = Color.yellow;
        else
            star3.color = star2.color = star1.color = Color.yellow;
    }
    
    //#E4E717
}
