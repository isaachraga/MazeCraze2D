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
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
        //playerInput = GetComponent<PlayerInput>();
        select();
    }

    // Update is called once per frame
    void Update()
    {

        //InputControlls();
        
        

        
    }
    void select(){
        if(selection == 0){
            EventSystem.current.SetSelectedGameObject(resume.gameObject);
        } else if(selection == 1){
            EventSystem.current.SetSelectedGameObject(main.gameObject);
        } else if(selection == 2){
            EventSystem.current.SetSelectedGameObject(quit.gameObject);
        }

        //text.text = selection.ToString();
        //Debug.Log("Select: "+selection);
    }

    public void HandleRight(InputAction.CallbackContext context)
    {
        //print(context.phase);

        /*if (context.performed)
        {
           // print("Attack performed");
        }
        else*/ if (context.started)
        {
            if (selection < 2){
                ++selection;
            } else{
                selection = 0;
                
            }
            select();
        }
        /*else if (context.canceled)
        {
            //print("Attack canceled");
        }*/
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
