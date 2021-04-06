using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Painel;
    public bool isPaused = false;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    //botão de pause 
    public GameObject panelPause;
    public void PauseControl() {
        
        if (Time.timeScale == 1 )
            
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
            panelPause.SetActive(false);
                
        }
    }
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void Menu() {
       // Application.LoadLevel(0);
    
    }
}
