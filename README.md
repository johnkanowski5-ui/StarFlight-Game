# StarFlight Game

This repository contains a Unity starter project for a space-themed endless runner inspired by the Flight game, but with a glowing star as the player. It includes the gameplay loop, obstacle spawning, coin collection, multiple upgrades, mobile touch controls, and persistent save data.

## What is included

- Endless runner gameplay
- Tap/click to fly
- Obstacle and coin spawning
- Persistent coin and upgrade storage using PlayerPrefs
- Upgrade system for speed, shield, magnet, and boost
- Layout built for iOS and Android deployment in Unity

## How to use in Unity

1. Open Unity Hub and create a new 2D project or use this repo as a Unity project root.
2. Copy the `Assets` folder from this repo into your Unity project.
3. Create an empty scene named `Main`.
4. In the scene, press Play. The bootstrap script creates the game objects automatically.
5. Build for Android with Android Build Settings and for iOS with iOS Build Settings.

## Included files

- `Assets/Scripts/GameBootstrap.cs`
- `Assets/Scripts/GameManager.cs`
- `Assets/Scripts/PlayerController.cs`
- `Assets/Scripts/ObstacleSpawner.cs`
- `Assets/Scripts/CoinSpawner.cs`
- `Assets/Scripts/UpgradeManager.cs`
- `Assets/Scripts/UIManager.cs`
- `Assets/Scripts/SimpleSpriteFactory.cs`

## Suggested Unity versions

- Unity 2022.3 LTS or later

## Build steps

### Android

1. Install Android Build Support in Unity
2. File > Build Settings > Android > Switch Platform
3. Build APK / AAB
4. Sign with your keystore

### iOS

1. File > Build Settings > iOS > Switch Platform
2. Open project in Xcode
3. Set your bundle identifier and signing team
4. Archive and upload to TestFlight or App Store

## Notes

This is a starter project and is designed to be expanded with art, sound, menus, and polish.
