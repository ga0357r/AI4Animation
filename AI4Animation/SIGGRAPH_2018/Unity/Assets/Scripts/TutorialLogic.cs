using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialLogic : MonoBehaviour
{
    [SerializeField] private bool playTutorialFirst = true;
    private bool isInTutorial;
    [SerializeField] private GameObject wKey;
    [SerializeField] private GameObject sKey;
    [SerializeField] private GameObject aKey;
    [SerializeField] private GameObject dKey;
    [SerializeField] private GameObject qKey;
    [SerializeField] private GameObject eKey;
    [SerializeField] private GameObject lShiftKey;
    private bool isWPressed = false;
    private bool isSPressed = false;
    private bool isAPressed = false;
    private bool isDPressed = false;
    private bool isQPressed = false;
    private bool isEPressed = false;
    private bool isLShiftPressed = false;
    


    private void Awake()
    {
        if (playTutorialFirst)
            isInTutorial = true;
    }


    private void Update()
    {
        if (isInTutorial)
        {
            if (isWPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    wKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isWPressed = true;
                }
            }

            if (isSPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    sKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isSPressed = true;
                }
            }

            if (isAPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    aKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isAPressed = true;
                }
            }
            
            if (isDPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    dKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isDPressed = true;
                }
            }

            if (isQPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    qKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isQPressed = true;
                }
            }

            if (isEPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    eKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isEPressed = true;
                }
            }

            if (isLShiftPressed == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    lShiftKey.GetComponent<TextMeshProUGUI>().color = Color.green;
                    isLShiftPressed = true;
                }
            }

            if (isWPressed && isSPressed && isAPressed && isDPressed && isQPressed && isEPressed && isLShiftPressed)
                SceneManager.LoadSceneAsync("Demo");

        }
    }
}
