using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public int levelsComplete;
    // Start is called before the first frame update
    void Start()
    {
        levelsComplete = GameManager.Instance.levelsComplete;
    }

    // Update is called once per frame
    void Update()
    {
        levelsComplete = GameManager.Instance.levelsComplete;
    }

    void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Upgrade"))
        {
            if (levelsComplete == 0) {
                SceneManager.LoadSceneAsync("wave1");
            }
            else if(levelsComplete == 1) {
                SceneManager.LoadSceneAsync("wave2");
            }
            else if (levelsComplete == 2){
                SceneManager.LoadSceneAsync("wave3");
            }
            else if (levelsComplete == 3){
                SceneManager.LoadSceneAsync("Boss");
            }
        }
        else
        {
            if(GameManager.Instance.waveComplete)
            {
                SceneManager.LoadSceneAsync("Upgrade");
            }
        }
    }
    
}
