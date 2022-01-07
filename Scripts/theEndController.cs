using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class theEndController : MonoBehaviour
{
    public TextMeshProUGUI MainText, GoMenu;
    public AudioClip typeSound;
    public AudioSource audioS;
    private bool goMenuActive = false;
    [Multiline]
    public string Maintxt;

    void Start()
    {
        StartCoroutine("WriteMaintxt");
    }
    private void Update()
    {
        if (goMenuActive)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    private IEnumerator WriteMaintxt()
    {
        foreach (char i in Maintxt)
        {
            MainText.text += i.ToString();
            audioS.pitch = Random.Range(0.8f, 1.2f);
            audioS.PlayOneShot(typeSound);
            if (i.ToString() == ".")
                yield return new WaitForSeconds(1);
            else
                yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(menuBT());
    }

    private IEnumerator menuBT()
    {
        yield return new WaitForSeconds(3);
        GoMenu.gameObject.SetActive(true);
        goMenuActive = true;
    }
}
