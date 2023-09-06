using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    private PlayerControlls plScript;

    public GameObject startPannel, tipsPannel;
    // Start is called before the first frame update
    void Start()
    {
        plScript = GameObject.Find("Player").GetComponent<PlayerControlls>();
        StartCoroutine(hideTips());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        startPannel.SetActive(false);
        Time.timeScale = 1;
        plScript.gameover = false;
        tipsPannel.SetActive(true);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    IEnumerator hideTips()
    {
        yield return new WaitForSeconds(3);

        tipsPannel.SetActive(false);
    }
}
