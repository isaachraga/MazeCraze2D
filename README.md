# MazeCraze2D
A recreation of the classic Maze Craze game built in Unity, featuring procedurally generated mazes using the Depth-First Search (DFS) algorithm, built for Intro to Game Design.

## Overview
This project is a 2D maze-based game developed in Unity, inspired by the classic Maze Craze arcade experience.
It was built to demonstrate a clear understanding of:

- Procedural content generation
- Graph traversal algorithms (Depth-First Search)
- Tile-based level design
- Player movement and collision in 2D space
- Unity’s component-based architecture
- Unity's Input manager for controller support
- Local 2-Player Multiplayer

Each playthrough generates a unique maze, ensuring replayability while preserving classic maze gameplay.

---

## Demo
- ![Multiplayer](MazeCraze2D/Demo/Demo1.gif)  

---

## Skills Demonstrated
- Unity 2D development
- Procedural maze generation
- Depth-First Search (DFS) algorithm implementation
- Grid-based data structures
- Player controller design
- Collision handling and level boundaries
- Game state management

---

## Architecture
The project is organized around modular gameplay systems:

### Maze Generator
Uses Depth-First Search to carve passages through a grid-based maze.

### Grid System
Represents each maze cell and its walls for traversal and rendering.

### Player Controller
Handles movement, input, and collision within the maze.

### Game Manager
Controls maze generation, holds the grid information, controls level resets, and win conditions.

---

## How to Run
### **Prerequisites**
- Unity Hub
- Unity 2D (2022.3 LTS version recommended)

### **Setup**
- Clone the repository
- Open the project in Unity Hub
- Load the MainMenu scene
- Plug in 2 controlers to play 2 Player, default is single player keyboard controls
- Press Play in the Unity Editor

--- 

## Controls
- W / A / S / D  — Move Player
- Arrow Keys — Move Player
- Controler D-Pad - Move Player
- Controller Left Stick - Move Player
- Backspace - Pause
- ESC — Exit to Editor

## Game Rules
- Navigate from the yellow start point to the maze exit
- Walls are impassable
- Each level generates a new maze layout
- Completing the maze ends the run or advances to a new maze

---

## Technologies Used
- Unity Engine (2D)
- C#
- Depth-First Search (DFS) algorithm
- Unity Tilemaps / Sprites
- Unity Animator

---

## Contact
**Isaac Hraga**
- GitHub: https://github.com/isaachraga
- LinkedIn: www.linkedin.com/in/isaac-hraga-5b7535b2
