using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool skipMenus;
    public GameObject uiRoot;
    public GameEvent gameWonEvent;

    public TextMeshProUGUI playerAliveText;
    private int _alivePlayerCount = 4;
    // Start is called before the first frame update
    void Start()
    {
        if (skipMenus)
        {
            uiRoot.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseToggle(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public void GameOver()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void IncreaseKillCount()
    {
        _alivePlayerCount--;
        playerAliveText.text = "Players alive:" + _alivePlayerCount;
        if (_alivePlayerCount == 1)
        {
            gameWonEvent.Raise();
        }
    }
}
