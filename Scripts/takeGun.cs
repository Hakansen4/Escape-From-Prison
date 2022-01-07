using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeGun : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]
    private GameObject m9;
    [SerializeField]
    private GameObject m4;
    [SerializeField]
    private GameObject ak;
    private gameController gc;
    private void Awake()
    {
        gc = GameObject.FindGameObjectWithTag("GC").GetComponent<gameController>();
    }
    private void Start()
    {
        giveGun();
    }
    private void giveGun()
    {
        if(gc.ActiveGun == "M9")
        {
            gc.ActiveGun = "M9";
            m9.SetActive(true);
            m4.SetActive(false);
            ak.SetActive(false);
        }
        else if(gc.ActiveGun == "M4A1")
        {
            m9.SetActive(false);
            m4.SetActive(true);
            ak.SetActive(false);
            gc.ActiveGun = "M4A1";
        }
        else if(gc.ActiveGun == "AK47")
        {
            m9.SetActive(false);
            m4.SetActive(false);
            ak.SetActive(true);
            gc.ActiveGun = "AK47";
        }
        else
        {
            m9.SetActive(false);
            m4.SetActive(false);
            ak.SetActive(false);
            gc.ActiveGun = "Bos";
        }
    }

    private void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("MainCamera") != null)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (hit.transform.tag == "M9")
                    {
                        Destroy(hit.transform.gameObject);
                        gc.ActiveGun = "M9";
                        m9.SetActive(true);
                        m4.SetActive(false);
                        ak.SetActive(false);
                    }
                    else if (hit.transform.tag == "M4A1")
                    {
                        Destroy(hit.transform.gameObject);
                        m9.SetActive(false);
                        m4.SetActive(true);
                        ak.SetActive(false);
                        gc.ActiveGun = "M4A1";
                    }
                    else if (hit.transform.tag == "AK47")
                    {
                        Destroy(hit.transform.gameObject);
                        m9.SetActive(false);
                        m4.SetActive(false);
                        ak.SetActive(true);
                        gc.ActiveGun = "AK47";
                    }
                }
            }
        }
    }
}
