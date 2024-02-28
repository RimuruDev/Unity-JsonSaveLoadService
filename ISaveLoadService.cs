// Resharper disable all
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

namespace RimuruDev.StorageService
{
    public interface ISaveLoadService
    {
        public void Save<TData>(TData data, string key);
        public TData Load<TData>(string key, TData defaultValue = default);
#if UNITY_EDITOR
        public void SetCustomPathInEditor(string customPath);
#endif
    }
}
