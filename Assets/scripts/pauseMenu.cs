using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{

    public GameObject pausedMenu;

    public bool isPuased = false;
    // Start is called before the first frame update
    void Start()
    {
        pausedMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPuased){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausedMenu.SetActive(true);
        isPuased = true;
    }

    public void ResumeGame()
    {
        pausedMenu.SetActive(false);
        isPuased = false;
    }
}
