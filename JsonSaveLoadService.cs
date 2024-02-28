// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Contact me: 
//          - Gmail:    rimuru.dev@gmail.com
//          - GitHub:   https://github.com/RimuruDev
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//          - GitHub Organizations: https://github.com/Rimuru-Dev
//
// **************************************************************** //

using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AbyssMoth.Internal.Codebase.Infrastructure.StorageService
{
    public sealed class JsonSaveLoadService : ISaveLoadService
    {
        private const string FileFormat = ".json";
        private static string _customPathInEditor = "Assets/Saves";

        public void Save<TData>(TData data, string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                Debug.LogError("Save operation failed: Key is null or whitespace.");
                return;
            }

            if (data == null)
            {
                Debug.LogError("Save operation failed: Data is null.");
                return;
            }

            try
            {
                var filePath = GetFilePath(key);

                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath ??
                                              throw new InvalidOperationException("Directory path is null."));
                }

                var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error when saving data: {ex.Message}");
            }
        }

        public TData Load<TData>(string key, TData defaultValue = default)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                Debug.LogError("Load operation failed: Key is null or whitespace.");
                return defaultValue;
            }

            try
            {
                var filePath = GetFilePath(key);
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<TData>(jsonData);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error when loading data: {ex.Message}");
            }

            return defaultValue;
        }

        private static string GetFilePath(string key)
        {
#if UNITY_EDITOR
            return Path.Combine(_customPathInEditor, $"{key}{FileFormat}");
#else
            return Path.Combine(Application.persistentDataPath, $"{key}{FileFormat}");
#endif
        }

#if UNITY_EDITOR
        public void SetCustomPathInEditor(string customPath)
        {
            _customPathInEditor = customPath;

            if (!Directory.Exists(_customPathInEditor))
                Directory.CreateDirectory(_customPathInEditor);
        }
#endif
    }
}
