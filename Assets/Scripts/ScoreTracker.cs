using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private int stars;
    public Image star1, star2, star3, hasStar, noStar, oneStarDog, twoStarDog, threeStarDog, starDog;
    public GameObject canvas;
    private bool isFinish = false;
    // Start is called before the first frame update
    void Start()
    {
        stars = 4;
        isFinish = false;

    }
    public void reduceStars()
    {
        if (stars > 0)
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
            canvas.SetActive(true);
            showScore();
        }
    }
    public void doFinish()
    {
        isFinish = true;
    }
    void showScore()
    {
        if (stars == 1)
        {
            //star1.color = Color.yellow;
            star1.sprite = hasStar.sprite;
            star3.sprite = star2.sprite = noStar.sprite;
            starDog.sprite = oneStarDog.sprite;
        }
        else if (stars == 2)
        {
            star2.sprite = star1.sprite = hasStar.sprite;
            star3.sprite = noStar.sprite;
            starDog.sprite = twoStarDog.sprite;
        }
        else if (stars == 3)
        {
            star1.color = Color.yellow;
            star3.sprite = star2.sprite = star1.sprite = hasStar.sprite;
            starDog.sprite = threeStarDog.sprite;
        }
        else
            return;
    }
}
