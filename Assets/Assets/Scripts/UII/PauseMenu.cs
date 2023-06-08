using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public bool isActive = false;
    int currentScene;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        //if(pauseMenu != null)
        //    pauseMenu.SetActive(false);    
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.semillasMenuOpened)
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            isActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            isActive = false;
        }

    }

    
    public void ReturnToGame()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        isActive = false;
    }
    /*
    public void ChangeScene(string SceneName)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneName);
    }
    */
    public void GoToHub()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("HUB_HUB");

    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

}
