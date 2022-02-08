# This is the development branch of the AR application for the project CO<sub>2</sub>NLINE 🌐

## Aim 🏹
This app is supposed to augment our real world artifact using AR technology. It tracks the frontface of the artifact and projects a virtuall model onto it.
This model replaces the artifact and adds a user interface.
## Functionality 🦾
The augmented model will display the amount of carbon safed by the owner/user as bubble that float inside the artifact. Every day, a bubble whoms size represents the amount of safed carbon will be added to the collection. <br>
Users can decide to donate their safed carbon which is visualized by vines growing along the outside of the virtual artifact.
## Implementation 🖥️
The application is implemented using [Unity3D](www.unity3d.com) and C#. 
### Project structure 📂
#### Assets 
The assets folder contains all content specific to this project. Scripts, 3D-models, textures etc.
##### Prefabs 
Prefabs are reusable objects, that can be added into a unity scene muliple times using code or the unity editor. Here is our `AR-Boilderplate` containing ar camera, lighting and so on. Additionally, the augmented artifact model is contained in this folder. This is added to the scene as soon as the frontface of the real-world artifact is recognised.
##### Images 📷
This directory contains the image used for the tracking which is showing the frontface design.
##### Scenes 🗺️
Here you can find the scenes of the project. Main is the scene used for `production` and `testGround` is a scene used for development.
##### Sounds 📢
Sounds contains the sounds used for UI 🥳
