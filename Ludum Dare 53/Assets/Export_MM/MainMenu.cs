using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject ScrollView;
    [SerializeField] Canvas VolumeCanvas;
    void Start()
    {
        ScrollView.SetActive(false);
        VolumeCanvas.enabled = false;
    }
    void Update()
    {
        
    }
    public void CarSelection()
    {
        SceneManager.LoadScene(1);
    }
    public void HowToPlay()
    {
        ScrollView.SetActive(true);
    }
    public void CancelScroll()
    {
        ScrollView.SetActive(false);
    }
    public void VolumeControl()
    {
        gameObject.SetActive(false);
        VolumeCanvas.enabled = true;
    }
    public void GameQuit()
    {
        print("Application_Closed");
        Application.Quit();
    }
}
