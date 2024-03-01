using UnityEngine;

public class DataController : MonoBehaviour
{
    public static DataController Instance;
    public string[,] Localization;
    public string[] Dictionary;
    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadAllData(string language)
    {
        LoadLanguage(language);
    }

    public void LoadLanguage(string language)
    {
        Localization = Utility.Utility.ReadCSVString("Localization");

        int id = GetLanguageId(language);
        Dictionary = new string[Localization.GetLength(0) - 1];

        for (int i = 1; i < Localization.GetLength(0); i++)
        {
            Dictionary[i - 1] = Localization[i, id];
        }
    }

    private int GetLanguageId(string language)
    {
        for (int j = 0; j < Localization.GetLength(1); j++)
        {
            if (Localization[0, j] == language)
            {
                return j;
            }
        }
        Debug.Log("Unknown language - switch to en");
        return GetLanguageId("en");
    }
}
