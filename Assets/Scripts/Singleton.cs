using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance;

    public string s_playerName;
    public string s_bestPlayerName;
    public int s_bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    public class BestResult
    {
        public string s_bestPlayerName;
        public int s_bestScore;
    }

    public void SaveBestResult()
    {
        BestResult bestResult = new BestResult();
        bestResult.s_bestPlayerName = s_bestPlayerName;
        bestResult.s_bestScore = s_bestScore;

        string savedResult = JsonUtility.ToJson(bestResult);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", savedResult);
    }
}
