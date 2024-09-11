using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CreditControl : MonoBehaviour
{
    
    public UnityEngine.UI.Button MainMenu;
    

    void Start()
    {
        
        EventSystem.current.SetSelectedGameObject(MainMenu.gameObject);
    }

    void Update(){
        //checks for exit application
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
    }



    

    public void HandleSelect(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            selectButton();
        }
    }
    void selectButton(){
        //Open assigned menu
        MainMenu.GetComponent<ButtonExecute>().selected();
    }
}
