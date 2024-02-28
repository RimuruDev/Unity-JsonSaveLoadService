<h1 align="center">⭐ Json Save Load Service ⭐</h1>
<p align="center">
  <a>
    <img alt="Made With Unity" src="https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity">
  </a>
  <a>
    <img alt="License" src="https://img.shields.io/github/license/RimuruDev/Unity-JsonSaveLoadService?logo=github">
  </a>
  <a>
    <img alt="Last Commit" src="https://img.shields.io/github/last-commit/RimuruDev/Unity-JsonSaveLoadService?logo=Mapbox&color=orange">
  </a>
  <a>
    <img alt="Repo Size" src="https://img.shields.io/github/repo-size/RimuruDev/Unity-JsonSaveLoadService?logo=VirtualBox">
  </a>
  <a>
    <img alt="Downloads" src="https://img.shields.io/github/downloads/RimuruDev/Unity-JsonSaveLoadService/total?color=brightgreen">
  </a>
  <a>
    <img alt="Last Release" src="https://img.shields.io/github/v/release/RimuruDev/Unity-JsonSaveLoadService?include_prereleases&logo=Dropbox&color=yellow">
  </a>
  <a>
    <img alt="GitHub stars" src="https://img.shields.io/github/stars/RimuruDev/Unity-JsonSaveLoadService?branch=main&label=Stars&logo=GitHub&logoColor=ffffff&labelColor=282828&color=informational&style=flat">
  </a>
  <a>
    <img alt="GitHub user stars" src="https://img.shields.io/github/stars/RimuruDev?affiliations=OWNER&branch=main&label=User%20Stars&logo=GitHub&logoColor=ffffff&labelColor=282828&color=informational&style=flat">
  </a>
  <a>
    <img alt="" src="https://img.shields.io/github/watchers/RimuruDev/Unity-JsonSaveLoadService?style=flat">
  </a>
</p>


## Overview
`JsonSaveLoadService` is a flexible and powerful service designed for saving and loading data in Unity applications. It supports various data types including primitives, custom objects, and collections like Dictionary, HashSet, List, Queue, and Stack. This service ensures cross-platform compatibility (PC, Android, Web) and includes functionality for handling default values when loading data for the first time.

## Dependencies
This service requires the Newtonsoft.Json library for JSON serialization and deserialization. Specifically, it depends on the Unity package `com.unity.nuget.newtonsoft-json` version `3.2.1`.

## Installing Newtonsoft.Json in Unity
To use `JsonSaveLoadService` in your project, you must first ensure that Newtonsoft.Json is properly installed. Follow these steps to install the Newtonsoft.Json package through Unity's Package Manager:

1. Open your Unity project.
2. Navigate to `Window` > `Package Manager`.
3. Click the `+` button in the top left corner of the Package Manager window.
4. Select `Add package from git URL...`.
5. Enter `com.unity.nuget.newtonsoft-json@3.2.1` and click `Add`.
6. Unity will download and install the Newtonsoft.Json package.

Alternatively, you can manually edit your project's `Packages/manifest.json` file to include the following line in the `dependencies` section:

```json
"com.unity.nuget.newtonsoft-json": "3.2.1"
```

## Usage

### Saving Data
```csharp
var saveLoadService = new JsonSaveLoadService();

// Saving a simple data type :D
int highScore = 100;
saveLoadService.Save(highScore, "highScore");

// Saving a custom object :D
var playerData = new PlayerData { Name = "Rimuru", Level = 10 };
saveLoadService.Save(playerData, "playerData");

// Saving a collection :D
var scores = new List<int> { 100, 200, 300 };
saveLoadService.Save(scores, "scores");
```

### Loading Data
```csharp
var loadedHighScore = saveLoadService.Load("highScore", 0);
var loadedPlayerData = saveLoadService.Load("playerData", new PlayerData());
var loadedScores = saveLoadService.Load("scores", new List<int>());
```

### Working with Collections
- **Dictionary**: Save and load `Dictionary<TKey, TValue>` collections.
    ```csharp
    var monsterConfigs = new Dictionary<int, MonsterConfig>
    {
        { 1, new MonsterConfig { /* Initialization */ } },
    };
    saveLoadService.Save(monsterConfigs, "monsterConfigs");

    var loadedMonsterConfigs = saveLoadService.Load("monsterConfigs", new Dictionary<int, MonsterConfig>());
    ```

- **HashSet**: Save and load `HashSet<T>` collections.
    ```csharp
    var uniqueItems = new HashSet<string> { "Sword", "Shield" };
    saveLoadService.Save(uniqueItems, "uniqueItems");

    var loadedUniqueItems = saveLoadService.Load("uniqueItems", new HashSet<string>());
    ```

- **List**: Save and load `List<T>` collections.
    ```csharp
    var itemList = new List<string> { "Apple", "Banana" };
    saveLoadService.Save(itemList, "itemList");

    var loadedItemList = saveLoadService.Load("itemList", new List<string>());
    ```

- **Queue**: Save and load `Queue<T>` collections.
    ```csharp
    var messageQueue = new Queue<string>();
    messageQueue.Enqueue("Hello");
    messageQueue.Enqueue("World");
    saveLoadService.Save(messageQueue, "messageQueue");

    var loadedMessageQueue = saveLoadService.Load("messageQueue", new Queue<string>());
    ```

- **Stack**: Save and load `Stack<T>` collections.
    ```csharp
    var undoCommands = new Stack<string>();
    undoCommands.Push("Command1");
    undoCommands.Push("Command2");
    saveLoadService.Save(undoCommands, "undoCommands");

    var loadedUndoCommands = saveLoadService.Load("undoCommands", new Stack<string>());
    ```

## Editor-Only Custom Path
For ease of debugging and testing in the Unity Editor, `JsonSaveLoadService` allows specifying a custom save path:

```csharp
#if UNITY_EDITOR
JsonSaveLoadService.SetCustomPathInEditor("Assets/Saves");
#endif
```
