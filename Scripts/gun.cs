using UnityEngine;
using TMPro;
public class gun : MonoBehaviour
{
    [SerializeField]
    private bool autoGun;
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private GameObject hitEffect;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float reloadTime;
    [SerializeField]
    private int allbulletCount;
    [SerializeField]
    public int magSize;
    private int bulletLeftinMag;
    private float nextTimeToFire = 0f;
    [SerializeField]
    private Camera fpsCam;
    [SerializeField]
    private ParticleSystem muzzleFlash;
    [SerializeField]
    private AudioSource audio;
    [SerializeField]
    private AudioClip shootSound;
    [SerializeField]
    private AudioClip reloadSound;
    [SerializeField]
    private AudioClip noBullet;
    private bool canFire = true;
    [SerializeField]
    private healthController textController;
    [SerializeField]
    private audioHit audioHit;
    private void Awake()
    {
        bulletLeftinMag = magSize;
        textController = GameObject.FindGameObjectWithTag("txtC").GetComponent<healthController>();
    }
    private void Start()
    {
        textController.setallBUllet(allbulletCount.ToString());
        textController.setbulletinMag(bulletLeftinMag.ToString());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && bulletLeftinMag != magSize)
            pressedReload();
        fire();
    }
    private void pressedReload()
    {
        int x = magSize - bulletLeftinMag;
        canFire = false;
        allbulletCount = allbulletCount - x;
        bulletLeftinMag = magSize;
        textController.setallBUllet(allbulletCount.ToString());
        textController.setbulletinMag(bulletLeftinMag.ToString());
        audio.clip = reloadSound;
        audio.Play();
        anim.SetBool("reload", true);
        Invoke(nameof(reload), reloadTime);
    }
    private void fire()
    {
        if (!autoGun)
        {
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire && canFire)
            {
                nextTimeToFire = Time.time + 1f * fireRate;
                if (bulletLeftinMag == 0 && allbulletCount == 0)
                {
                    audio.clip = noBullet;
                    audio.Play();
                }
                else if (bulletLeftinMag == 0)
                {
                    allbulletCount = allbulletCount - magSize;
                    textController.setallBUllet(allbulletCount.ToString());
                    audio.clip = reloadSound;
                    audio.Play();
                    anim.SetBool("reload", true);
                    canFire = false;
                    Invoke(nameof(reload), reloadTime);
                }
                else
                {
                    shoot();
                    bulletLeftinMag--;
                    textController.setbulletinMag(bulletLeftinMag.ToString());
                }
            }
        }
        else
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && canFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                if (allbulletCount == 0 && bulletLeftinMag == 0)
                {
                    audio.clip = noBullet;
                    audio.Play();
                }
                else if (bulletLeftinMag == 0)
                {
                    allbulletCount = allbulletCount - magSize;
                    textController.setallBUllet(allbulletCount.ToString());
                    audio.clip = reloadSound;
                    audio.Play();
                    anim.SetBool("reload", true);
                    canFire = false;
                    Invoke(nameof(reload), reloadTime);
                }
                else
                {
                    shoot();
                    bulletLeftinMag--;
                    textController.setbulletinMag(bulletLeftinMag.ToString());
                }
            }
        }
    }
    private void reload()
    {
        bulletLeftinMag = magSize;
        textController.setbulletinMag(bulletLeftinMag.ToString());
        anim.SetBool("reload", false);
        canFire = true;
    }
    private void shoot()
    {
        audio.clip = shootSound;
        audio.Play();
        muzzleFlash.Play();
        RaycastHit hitInfo;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
        {
            EnemyAI enemy = hitInfo.transform.GetComponent<EnemyAI>();
            if(enemy != null)
            {
                Invoke(nameof(AudioHit), 0.1f);
                hitInfo.rigidbody.AddForce(-hitInfo.normal * 80);
                Instantiate(hitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                enemy.takeDamage(damage);
            }
        }
    }
    private void AudioHit()
    {
        audioHit.play();
    }
}
