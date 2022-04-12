# Loading Screen

Package with the premade functionality of an assynchronous loading screen for games.

# Getting started
## How to import the Package into your project

Import the package into your project following this guide: https://www.notion.so/Adding-a-Package-Unity-Package-to-a-new-Project-95e414ed08684e6898991db7885babb3

Go to the Package's folder and into Prefabs, and then drag the LoadingManager (Raw) prefab into the scene you wish to set as a Loading Manager:

![Unity_To7HLXa80y](https://user-images.githubusercontent.com/68963406/162973436-33add1ed-5c00-4745-b2ea-2e1fbb4a3a0f.png)

Now drag the same prefab contained into the Scene within the Assets directory, into a desired folder that contains prefabs, and then choose the option "Prefab Variant":
![Unity_0VGzyejs0X](https://user-images.githubusercontent.com/68963406/162973473-4b2d98be-debf-4c98-85b0-3098b1bc8bd5.png)

Considering that the Loading Manager should always be the first scene to be loaded in the Build Settings, you'll have to specify which scene(s) it needs to load afterwards:

![Pasted image 20220412101805](https://user-images.githubusercontent.com/68963406/162973529-e9195c19-e53f-4b67-9998-1a21136983e2.png)

## How to manage the Loading Manager

Now you'll be able to fiddle with the Loading Manager base as much as you want! There's a "Loading Effects Canvas" GameObject made specifically for visual effects within the UI. 

![Unity_d0H2Lvn22Q](https://user-images.githubusercontent.com/68963406/162973560-596e3d28-4c88-4278-8107-de02ff206de9.png)

You'll be able to control your LoadingScreen animations with the events on the LoadingManager which are: 

- LoadingScreenInitiated : Whenever the Loading Screen is called to load Scenes;
- LoadingScreenFinished: Whenever the scenes were totally loaded after calling the Loading Screen;
![Unity_Z7fNwoMk6J](https://user-images.githubusercontent.com/68963406/162973589-49309b46-28c6-46c7-9ee7-b60d52b9453a.png)

## How to manage Temporary Editor Loading Managers

The Loading Manager should be always the first scene to load in your build, however it's desired to be able to manage our scenes at the Editor without having to pass through LoadingManagers, which means we need to access the scenes directly while having a LoadingManager to handle loading between scenes as well.

With that in mind, you can create a "Temporary Loading Manager" scene that does not load anything when awoken, that way we can call it from any scene if there is no Loading Manager loaded in. Create the scene with the exactly same prefab from the Loading Manager:
![Pasted image 20220412102118](https://user-images.githubusercontent.com/68963406/162973782-b80474af-1a6e-4937-92c2-58d724beb972.png)

In this prefab (be sure to make modifications in the Scene, not in the prefab), uncheck the option "Call Main Scene At Awake":
![Pasted image 20220412102218](https://user-images.githubusercontent.com/68963406/162973808-da6e3ecf-9773-4a40-9dd8-91f671566cf3.png)


Now, in every scene that can be loaded, insert the game object "Loading Manager Caller" and add the Component "LoadingManagerCaller" and "SceneLoader":

Set Call On Awake to true in Loading Manager Caller, set the Scene Loader reference from the same GameObject and in the Scene Loader script set the Temporary Loading Manager scene as follows:

![Pasted image 20220412102438](https://user-images.githubusercontent.com/68963406/162973835-93e0ad28-6f67-4c18-8706-5a9fb66ecd1e.png)

And now, the scene should load the Temporary Loading Manager if there's no Loading Manager laying around!
![Unity_syJj4PbJEY](https://user-images.githubusercontent.com/68963406/162974991-1e4c10e6-e062-4b6c-8a42-294cdd93e00d.gif)
