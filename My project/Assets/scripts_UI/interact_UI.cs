using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact_UI : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup uiGroup;
    public float fadeSpeed = 2f;
    private Coroutine fadeCoroutine;
    public GameObject interactCanvas;

    void Start()
    {
        uiGroup.alpha = 0f;
        uiGroup.interactable = false;
        uiGroup.blocksRaycasts = false;
        interactCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeUI(1f));
            interactCanvas.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
            fadeCoroutine = StartCoroutine(FadeUI(0f, disableOnZero: true));
        }
    }

    IEnumerator FadeUI(float targetAlpha, bool disableOnZero = false)
    {
        while (!Mathf.Approximately(uiGroup.alpha, targetAlpha))
        {
            uiGroup.alpha = Mathf.MoveTowards(uiGroup.alpha, targetAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }

        uiGroup.interactable = targetAlpha > 0f;
        uiGroup.blocksRaycasts = targetAlpha > 0f;
        if (disableOnZero && targetAlpha == 0f)
        {
            interactCanvas.SetActive(false);  // 페이드 완료 후 비활성화
        }
    }
}