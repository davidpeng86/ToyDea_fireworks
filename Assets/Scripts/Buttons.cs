using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    Scene scene;
    ScoreTracker scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        scoreTracker = (ScoreTracker)FindObjectOfType(typeof(ScoreTracker));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextStage(){
        scoreTracker.resetStar();
        if(scene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        SceneManager.LoadScene(scene.buildIndex+1, LoadSceneMode.Single);
    }
    public void Replay(){
        SceneManager.LoadScene(scene.buildIndex, LoadSceneMode.Single);
    }
    public void Home(){
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
