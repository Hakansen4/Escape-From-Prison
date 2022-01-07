using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCreater : MonoBehaviour
{
    private float posX;
    private float posZ;
    private float posY;
    private int sira = 0;
    [SerializeField]
    private int sec1_1;
    [SerializeField]
    private int sec1_2;
    [SerializeField]
    private int sec2Middle;
    [SerializeField]
    private int sec2Up1;
    [SerializeField]
    private int sec2Up2;
    [SerializeField]
    private int sec3;
    [SerializeField]
    private int sec4;
    [SerializeField]
    private GameObject []enemys;
    private void Start()
    {
        enemySpawnerSector1();
        enemySpawnerSector2(sec2Middle,sec2Up1,sec2Up2);
        enemySpawnerSector3(sec3);
        enemySpawnerSector4(sec4);
    }
    //Sector1
    private void enemySpawnerSector1()
    {
        enemySpawnerSector1_1(sec1_1);
        enemySpawnerSector1_2(sec1_2);  
    }
    private void enemySpawnerSector1_1(int sayi)
    {
        for (int i = 0; i < sayi; i++)
        {
            posX = Random.Range(-38.097f, -3.43f);
            posZ = Random.Range(37.781f, 57.58f);
            posY = 0.38f;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
    
    private void enemySpawnerSector1_2(int sayi)
    {
        for (int i = 0; i < sayi; i++)
        {
            posX = Random.Range(-60.2f, -51.1f);
            posZ = Random.Range(50.1f, 80.3f);
            posY = 0.38f;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
    //Sector2
    private void enemySpawnerSector2(int middle,int up1,int up2)
    {
        enemySpawnerSector2Middle(middle);
        enemySpawnerSector2Up1(up1);
        enemySpawnerSector2Up2(up2);
    }
    private void enemySpawnerSector2Up1(int sayi)
    {
        for(int i=0;i<sayi;i++)
        {
            posX = Random.Range(-123, -30);
            posZ = 119.68f;
            posY = 1.23f;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
    private void enemySpawnerSector2Up2(int sayi)
    {
        for (int i = 0; i < sayi; i++)
        {
            posX = Random.Range(-123, -30);
            posZ = 174.6f;
            posY = 1.23f;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
    private void enemySpawnerSector2Middle(int sayi)
    {
        for (int i = 0; i < sayi; i++)
        {
            posX = Random.Range(-104, -46);
            posZ = Random.Range(126, 164);
            posY = -12;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
    
    //Sector3
    private void enemySpawnerSector3(int sayi)
    {
        for(int i=0;i<sayi;i++)
        {
            posX = Random.Range(-15.83f, 11.32f);
            posZ = Random.Range(182.87f, 240.49f);
            posY = -11.55f;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
    
    //Sector4
    private void enemySpawnerSector4(int sayi)
    {
        for(int i=0;i<sayi;i++)
        {
            posX = Random.Range(-19.227f, 13.22f);
            posZ = Random.Range(306.56f, 317.676f);
            posY = -11.68f;
            sira = Random.Range(0, 6);
            Instantiate(enemys[sira], new Vector3(posX, posY, posZ), Quaternion.identity);
        }
    }
}
