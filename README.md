# CO<sub>2</sub>NLINE App 🌐 :phone:
This app is supposed to augment our real world artifact using AR technology. 
## Contents
- [Description](#description-pen)
- [Project Structure](#project-structure-)
- [Instalation](#installation-computer)
- [Usage](#usage)
- [License](#license)
## Description :pen:
### Base Project
This application belongs to the CO<sub>2</sub>NLINE project which was created and implemented as part of the [coding IxD](https://www.codingixd.org) lecture of the [FU Berlin](https://www.fu-berlin.de) and the [KH Weissensee](https://www.kh-berlin.de). The topic of was `Digital Souveranity`. CO<sub>2</sub>NLINE is an artefact that visualizes one's digital carbon footprint. 
### Aim 🏹
This app is supposed to augment a real world artefact using AR technology. It tracks the frontface of the artefact and projects a virtuall model onto it.
This model replaces the artifact and adds a user interface. 
### Functionality 🦾
The augmented model will display the amount of carbon safed by the owner/user as bubble that float inside *the* artefact. Every day, a bubble whose size represents the amount of safed carbon will be added to the collection. <br>
Users can decide to donate their safed carbon which is visualized by abstract vines growing along the outside of the virtual artefact. For an exhibition a tour is implemented that guids users through the functionaliy of the app.
### Implementation 🖥️
The application is implemented using [Unity3D](www.unity3d.com) and C#. Unity3D comes with a feature rich AR module and makes it easy to build apps for iOS and Android devices with the same codebase.<br>
3D objects are aranged in the Unity3D editor. Interactivity and custom functionality is added through C# scripts attached to these objects. For animation the [DOTween Library](http://dotween.demigiant.com/documentation.php) was used.
## Project structure 📂
### Assets 
The assets folder contains all content specific to this project. Scripts, 3D-models, textures etc.
#### Prefabs 
Prefabs are reusable objects, that can be added into a unity scene muliple times using code or the unity editor. Here is our `AR-Boilderplate` containing ar camera, lighting and so on. Additionally, the augmented artifact model is contained in this folder. This is added to the scene as soon as the frontface of the real-world artifact is recognised.
#### Images 📷
This directory contains the image used for the tracking which is showing the frontface design.
#### Scenes 🗺️
Here you can find the scenes of the project. Main is the scene used for `production` and `testGround` is a scene used for development.
#### Sounds 📢
Sounds contains the sounds used for UI 🥳
## Installation :computer:
**!! This code is only usable with a working Unity3D installation !!**<br>
Note: If you have never used unity, consider doing these [turorials](https://learn.unity.com)
1. Install [Unity3D](https://unity3d.com/de/get-unity/download). This project was build using version `2021.2.8f1`
2. `git clone https://github.com/Carbon-Online/ar_application.git`
3. Open the project in unity, it takes Unity a while to install all necessary modules.
## Usage
You can:
1. build the project onto your device
2. jump into the code using your favourite texteditor
3. jump into the Unity Editor and tinker around with the 3D models.
## Acknowledgements
Programming: Simon Sasse<br>
3D-Design: Youran Song<br>
UI-Design: Youran Song

## License
MIT License

Copyright (c) 2022 Simon Sasse

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.