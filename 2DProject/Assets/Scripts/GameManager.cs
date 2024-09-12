using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;





public class GameManager : MonoBehaviour
{
    //Game Vars
    int[,] Board;
    public int maxX = 50;
    public int maxY = 25;
    List<Tuple<int,int>> paths = new List<Tuple<int,int>>();
    Tuple<int,int> start = new Tuple<int,int>(-1,-1);
    Tuple<int,int> end = new Tuple<int,int>(-1,-1);
    Tuple<int,int> next = new Tuple<int,int>(-1,-1);
    Tuple<int,int> testing = new Tuple<int,int>(-1,-1);
    public GameObject wall, path, Player1, Player2, GameBoard, Tilemap, pauseMenu, startSprite;
    GameObject p1, p2;
    bool pause = false;

    //Score Vars
    int P1Score = 0;
    int P2Score = 0;
    public TMP_Text P1Sc, P2Sc;

    //Debug Vars

    [HideInInspector]
    //public float time = 1f;

    
    
    

    void Start()
    {
        Board = new int[maxX, maxY];
        Tilemap.SetActive(true);
        fillBoard();
        
        buildPaths();
        //printBoard();
        instantiateGameBoard();
    }

    void Update()
    {
        //checks for application quit
        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }
        //Pause check
        if (Input.GetKeyDown("backspace"))
        {
            unpause(); 
        }

        
    }
/*
    public void HandlePauseButton(){
        unpause(); 
    }*/

    public void unpause(){
        if(pause){
            pause = false;
            pauseMenu.SetActive(false);
        }else{
            pause = true;
            pauseMenu.SetActive(true);
        }
        p1.GetComponent<PlayerController>().pause = pause;
        p2.GetComponent<PlayerController>().pause = pause;
    }

    //Fills board with all wall pieces
    void fillBoard(){
        for(int i = 0; i < maxX; ++i){
            for(int j = 0; j < maxY; ++j){
                Board[i, j] = 0;
            }
        }
    }

    void printBoard(){
        string printer = "";
        
        for(int j = maxY-1; j >= 0; --j){
            for(int i = 0; i < maxX; ++i){
                printer += "[" + Board[i, j]+"]";
            }
            printer += "\n";
        }
        Debug.Log(printer);
    }

    void buildPaths(){
        
        int startLoc = UnityEngine.Random.Range(1,24);
        Tuple<int,int> p = new Tuple<int,int>(1,startLoc);
        paths.Add(p);
        Board[p.Item1, p.Item2] = 1;
        

        

        if (start.Item1 == -1 && start.Item2 == -1){
            start = p;
        }

        //build maze with depth first traversal
        //pick random direction if anydirections left
        //check for validity
        //remove direction
        //remove path
        
        while(paths.Count > 0){

            
            
            List<string> dir = new List<string>();
            dir.Add("Up");
            dir.Add("Down");
            dir.Add("Left");
            dir.Add("Right");

            int dirCount = dir.Count;

            //Check for next assigned space to check, if not use the first item in path array
            if (next.Item1 == -1 && next.Item2 == -1){
                testing = paths[0];
            } else{
                testing = next;
            }
            
            //check unitl valid direction or verify no directions(end of path)
            while(dirCount > 0){
                int dirNum = UnityEngine.Random.Range(0, dir.Count);
                
                if(dir[dirNum] == "Up"){
                    if(!checkValid(testing, 0, 1)){
                        dir.RemoveAt(dirNum);
                        
                    }else{
                        break;
                    }

                } else if(dir[dirNum] == "Down"){
                    if(!checkValid(testing, 0, -1)){
                        dir.RemoveAt(dirNum);
                    }else{
                        break;
                    }

                } else if(dir[dirNum] == "Left"){
                    if(!checkValid(testing, -1, 0)){
                        dir.RemoveAt(dirNum);
                    }else{
                        break;
                    }

                } else { //Right
                    if(!checkValid(testing, 1, 0)){
                        dir.RemoveAt(dirNum);
                    }else{
                        break;
                    }

                }
                dirCount = dir.Count;
                next = new Tuple<int,int>(-1,-1);
                if(paths.Count > 0){
                    if(testing == paths[0]){
                        paths.RemoveAt(0);
                    }
                }
            }
        }
    }

    //check is potential location is a valid place to put path
    bool checkValid(Tuple<int,int> check, int x, int y){
        int tempX = check.Item1+x;
        int tempY = check.Item2+y;
        
        //verifies potential exit to board
        //if not end and y is valid
        if(tempX == maxX-1 && (tempY != 0 || tempY != maxY-1)){
            if (end.Item1 == -1 && end.Item2 == -1){
                end = check;
                Board[tempX, tempY] = 1;
                return true;
            }
        }
        
        //checks for board bounds
        if(tempX >= maxX-1 || tempY >= maxY-1 || tempX == 0 || tempY == 0){
            
            return false;

        } else {

            //these validity checks based on previous path location(-: previous, x: potential)
            if (check.Item1 == tempX-1 && check.Item2 == tempY){
                // 0 0 0
                // - x 0
                // 0 0 0
                if(Board[tempX,tempY+1]==1 || Board[tempX,tempY-1]==1 || Board[tempX+1,tempY]==1 || Board[tempX+1,tempY+1]==1|| Board[tempX+1,tempY-1]==1){
                    
                    return false;
                }
                
            }
            else if (check.Item1 == tempX && check.Item2 == tempY-1){
                // 0 0 0
                // 0 x 0
                // 0 - 0
                if(Board[tempX,tempY+1]==1 || Board[tempX-1,tempY]==1 || Board[tempX+1,tempY]==1 || Board[tempX+1,tempY+1]==1|| Board[tempX-1,tempY+1]==1){
                    
                    return false;
                    
                }
            }
            else if (check.Item1 == tempX+1 && check.Item2 == tempY){
                // 0 0 0
                // 0 x -
                // 0 0 0
                if(Board[tempX,tempY+1]==1 || Board[tempX,tempY-1]==1 || Board[tempX-1,tempY]==1 || Board[tempX-1,tempY+1]==1|| Board[tempX-1,tempY-1]==1){
                    
                    return false;
                }
            }
            else{
                // 0 - 0
                // 0 x 0
                // 0 0 0
                if(Board[tempX-1,tempY]==1 || Board[tempX,tempY-1]==1 || Board[tempX+1,tempY]==1 || Board[tempX+1,tempY-1]==1|| Board[tempX-1,tempY-1]==1){
                   
                    return false;
                }
            }


            //if all tests pass, instantiate new path and add that path as the next locaiton to test
            Tuple<int,int> p = new Tuple<int,int>(tempX,tempY);
            paths.Add(p);
            next = p;
            Board[tempX, tempY] = 1;
            return true;

            
            
            
        }

    }

    void instantiateGameBoard(){
        //iterate through board and instatiate pieces
        for(int i = 0; i < maxX; ++i){
            for(int j = 0; j < maxY; ++j){
                if(Board[i,j] == 0){
                    Instantiate(wall, new UnityEngine.Vector3(i, j, -1), UnityEngine.Quaternion.identity, GameBoard.transform);
                } else{
                    Instantiate(path, new UnityEngine.Vector3(i, j, 0), UnityEngine.Quaternion.identity, GameBoard.transform);
                }
            }
        }

        p1 = Instantiate(Player1, new UnityEngine.Vector3(start.Item1, start.Item2, -1), UnityEngine.Quaternion.identity, GameBoard.transform);
        p1.GetComponent<PlayerController>().setPlayerNum(1);
        p2 = Instantiate(Player2, new UnityEngine.Vector3(start.Item1, start.Item2, -1), UnityEngine.Quaternion.identity, GameBoard.transform);
        p2.GetComponent<PlayerController>().setPlayerNum(2);

        Instantiate(startSprite, new UnityEngine.Vector3(start.Item1, start.Item2, -1), UnityEngine.Quaternion.identity, GameBoard.transform);
        

        
        
    }

    public void Score(string p){
        if(p == "Player1(Clone)"){
            ++P1Score;

            P1Sc.text = P1Score.ToString();
        }
        if(p == "Player2(Clone)"){
            ++P2Score;
            P2Sc.text = P2Score.ToString();
        }
        Resetboard();
    }

    public void Resetboard(){
        Tilemap.SetActive(false);
        foreach(Transform child in GameBoard.transform)
        {
            Destroy(child.gameObject);
        }
        start = new Tuple<int,int>(-1,-1);
        end = new Tuple<int,int>(-1,-1);

        fillBoard();
        buildPaths();
        instantiateGameBoard();
        Tilemap.SetActive(true);
    }

}
