using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class PortalGun : MonoBehaviour
{
    public Portal Red;
    public Portal Blue;
    private Animator redAnimator;
    private Animator blueAnimator;
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint; // Точка, откуда будет вылетать снаряд
    public float projectileSpeed = 20f;

    public float delayTime = 1f; // Задержка в секундах

    void Start()
    {
        redAnimator = Red.GetComponent<Animator>();
        blueAnimator = Blue.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer != 9) return;

                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                    StartCoroutine(DelayedAction(hit, Red, redAnimator));
                    //ActivatePortal(hit, Red, redAnimator);
                }
                else
                {
                    Shoot();
                    StartCoroutine(DelayedAction(hit, Blue, blueAnimator));
                    //ActivatePortal(hit, Blue, blueAnimator);
                }
            }
        }
    }

    void ActivatePortal(RaycastHit hit, Portal portal, Animator animator)
    {
        portal.transform.rotation = Quaternion.LookRotation(hit.normal);
        portal.transform.position = hit.point + portal.transform.forward * 0.6f;

        if (animator != null)
        {
            animator.SetTrigger(portal == Red ? "ActivateRed" : "ActivateBlue");
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * projectileSpeed;
        }

        Destroy(projectile, delayTime);
    }

    IEnumerator DelayedAction(RaycastHit hit, Portal portal, Animator animator)
    {
        //Пауза на delayTime секунд
        yield return new WaitForSeconds(delayTime);

        ActivatePortal(hit, portal, animator);
    }
}



//public class PortalGun : MonoBehaviour
//{
//    public Portal Red;
//    public Portal Blue;
//    private Animator redAnimator;
//    private Animator blueAnimator;

//    void Start()
//    {
//        // Получаем компоненты Animator из объектов порталов
//        redAnimator = Red.GetComponent<Animator>();
//        blueAnimator = Blue.GetComponent<Animator>();
//    }

//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
//        {
//            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
//            RaycastHit hit;

//            if (Physics.Raycast(ray, out hit))
//            {
//                if (hit.collider.gameObject.layer != 9) return;

//                if (Input.GetMouseButtonDown(0))
//                {
//                    Red.transform.rotation = Quaternion.LookRotation(hit.normal);
//                    Red.transform.position = hit.point + Red.transform.forward * 0.6f;

//                    if (redAnimator != null)
//                    {
//                        redAnimator.SetTrigger("ActivateRed");
//                    }
//                }
//                else
//                {
//                    Blue.transform.rotation = Quaternion.LookRotation(hit.normal);
//                    Blue.transform.position = hit.point + Blue.transform.forward * 0.6f;

//                    if (blueAnimator != null)
//                    {
//                        blueAnimator.SetTrigger("ActivateBlue");
//                    }
//                }
//            }
//        }
//    }
//}
