using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class OX_quiz : MonoBehaviour
{
    public GameObject OX_quizCanvas;
    public GameObject interactCanvas;
    public GameObject quiz_1;
    public GameObject quiz_2;
    public GameObject quiz_3;
    public GameObject quiz_4;
    public GameObject quiz_5;
    public Button oButton;
    public Button xButton;
    private int currentQuizIndex = 0;
    public Camera mainCamera;
    public Camera quizCamera;
    public Camera cubeCamera;
    private bool hasQuizStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        OX_quizCanvas.SetActive(false);
        interactCanvas.SetActive(false);
        oButton.onClick.AddListener(() => OnAnswerSelected());
        xButton.onClick.AddListener(() => OnAnswerSelected());
    }
    // Update is called once per frame
    void ShowQuiz(int index)
    {
        quiz_1.SetActive(false);
        quiz_2.SetActive(false);
        quiz_3.SetActive(false);
        quiz_4.SetActive(false);
        quiz_5.SetActive(false);
        if (index == 0)
        {
            quiz_1.SetActive(true);
        }
        if (index == 1)
        {
            quiz_2.SetActive(true);
        }
        if (index == 2)
        {
            quiz_3.SetActive(true);
        }
        if (index == 3)
        {
            quiz_4.SetActive(true);
        }
        if (index == 4)
        {
            quiz_5.SetActive(true);
        }
        if (index >= 5)
        {
            OX_quizCanvas.SetActive(false);
            if (mainCamera != null && quizCamera != null && cubeCamera != null)
            {
                mainCamera.transform.position = cubeCamera.transform.position;
                mainCamera.transform.rotation = cubeCamera.transform.rotation;
                mainCamera.enabled = true;
                cubeCamera.enabled = false;
            }
            currentQuizIndex = 0;
        }
    }
    void OnAnswerSelected()
    {
        currentQuizIndex++;
        ShowQuiz(currentQuizIndex);
    }
    void Update()
    {
        if (!hasQuizStarted && interactCanvas.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            interactCanvas.SetActive(false);
            if (mainCamera != null && quizCamera != null)
            {
                mainCamera.transform.position = quizCamera.transform.position;
                mainCamera.transform.rotation = quizCamera.transform.rotation;
                mainCamera.enabled = true;
                quizCamera.enabled = false;
            }
            OX_quizCanvas.SetActive(true);
            quiz_1.SetActive(false);
            quiz_2.SetActive(false);
            quiz_3.SetActive(false);
            quiz_4.SetActive(false);
            quiz_5.SetActive(false);
            ShowQuiz(currentQuizIndex);
        }
    }
}
