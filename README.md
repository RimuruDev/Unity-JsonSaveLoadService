# JsonSaveLoadService

## Overview
`JsonSaveLoadService` is a flexible and powerful service designed for saving and loading data in Unity applications. It supports various data types including primitives, custom objects, and collections like Dictionary, HashSet, List, Queue, and Stack. This service ensures cross-platform compatibility (PC, Android, Web) and includes functionality for handling default values when loading data for the first time.

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
