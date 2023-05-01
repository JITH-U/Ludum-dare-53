using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas PauseMenuCanvas;
    float volumeFloat;
    void Start()
    {

        volumeFloat = PlayerPrefs.GetFloat("GameVolume");
        PauseMenuCanvas.enabled = false;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseMenuCanvas.enabled)
            {
                PauseMenuCanvas.enabled = true;
                Time.timeScale = 0;
                AudioListener.volume = 0;
            }
            else if (PauseMenuCanvas.enabled)
            {
                Resume();
            }

        }

    }
    public void Resume()
    {
        FindObjectOfType<soundmanager>().play("click");
        AudioListener.volume = volumeFloat;

        Time.timeScale = 1;
        PauseMenuCanvas.enabled = false;
    }
    public void ReturnToMainMenu()
    {
        FindObjectOfType<soundmanager>().play("click");
        Time.timeScale = 1;
        AudioListener.volume = volumeFloat;
        Invoke("GotoMain", 0.2f);
    }
    public void Retry()
    {

        FindObjectOfType<soundmanager>().play("click");
        Time.timeScale = 1;
        AudioListener.volume = volumeFloat;
        StartCoroutine(retrying());
    }
    IEnumerator retrying()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void GotoMain()
    {
        SceneManager.LoadScene(0);
    }
}
