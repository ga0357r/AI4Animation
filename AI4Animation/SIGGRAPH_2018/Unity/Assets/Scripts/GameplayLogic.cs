using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SIGGRAPH_2018;
using UnityEngine.SceneManagement;
using TMPro;

public class GameplayLogic : MonoBehaviour
{
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject youLose;
    private float timeRemainingBeforeRestarting = 3;

    private void Update()
    {
        EndGame();
    }

    private void EndGame()
    {
        if (Player.Instance.IsHome)
            PlayerWins();

        if (Player.Instance.IsCaught)
            PlayerLoses();
    }

    private void PlayerWins()
    {
        Debug.Log("You Win");
        youWin.SetActive(true);
        youLose.SetActive(false);
        Time.timeScale = 0;
        Player.Instance.GetComponent<BioAnimation_Wolf>().enabled = false;
    }

    private void PlayerLoses()
    {
        Debug.Log("You Lose");
        youLose.SetActive(true);
        youWin.SetActive(false);
        Player.Instance.GetComponent<BioAnimation_Wolf>().enabled = false;
        youLose.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = " You Lose! \n Restarting in " + (int)timeRemainingBeforeRestarting;
        timeRemainingBeforeRestarting -= Time.deltaTime;

        if (timeRemainingBeforeRestarting <= 0)
        {
            timeRemainingBeforeRestarting = 3;
            SceneManager.LoadSceneAsync("Demo");
        }
    }
}