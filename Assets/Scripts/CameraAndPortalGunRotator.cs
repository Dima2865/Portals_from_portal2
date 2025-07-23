using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndPortalGunRotator : MonoBehaviour
{
    public Transform playerCamera; // Ссылка на камеру игрока
    public Transform targetObject; // Объект, которому будет копироваться движение

    void Update()
    {
        if (playerCamera != null && targetObject != null)
        {
            // Копируем вращение камеры
            Quaternion newRotation = playerCamera.rotation;
            newRotation *= Quaternion.Euler(-90, 0, 0);
            targetObject.rotation = newRotation;
        }
    }
}
