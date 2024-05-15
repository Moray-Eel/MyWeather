namespace MyWeather.Presentation.Services;

public class PreferenceService : IPreferences
{
    public bool ContainsKey(string key, string? sharedName = null) => Preferences.Default.ContainsKey(key, sharedName);

    public void Remove(string key, string? sharedName = null) => Preferences.Default.Remove(key, sharedName);

    public void Clear(string? sharedName = null) => Preferences.Default.Clear(sharedName);

    public void Set<T>(string key, T value, string? sharedName = null) => Preferences.Default.Set(key, value, sharedName);

    public T Get<T>(string key, T defaultValue, string? sharedName = null) => Preferences.Default.Get(key, defaultValue, sharedName);
}