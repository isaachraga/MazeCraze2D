using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public int num;
    //button controller for the pause menu buttons
    public void selected(){
        if(num == 0){

        } else if (num == 1){
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        } else{
            Application.Quit();
        }
    }
}
