using UnityEditor;
using UnityEngine;

public static class CheatMenu
{
    [MenuItem("Cheats/Add 100 gold")]
    public static void Add100Gold()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 100);
    }

    [MenuItem("Cheats/Add 1000 gold")]
    public static void Add1000Gold()
    {
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + 1000);
    }
    [MenuItem("Cheats/Add 1 level")]
    public static void Add1Level()
    {
        PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);
    }
}
