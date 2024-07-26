<div align="center">
    <h1>
        ARamsay
    </h1>
    <h4>
        <i>"Virtual Gordan Ramsay, but won't yell at you"</i>
    </h4>
    <table>
        <tr>
            <td align="center">
                <sub><b>Yifei Ning</b><br>
                    <sub><sub>y3ning@ucsd.edu</sub><br>
                    <sup>University of Caifornia, San Diego</sup></sub></sub>
            </td>
            <td align="center">
                <sub><b>Shutong Wu</b><br>
                    <sub><sub>shw087@ucsd.edu</sub><br>
                    <sup>University of Caifornia, San Diego</sup></sub></sub>
            </td>
        </tr>
        <tr>
            <td align="center">
                <sub><b>Run Huang</b><br>
                    <sub><sub>ruh010@ucsd.edu</sub><br>
                    <sup>University of Caifornia, San Diego</sup></sub></sub>
            </td>
            <td align="center">
                <sub><b>Lingshuang Kong</b><br>
                    <sub><sub>likong@ucsd.edu</sub><br>
                    <sup>University of Caifornia, San Diego</sup></sub></sub>
            </td>
        </tr>
    </table>
</div>
<h5>
    Build With:
</h5>
<a href="https://docs.unity3d.com/Manual/index.html">Unity</a> · <a href="https://developer.android.com/docs">Android Studio</a> · <a href="https://github.com/microsoft/MixedRealityToolkit-Unity">Mixed Reality Toolkit</a> · <a href="https://nodejs.org/en/docs/">Node.js</a><br>

## 1 Introduction and Demo

ARamsay is a HoloLens-based AR application designed to improve people's cooking/culinary learning experience. To give you a glimpse of how ARamsay works and its basic usage, here's a quick <a href="https://www.bilibili.com/video/BV1bR4y1W7h2">demo video</a>:

[![ARamsay-Demo-Cover](/Media/demo-cover.png)](https://www.bilibili.com/video/BV1bR4y1W7h2)

<i><small>*This is a 4-week-long course project for CSE 118 Ubiquitous Computing at UCSD.</small></i>

## 2 Motivation and Objective

Imagine yourself cooking in the kitchen, following the instructions in a recipe book or recipe app. With both hands wet and dirty, or occupied, you may not want to touch your phone screen just to check the next step of the recipe. Also, have you ever ran into a situation where you forgot to keep time and overcooked something, missed/mistaken certain ingredients, or even made a whole mess of your kitchen after the cooking? 

Yes, cooking could be a nightmare for beginners. Therefore, we had the idea of creating a tool that would make the cooking process more pleasant, relaxed and enjoyable. That's our primary motivation and here's what we wish to achieve:

- Keep the kitchen and users hygiene, by reducing physical contact with the environment.
- Present recipes to users in a more intuitive, interactive way.
- Real-time guidance for users, so they can learn and improve their cooking skills as they cook.
- Ensure the consistent quality of prepared meals.
- Recommend personalized recipes and meet people's dietary requirements.

## 3 Solution and Design

In this section, we are going to talk about the solution we proposed and the design ideas behind it.

### 3.1 Use HoloLens to show users recipes

To implement something that is contact-free, there weren't many available options: either through voice control or AR/VR glasses. We chose the latter because it seems more intuitive and easier to interact with. Eventually, we chose HoloLens over other AR/VR glasses based on two considerations: first being that we need to keep our users in the real world, rather than a fully virtualized scenario since our users are doing actual cooking in the real world, so there's no need for a Virtual-Reality support. The second is that HoloLens provides better hand-tracking and gesture recognition support for both developers and users.

We'll discuss more about the User-Interface (UI) in the next section.

### 3.2 Only use HoloLens as a display module

Considering HoloLens is heavy and users may not want to wear it for a long time. What's more, imagine a scenario where a user wants to find a recipe for dinner and get all the ingredients needed so HE/SHE could make a trip to the grocery store on HIS/HER way home. It would be impractical to have users wear a HoloLens in order to do all these jobs. 

Therefore, we moved the entire process of searching and selecting recipes to be done on a mobile/web app, with HoloLens only acting as a display and user gesture input module. In this way, we reduced the time users spend wearing HoloLens and enhance their experience of finding and selecting recipes.

### 3.3 Third-party API for recipe data

All recipe data comes from <a href="https://spoonacular.com/">spoonacular</a>.

### 3.4 Architecture

Between the HoloLens and the client-side application, we added another layer: an AWS server built with Node.js and Express framework to better manage the user system (in the future). The overall structure of ARamsay is shown below:

![Architecture](/Media/architecture.png)

### 3.5 Security

To elevate the data security of ARamsay, we deployed our server on AWS. AWS server can help us deal with data security:

- Scale Securely with Superior Visibility and Control: With AWS, we control where our data is stored, who can access it, and what resources our organization is consuming at any given moment. Fine-grain identity and access controls combined with continuous monitoring for near real-time security information ensure that the right resources have the right access at all times, wherever the information is stored.
- With AWS we can build on the most secure global infrastructure. All data flowing across the AWS global network that interconnects data centers and regions is automatically encrypted at the physical layer before it leaves secured facilities. Additional encryption layers exist as well; for example, all VPC cross-region peering traffic, and customer or service-to-service TLS connections

## 4 User Interface

### 4.1 HoloLens UI

All components in ARamsay are floatable and will follow your head movement by default, so they will always stay in the same position in users' viewpoint. Users could also fix components at a real-world coordinate by clicking the "stick" button on the top-bar of some components.

As shown in the Demo video above, the position and angle of all components in x, y and z axes are adjustable. Users can flip and adjust the components in any direction to find the most suitable viewing position.

### 4.2 Android UI

See <a href="https://github.com/ARamsay118/ARamsay-Android">here</a>

### 4.3 Interaction

The way users interact with ARamsay is of utmost importance for this project, as our original intention was to optimize the way users interact with recipe apps. Therefore, we've experimented with many gestures/hand-movements that allow users to navigate through the recipes in order to find the best gesture, notable ones including:

- "Pinch and drag"

  Users were required to pinch at the instruction panel and then drag it from one side to the other for at least 10 centimeters in order to turn pages. It may seems intuitive at first, but we soon found that it is not very accurate and reliable for HoloLens to recognize it, because of the complexity of this gesture ("pinch", "drag" and "release"). We didn't adopt it eventually.
  ![pinch-and-drag](/Media/1st%20version%20of%20holo.png)

- Button Clicking

  The most common and easy-to-learn interaction method. However, it is not always easy for users to target at a specific button then click it, so it is also not the most ideal way.
  ![click](/Media/2nd%20version%20of%20holo.png)

- Airtap

  Reflecting on the efforts we tried before, we further thought about whether users could perform just one action in a wide area so that they don't need to spend time finding and targeting a specific button while the gesture itself is also easy enough for HoloLens to recognize it. Then we came up with the Airtap gesture (As shown below). 

  ![airtap-gesture](/Media/air-tap-animation.gif)

  We drew a vertical line in the middle of users' view. "Airtap" on the left side would show the previous step and "Airtap" on the right side would show the next step. After experimenting, we found that this is the ideal gesture for ARamsay: simple-to-use and easy to be recognized. So eventually we chose the Airtap gesture.
  ![airtap](/Media/3rd%20version%20of%20holo.png)

## 5 Features

Due to the limited development time (3~4 weeks), our first prototype of ARamsay is quite rudimentary. We will continue to improve it in the future.

### - 12/07/2021, v0.1.0

##### Android app

- [x] search recipes by ingredients
- [x] basic UI
- [x] integrated with AWS server
- [ ] UI enhancement
- [ ] more filter

##### HoloLens app

- [x] floatable, adaptable UI components
- [x] interaction gesture recognition
- [x] display plain text instructions
- [ ] multi-device support
- [ ] UI enhancement
- [ ] display video and images
- [ ] object detection
- [ ] instruction hint
- [ ] coaching system

##### AWS server
- [x] basic configuration
- [ ] user system

##### Web application
- [ ] in progress
