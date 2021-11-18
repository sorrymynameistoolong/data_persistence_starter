using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public GameObject nameInput;

    void Start()
    {
        LoadHighScore();
    }

    public void StartGame()
    {
        if(nameInput.GetComponent< TMP_InputField>().text != "")
        {
            DataManager.Instance.currentPlayer = nameInput.GetComponent<TMP_InputField>().text.Trim();
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("please input player's name");
        }
    }

    public void LoadHighScore()
    {
        DataManager.Instance.Load();

        if(DataManager.Instance.highScore > 0)
        {
            highScoreText.text = "HighScore: " + DataManager.Instance.highScorePlayer + " - " + DataManager.Instance.highScore;
        }
    }
}
