using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScaleController : MonoBehaviour
{
    private ParticleSystem MyParticleSystem;

    void Start()
    {
        // �������� ��������� ParticleSystem
        MyParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // �������� ������ ����������� �������
        Vector3 forward = transform.forward;

        // ���������� ���� ����� �������� ����������� � �������� ����������
        float angleYZ = Vector3.Angle(forward, Vector3.right); // ��������� YZ
        float angleXZ = Vector3.Angle(forward, Vector3.forward); // ��������� XZ

        // ���������� ��� �������� ������ ��������
        Vector3 newScale = Vector3.one;

        // ��������� �������������� � ����������� � �������� �������
        if (angleYZ < 1e-5) // ��������� YZ
        {
            newScale = new Vector3(1, 1, 0.56f);
        }
        else
        {
            newScale = new Vector3(0.56f, 1, 1);
        }
        
        if (angleXZ < 1e-5) // ��������� XZ
        {
            newScale = new Vector3(0.56f, 1, 1);
        }
        else
        {
            newScale = new Vector3(0.56f, 1, 0.56f);
        }

        // ������������� ����� ������� � ParticleSystem
        MyParticleSystem.transform.localScale = newScale;
    }
}
