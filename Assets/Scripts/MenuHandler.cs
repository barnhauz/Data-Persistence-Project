using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;

    public TextMeshProUGUI bestScoreText;
    public TMP_InputField enterNameInput;
    public string playerName;

    void Start()
    {
        Singleton.Instance.LoadBestResult();
        bestScoreText.text = $"Best Score: {Singleton.Instance.s_bestPlayerName} ({Singleton.Instance.s_bestScore})";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
        Singleton.Instance.SaveBestResult();
    }    

    public void CaptureName()
    {
        playerName = enterNameInput.text;
        Singleton.Instance.s_playerName = playerName;
    }

    public void ResetHighScore()
    {
        string savefilePath = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(savefilePath))
        {
            File.Delete(savefilePath);
        }

        Singleton.Instance.s_bestPlayerName = null;
        Singleton.Instance.s_bestScore = 0;

        bestScoreText.text = $"Best Score: {Singleton.Instance.s_bestPlayerName} ({Singleton.Instance.s_bestScore})";
    }
}
