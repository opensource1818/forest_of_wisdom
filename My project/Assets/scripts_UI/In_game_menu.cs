using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class In_game_menu : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject optionCanvas;
    private bool isOptionActive = false;

    void Start()
    {
        optionCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mainMenuCanvas.activeSelf)
            {
                Debug.Log("1");
            }
            else
            {
                Debug.Log("ESC 눌림");
                isOptionActive = !isOptionActive;
                optionCanvas.SetActive(isOptionActive);
            }
        }
    }
    public void OnClickQuit()
    {
        optionCanvas.SetActive(false);
        isOptionActive = false;
        mainMenuCanvas.SetActive(true);
    }
}

