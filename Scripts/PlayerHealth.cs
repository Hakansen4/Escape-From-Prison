using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float Health = 100;
    [SerializeField]
    private checkpointController cp;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GameObject Player;
    private healthController textController;
    private void Awake()
    {
        textController = GameObject.FindGameObjectWithTag("txtC").GetComponent<healthController>();
    }
    private void Start()
    {
        textController.setHealt(Health.ToString());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyMelee"))
        {
            Health -= 10;
            if (Health < 1)
                respawn();
            textController.setHealt(Health.ToString());
        }
        else if(other.CompareTag("bulletP"))
        {
            Health -= 10;
            if (Health < 1)
                respawn();
            textController.setHealt(Health.ToString());
        }
        else if (other.CompareTag("bulletM4"))
        {
            Health -= 20;
            if (Health < 1)
                respawn();
            textController.setHealt(Health.ToString());
        }
        else if (other.CompareTag("bulletAK"))
        {
            Health -= 30;
            if (Health < 1)
                respawn();
            textController.setHealt(Health.ToString());
        }
        else if (other.CompareTag("bulletS"))
        {
            Health -= 40;
            if (Health < 1)
                respawn();
            textController.setHealt(Health.ToString());
        }
    }

    private void respawn()
    {
        GameObject.FindGameObjectWithTag("GC").GetComponent<gameController>().respawnScreen();
    }
}
