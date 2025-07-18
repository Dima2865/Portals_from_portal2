using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public Portal Red;
    public Portal Blue;

    private Animator redAnimator;
    private Animator blueAnimator;

    void Start()
    {
        // Получаем компоненты Animator из объектов порталов
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
                    Red.transform.rotation = Quaternion.LookRotation(hit.normal);
                    Red.transform.position = hit.point + Red.transform.forward * 0.6f;

                    if (redAnimator != null)
                    {
                        redAnimator.SetTrigger("ActivateRed");
                    }
                }
                else
                {
                    Blue.transform.rotation = Quaternion.LookRotation(hit.normal);
                    Blue.transform.position = hit.point + Blue.transform.forward * 0.6f;

                    if (blueAnimator != null)
                    {
                        blueAnimator.SetTrigger("ActivateBlue");
                    }
                }
            }
        }
    }
}
