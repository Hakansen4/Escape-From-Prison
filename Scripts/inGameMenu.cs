using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject firstCursor;
    [SerializeField]
    private GameObject secondCursor;
    [SerializeField]
    private GameObject gameController;

    private void Update()
    {
        cursorChoose();
        select();
    }
    private void select()
    {
        if(Input.GetKeyDown(KeyCode.Return) ||  Input.GetKeyDown(KeyCode.Space))
        {
            if(firstCursor.active == true)
            {
                gameController.GetComponent<gameController>().continueButton();
            }
            if(secondCursor.active == true)
            {
                gameController.GetComponent<gameController>().quitButton();
            }
        }
    }
    private void cursorChoose()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)  ||  Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(firstCursor.activeSelf)
            {
                firstCursor.SetActive(false);
                secondCursor.SetActive(true);
            }
            else
            {
                firstCursor.SetActive(true);
                secondCursor.SetActive(false);
            }
        }
    }
}
