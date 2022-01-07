using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private checkpointController cp;
    [SerializeField]
    private GameObject respawnSc;
    [SerializeField]
    private GameObject endAnim;
    public string ActiveGun;
    private void Awake()
    {
        ActiveGun = "Bos";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void respawnScreen()
    {
        respawnSc.SetActive(true);
        Time.timeScale = 0f;
    }

    public void continueButton()
    {
        Time.timeScale = 1f;
        respawnSc.SetActive(false);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Instantiate(player, cp.activeCheckpoint(), Quaternion.identity);
    }

    public void quitButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void endAnimStart()
    {
        GameObject.FindGameObjectWithTag("MainCamera").SetActive(false);
        endAnim.SetActive(true);
        Invoke(nameof(endSceneActive), 10.11f);
    }

    private void endSceneActive()
    {
        SceneManager.LoadScene("theEnd");
    }
    public string activeGun()
    {
        return ActiveGun;
    }
}
