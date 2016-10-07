# Weather App Xamarin.iOS

In this module we will build our first native iOS app using Visual Studio and Xamarin.iOS
The app we are building is called Weather App that gets the weather information from a web services
when you tap a location on the Maps.

## Overview

What we will learn in this lab?

- Creating a user interface using iOS Designer
- Calling web method to get weather data
- Using Maps control in an app 

In the _Start_ folder you will find the partially completed Weather App solution.
That we will use to complete this exercise

The projects contains a `Main.storyboard` file a interface designer surface where we will 
add UI controls for Maps, labels and button. A `ViewController.cs` a controller file where
we will write the business logic, in this exercise this will be touch handler for `Map` controls
and code to get the weather data.

And finally `AppDelegate.cs` this where the bootstrapping code for app

You can take a look at completed project in Finish folder, if you get stuck any where during this exercise

## Pre-requisites 
Before executing the labs be sure to setup your macOS or Windows machines as mentioned in the Lab Setup guidelines. 
The steps & screenshots in this guide focuses on Visual Studio development in Windows. 
However, the same labs can be executed in Xamarin Studio on a macOS too. 

When you rung the app, the iOS simulator should start and load the app with blank screen. Now you are all set up to write some code!

## Let's design the interface

Please follow the instructions to add a controls to the design surface

1. Double click on the `Main.storyboard` file, once designer is loaded you should some iOS `View` rendered on the device
2. Drag and drop a `Label` control from the Toolbox to the designer surface
3. Let's give it a meaningful name that we can identify in the `ViewController` code
4. Now repeat the steps 2 and 3, but add the `Map View` instead
5. When you're done the Designer should looks something like this: ![Designer](https://github.com/prashantvc/HOL-WeatherApp/blob/master/Screenshots/Designer.PNG)
6. Finally, lets run it in the simulator to verify that map loads

## Get location co-ordinates from the Map

1. Open the `ViewController.cs`, and locate the `ViewDidLoad` method. <br/> `ViewDidLoad` method is called when the screen loads on the screen
2. Create an event handler for `RegionChanged` event for the Map, lets call it `MyMap_RegionChanged`
3. We want to access the Geo coordinates for center of the displayed region, `MyMap.Region.Center` gives the value
4. Pass the `MyMap.Region.Center` value to the `GetWeather` method, where we get weather information from the web service

## Parse the weather data

We are using the OpenWeatherMap service to get the weather data, please take a look at the `GetWeather` method in `ViewController.cs` file.
Once we parsed the data returned from the web service we assign it to the `Description` label

`Description.Text = $"City {city}, {temperature}°C";`

## What's next?

Once you competed this exercise, you can try extend the app with:

- Display current weather icon
- Add forecast details
