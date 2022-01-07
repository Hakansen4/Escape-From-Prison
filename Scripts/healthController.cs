using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class healthController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bulletinMag;
    [SerializeField]
    private TextMeshProUGUI allBullet;
    [SerializeField]
    private TextMeshProUGUI healtText;

    public void setbulletinMag(string text)
    {
        bulletinMag.text = text;
    }
    public void setallBUllet(string text)
    {
        allBullet.text = text;
    }
    public void setHealt(string text)
    {
        healtText.text = text;
    }
}
