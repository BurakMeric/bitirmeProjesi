using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;

    public ParticleSystem muzzleFlash;

    Animator animator;

    private AudioSource pistolAS;
    [SerializeField] private AudioClip ShootAC;

    [SerializeField] int currentAmmo;
    [SerializeField] float rateOfFire;
    private float nextFire;

    [SerializeField] float weaponRange;
    public Transform shootPoint;

    public float damage = 20f;

    public GameObject bloodEffect;

    EnemyHealth enemySc;

    void Start()
    {
        animator = GetComponent<Animator>();

        pistolAS = GetComponent<AudioSource>();
        enemySc = FindObjectOfType<EnemyHealth>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            animator.SetTrigger("Shoot");
            currentAmmo--;


            if (Physics.Raycast(shootPoint.position,shootPoint.forward, out hit, weaponRange))
            {
                if (hit.transform.tag == "Enemy")
                {
                    enemySc.ReduceHealth(damage);
                    GameObject be = Instantiate(bloodEffect, hit.point, Quaternion.identity);
                    Destroy(be,1f);
                }
            }
            else
            {
                Debug.Log("Hit World");
            }
        }
    }

    IEnumerator pistolEffect()
    {
        muzzleFlash.Play();
        pistolAS.PlayOneShot(ShootAC);
        yield return new WaitForEndOfFrame();
        muzzleFlash.Stop();
    }
}
