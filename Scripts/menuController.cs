using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menuController : MonoBehaviour
{
    [SerializeField]
    private GameObject play;
    [SerializeField]
    private GameObject quit;
    private bool isFirst = true;

    private void Update()
    {
        choose();
        ChooseAnim();
        chooseActivated();
    }
    private void choose()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)    ||  Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(isFirst)
            {
                isFirst = false;
            }
            else
            {
                isFirst = true;
            }
        }
    }
    private void ChooseAnim()
    {
        if(isFirst)
        {
            play.GetComponent<Image>().color = new Color(138, 0, 0, 255);
            quit.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            play.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            quit.GetComponent<Image>().color = new Color(138, 0, 0, 255);
        }
    }

    private void chooseActivated()
    {
        if(Input.GetKeyDown(KeyCode.Return) ||  Input.GetKeyDown(KeyCode.Space))
        {
            if(isFirst)
            {
                SceneManager.LoadScene("SampleScene 1");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
