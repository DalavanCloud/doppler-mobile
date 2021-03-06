﻿using Newtonsoft.Json;
using Plugin.Settings.Abstractions;

namespace Doppler.Mobile.Core.Settings
{

    public class LocalSettings : ILocalSettings
    {
        private readonly ISettings _settingsService;

        public LocalSettings(ISettings settings)
        {
            _settingsService = settings;
        }

        /// <inheritdoc />
        public string AuthAccessToken
        {
            get => GetValueOrDefault(LocalSettingsKeys.IsUserLoggedIn, string.Empty);
            set => AddOrUpdateValue(LocalSettingsKeys.IsUserLoggedIn, value);
        }

        /// <inheritdoc />
        public bool IsUserLoggedIn
        {
            get => !string.IsNullOrEmpty(AuthAccessToken);
        }

        /// <inheritdoc />
        public string AccountNameLoggedIn
        {
            get => GetValueOrDefault(LocalSettingsKeys.AccountNameLoggedIn, string.Empty);
            set => AddOrUpdateValue(LocalSettingsKeys.AccountNameLoggedIn, value);
        }

        /// <inheritdoc />
        public int AccountIdLoggedIn 
        {
            get => GetValueOrDefault(LocalSettingsKeys.AccountIdLoggedIn, 0);
            set => AddOrUpdateValue(LocalSettingsKeys.AccountIdLoggedIn, value);
        }

        /// <inheritdoc />
        public bool AddOrUpdateValue<T>(string key, T value)
        {
            return _settingsService.AddOrUpdateValue(key, JsonConvert.SerializeObject(value));
        }

        /// <inheritdoc />
        public void Clear()
        {
            _settingsService.Clear();
        }

        /// <inheritdoc />
        public T GetValueOrDefault<T>(string key, T defaultValue)
        {
            var value = _settingsService.GetValueOrDefault(key, JsonConvert.SerializeObject(defaultValue));
            return JsonConvert.DeserializeObject<T>(value);
        }

        /// <inheritdoc />
        public void Remove(string key)
        {
            _settingsService.Remove(key);
        }
    }
}