using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndPortalGunRotator : MonoBehaviour
{
    public Transform playerCamera; // ������ �� ������ ������
    public Transform targetObject; // ������, �������� ����� ������������ ��������

    void Update()
    {
        if (playerCamera != null && targetObject != null)
        {
            // �������� �������� ������
            Quaternion newRotation = playerCamera.rotation;
            newRotation *= Quaternion.Euler(-90, 0, 0);
            targetObject.rotation = newRotation;
        }
    }
}
