# Shoot 'em Up Game
This is a game I made by myself in Unity, the built game is in the "Game" folder, whereas the code is in the .sln file.
![geym](https://github.com/user-attachments/assets/73af13ce-147f-4c26-8435-f8e81d209e8f)

## How to play
The game is quite simple, movement is omni-directional and done with the arrow keys, the gun is shot with "Space" and fires as fast as you can press, the goal is to get as many points as possible by destroying enemies, get hit 3 times and you will die. Upon death, you may restart the game and try again!
## How does it work?
The game, as previously mentioned, is created in Unity, utilizing their blank 2D game project, the game is fundamentally a collection of "Game Objects" which hold various parts and logic of the game, for example the "Main Camera" object holds what and where we can see, the "Player Plane" object holds the Sprite of the plane, a script for it's movement logic and so on.

Below is a screenshot of the object hierarchy:

![objects](https://github.com/user-attachments/assets/fb6a4159-1e6b-4fdd-a1a9-cd65b874f076)

Objects can be active, inactive, have sub-objects (children) and so on.

Below is the asset view where the various assets and scripts are kept, objects too can become assets which can then be reused:

![assets](https://github.com/user-attachments/assets/b079e20c-8bf8-41b5-b678-e4e04bcddef2)

There are various built-in functionalities in Unity which can greatly aid with development, such as sprite splicing.

Below is the inspector view for the player_plane object, it has many different components:

![inspector](https://github.com/user-attachments/assets/8b29d0f9-14b0-4878-bdcc-2a4df2c6167b)

Let's take a look at some code:

```
    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            myRigidbody.velocity = new Vector2(0, 0);
            return;
        }

        movementInput = new Vector2(horizontal, vertical);
        myRigidbody.velocity = movementInput * movementSpeed * Time.fixedDeltaTime;
    }
```
This is the move function found within the control script for the player_plane object, first;
1. Input.GetAxisRaw("Horizontal") and Input.GetAxisRaw("Vertical")
   - These functions retrieve the raw input values for horizontal and vertical axes. "Horizontal" typically refers to left/right movement (e.g., using a joystick or pressing the left right arrow keys). "Vertical" typically refers to up/down movement. The GetAxisRaw method returns values directly as -1, 0, or 1, which correspond to negative, neutral, or positive directions respectively.
2. Checking for no input:
   - The if statement checks if both horizontal and vertical inputs are zero, meaning no directional input is being provided. If both are zero, the GameObject's velocity is set to (0, 0), effectively stopping any movement. The return; statement exits the function early, so no further code in the function is executed.
3. Creating the movement vector:
   - movementInput is a Vector2 variable that stores the direction of movement based on the player's input. It combines the horizontal and vertical inputs into a single 2D vector. For example: (1, 0) would move the GameObject to the right. (0, 1) would move the GameObject up. (-1, -1) would move the GameObject diagonally down-left.
4. Applying movement to the Rigidbody:
   - myRigidbody is a reference to the Rigidbody2D component attached to the GameObject, velocity is a property that directly controls the speed and direction of the Rigidbody. The movementInput vector is multiplied by movementSpeed (a global value controlling how fast the GameObject should move) and Time.fixedDeltaTime. Time.fixedDeltaTime ensures that the movement speed is consistent across different frame rates. It represents the time interval between physics updates, making the movement frame-rate independent.
