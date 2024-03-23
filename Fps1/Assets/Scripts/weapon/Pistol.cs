using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;
    Animator animator;
    bool isReloading;


    public int currentAmmo = 12;
    public int maxAmmo = 12;
    public int carriedAmmo = 0;

    public GameObject metallicBulletHole;
    public AudioClip shootMetalAC;



    [SerializeField]
    float rateOfFire;
    float nextFire = 0;
    [SerializeField]
    float weaponRange;
    public Transform shootPoint;

    public float damagae = 20f;

 

    public ParticleSystem muzzleFlash;

    AudioSource pistolAS;
    public AudioClip shootAC;
    public AudioClip  emptyFire;
    public Text currentAmmoText;
    public Text carriedAmmoText;


    public GameObject bloodEffect;
    void Start()
    {
        pistolAS = GetComponent<AudioSource>();
        muzzleFlash.Stop();
      
        animator = GetComponent<Animator>();
        UpdateAmmoUI();

    }

    // weapon use is controlled
    void Update()
    {
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }
         else if(Input.GetButton("Fire1") && currentAmmo <= 0&& !isReloading)
        {
            EmptyFire();
        }
        else if (Input.GetKeyDown(KeyCode.R)&&currentAmmo<=maxAmmo && !isReloading)
        {
            isReloading = true;
            Reload();
        }
    }
    //firing is controlled
    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            animator.SetTrigger("Shoot");

            currentAmmo--;
            ShootRay();
            UpdateAmmoUI();

            

        }
    }
    public void UpdateAmmoUI()
    {
        currentAmmoText.text = currentAmmo.ToString();
        carriedAmmoText.text = carriedAmmo.ToString();
    }

    //This function sends a rail in the shooting direction
    void ShootRay()
    {
        if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weaponRange))//collidere çarpmalý
        {
            if (hit.transform.tag == "Enemy")
            {
                EnemyHealth enemy =hit.transform.GetComponent<EnemyHealth>();// Bizden çýkan ýþýnlar  nereye vuruyorsa onun scriptine ulaþ.
                enemy.ReduceHealth(damagae);
                Instantiate(bloodEffect, hit.point, transform.rotation);
            }
            else if(hit.transform.tag==("metal"))
            {
                pistolAS.PlayOneShot(shootMetalAC);
                Instantiate(metallicBulletHole,hit.point,Quaternion.FromToRotation(Vector3.up,hit.normal));
            }
            else
            {
                Debug.Log("something else");
            }
        }
    }

    //empty shot is checked
    void EmptyFire()
    {
        if(Time.time>nextFire)
        {
            nextFire= Time.time + rateOfFire;
            pistolAS.PlayOneShot(emptyFire);
            animator.SetTrigger("Empty");
        }
    }

    //bullet renewal
    void Reload()
    {
        if (carriedAmmo <= 0) return;
        animator.SetTrigger("Reload");
        StartCoroutine(ReloadCountDown(2f));
        
    }
    IEnumerator PistolEffect()
    {
        muzzleFlash.Play();
        pistolAS.PlayOneShot(shootAC);
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();
    }
    IEnumerator ReloadCountDown(float timer)
    {
        while (timer > 0f)
        {
            
            timer -= Time.deltaTime;
            yield return null;
        }
        if(timer<=0)
        {
            isReloading=false;
            int bulletNeeded = maxAmmo - currentAmmo;
            int bulletToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;
            carriedAmmo-= bulletToDeduct;
            currentAmmo += bulletToDeduct;
            UpdateAmmoUI();
        }
    }
}
