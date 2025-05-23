using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject mainMenuCanvas;
    public Camera mainCamera;               // 이동할 카메라
    public Camera cubeCamera;    // 카메라가 이동할 위치
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
        if (mainMenuCanvas != null)
            mainMenuCanvas.SetActive(false);
        if (mainCamera != null && cubeCamera != null)
        {
            mainCamera.transform.position = cubeCamera.transform.position;
            mainCamera.transform.rotation = cubeCamera.transform.rotation;
            mainCamera.enabled = true;
            cubeCamera.enabled = false;
        }
    }

    public void OnClickLoad()
    {
        Debug.Log("불러오기");
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Debug.Log("종료");
        Application.Quit();
#endif
    }
}
