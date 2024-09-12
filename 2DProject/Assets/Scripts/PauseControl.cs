using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class PauseControl : MonoBehaviour
{
    public int selection = 0;
    public UnityEngine.UI.Button resume, main, quit;
    public GameObject gm;
    private PlayerInput playerInput;
    public TMP_Text text;
    
    
    void Start()
    {
        
        select();
    }

    
    
    void select(){
        if(selection == 0){
            EventSystem.current.SetSelectedGameObject(resume.gameObject);
        } else if(selection == 1){
            EventSystem.current.SetSelectedGameObject(main.gameObject);
        } else if(selection == 2){
            EventSystem.current.SetSelectedGameObject(quit.gameObject);
        }

        
    }

    //menu navigation split up by direction
    public void HandleRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (selection < 2){
                ++selection;
            } else{
                selection = 0;
                
            }
            select();
        }
        
    }

    public void HandleLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (selection > 0){
                --selection;
            } else{
                selection = 2;
                
            }
            select();
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
        if(selection == 0){
            gm.GetComponent<GameManager>().unpause();
        } else if(selection == 1){
            main.GetComponent<PauseButtons>().selected();
        } else if(selection == 2){
            quit.GetComponent<PauseButtons>().selected();
        }
    }
}
