using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;
    public Transform shootPoint;
    Animator animator;
    public bool canShoot;
    float nextFire = 0;
    [SerializeField]
    float rateOfFire;
    public ParticleSystem muzzleFlash;
    public AudioClip shootAC;
    public AudioClip emptyFire;
    public AudioClip reloadAC;
    AudioSource pistolAS;
    public float weaponRange;
    bool isReloading;

    public int currentAmmo = 8;
    public int maxAmmo = 8;
    public int carriedAmmo = 40;
    public Text currentAmmoText;
    public Text carriedAmmoText;
    public Text fullAmmoText;


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
        if (Input.GetButton("Fire1") && canShoot == true && currentAmmo > 0)
        {

            
                Shoot();
            

        }
        else if (Input.GetButton("Fire1") && currentAmmo <= 0 && !isReloading)
        {
            EmptyFire();
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !isReloading)
        {
            isReloading = true;
            Reload();
        }
        



        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("Run", true);

        }
        else
        {
            animator.SetBool("Run", false);

        }


    }
    //firing is controlled
    void Shoot()
    {
        if (Time.time > nextFire && currentAmmo >= 2)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.Play();
            pistolAS.clip = shootAC;

            animator.SetTrigger("shoot");
            StartCoroutine(ShowMuzzleFlash());
            StartCoroutine(StopMuzzleFlash());

          if (currentAmmo <=2)
            {
                currentAmmo -= currentAmmo;
            }
          else
            {
                currentAmmo -= 3;
            }
           
           
            
            ShootRay();
            UpdateAmmoUI();
            



        }
    }

    IEnumerator ShowMuzzleFlash()
    {
        for (int i = 0; i < 7; i++)
        {
            muzzleFlash.Play();
            yield return new WaitForSeconds(0.1f); // Efektler arasýnda beklenen süre
        }
    }

    IEnumerator StopMuzzleFlash()
    {
        yield return new WaitForSeconds(0.3f); // Üç efekt tamamlandýktan sonra beklenen süre
        muzzleFlash.Stop();
    }

    void EmptyFire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            pistolAS.PlayOneShot(emptyFire);


        }
    }
    void Reload()
    {
        if (carriedAmmo <= 0 ) return;
       
        animator.SetTrigger("reload");
        pistolAS.PlayOneShot(reloadAC);
       
        StartCoroutine(ReloadCountDown(2f));

        
        
       
           
      
        
        


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
                EnemyHealth enemyHealth = hit.transform.GetComponent<EnemyHealth>();// Bizden çýkan ýþýnlar  nereye vuruyorsa onun scriptine ulaþ.
                Instantiate(bloodEffect, hit.point, transform.rotation);
                enemyHealth.ReduceHealth(30);

            }

        }
    }
    
    IEnumerator ReloadCountDown(float timer)
    {
        while (timer > 0f)
        {

            timer -= Time.deltaTime;
            yield return null;
        }
        if (timer <= 0)
        {
            
            isReloading = false;
            int bulletNeeded = maxAmmo - currentAmmo;
            int bulletToDeduct = (carriedAmmo >= bulletNeeded) ? bulletNeeded : carriedAmmo;
            carriedAmmo -= bulletToDeduct;
            currentAmmo += bulletToDeduct;
            UpdateAmmoUI();
        }
    }





}
