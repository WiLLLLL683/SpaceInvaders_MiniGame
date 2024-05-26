# SpaceInvaders_MiniGame

Mini game module running completely in Unity UI space with Space Invaders-like gameplay.  

Main features:
- Custom physics for UI objects.
- Easy import into any project, thanks to modular structure.
- Easy gameplay expansion with more enemies and player behaviors, like movement and attack.

## Table of contents

- [Installation](#Installation)
  - [Requirements](#Requirements)
  - [Install manually (using .unitypackage)](#install-manually-using-unitypackage)
- [How to use](#How-to-use)
  - [Mini Game](#Mini-Game)
  - [PhysicsUI](#PhysicsUI)
- [Code stucture](#Code-stucture)
  - [Infrastructure](#Infrastructure)
  - [Actors](#Actors)
  - [Components](#Components)
  - [Config](#Config)
  - [UI](#UI)
- [Resources](#Resources)

<!-- ## How to play -->



## Installation

#### Requirements:

- Unity 2019.4+
- Input System
- TextMeshPro

#### Install manually (using .unitypackage):

1. Download the [SpaceInvaders_MiniGame.unitypackage](https://github.com/WiLLLLL683/SpaceInvaders_MiniGame/releases/latest/download/SpaceInvaders_MiniGame.unitypackage) 
file from latest release. 
2. Open SpaceInvaders_MiniGame.unitypackage.



## How to use

#### Mini Game

1. Add `Assets/SpaceInvader_MiniGame/Prefabs/MiniGame.prefab` to the Canvas on your scene.
2. Run the mini game with this code:
    ```csharp
    [SerializeField] private MiniGame miniGame;

    public void YourMethod()
    {
        miniGame.Enable();
    }
    ```

Open `Assets/SpaceInvader_MiniGame/Scenes/BasicScene.unity` to see an example.

#### PhysicsUI

1. Add gameObject with `PhysicsUI` component to the root of your scene. One `PhysicsUI` component should always be present on the scene.
2. Add `ColliderUI` component to a UI element (`RectTransform` required).
3. Subscribe to `OnCollisionEnter`, `OnCollisionStay` or `OnCollisionExit` to recieve events from `ColliderUI`.
4. (Optional) If you need rigid body behavior, add `RigidBodyUI` component to UI element (`ColliderUI` required).



## Code stucture

Since this is a mini-game and it should work in any context, the simplest possible design patterns were used.

#### Infrastructure

Entry point is `MiniGame` object. It starts the game and configures `StateMachine` to controll game flow.
Dependencies are resolved manualy in `InitState` and stored between states in simple `Container`.
>You can change game flow by modifying states or creating new one.

`Factories` create `Actors` and pass dependencies to them. All factories are inherited from generic `FactoryBase` class,
which registers actors on create and deregisters on actor killed. 

Input is handeled by `PlayerInput` class, which is wrapper over `InputActions`.
>To resieve input you need to subscribe to `PlayerInput` events.

#### Actors

`Actors` represent the active entities of the game. 
Each `Actor` is `MonoBehavior` controller that defines and connects `Components` to achieve the required behavior.
Some `Actors` could be controlled by `Managers`, for example `EnemyAI` coordinates all enemies to achieve synchronous actions.
>To create new `Actor` you need to create new `MonoBehavior` and new `Factory` for that `Actor`.

#### Components

Each `Component` is C# class with implementation of some action, for example Attack or Movement.
`Components` implement interfaces segregated by type of action. 
`Components` can be used in any `Actor`.
>To create new `Component` just implement some of existing interfases or create new one.

#### Config

Game configuration is made with `ScriptableObjects`.
There are separate `ScriptableObjects` for `MiniGame, Player, Levels, Enemies and EnemyAI` with settings and prefabs.
Settings of each `Component` type are distributed in separate serializable C# classes.
All configuration files are referensed by `MiniGame` object.
>To create different variants of `Actors` like `Enemies` or `Bullets` you need to create prefab with desired `Actor` script on it and drag it to appropriate `ScriptableObject`.

#### UI

The whole game takes place on one `GameScreen`. It displays name of the current level and control scheme.
Also it contains parent transforms and spawn points to spawn `Player` and `Enemies`.
>In case other game screens are created, `GameScreen` class could be reused.



## Resources

This assets were used in the project:
- [Galaxia 2D Space Shooter Sprite Pack #1](https://assetstore.unity.com/packages/2d/textures-materials/galaxia-2d-space-shooter-sprite-pack-1-64944) - for ship and bullet sprites.
- [Pixel Skies DEMO Background pack](https://assetstore.unity.com/packages/2d/environments/pixel-skies-demo-background-pack-226622) - for background images.


