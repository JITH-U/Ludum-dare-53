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
        FindObjectOfType<soundmanager>().play("theme");
        ScrollView.SetActive(false);
        VolumeCanvas.enabled = false;
    }
    void Update()
    {
        
    }
    public void CarSelection()
    {
        FindObjectOfType<soundmanager>().play("click");
        SceneManager.LoadScene(1);
    }
    public void HowToPlay()
    {
        FindObjectOfType<soundmanager>().play("click");
        ScrollView.SetActive(true);
    }
    public void CancelScroll()
    {
        FindObjectOfType<soundmanager>().play("click");
        ScrollView.SetActive(false);
    }
    public void VolumeControl()
    {
        FindObjectOfType<soundmanager>().play("click");
        gameObject.SetActive(false);
        VolumeCanvas.enabled = true;
    }
    public void GameQuit()
    {
        FindObjectOfType<soundmanager>().play("click");
        print("Application_Closed");
        Application.Quit();
    }
}
