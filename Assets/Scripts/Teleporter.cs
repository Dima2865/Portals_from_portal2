using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Teleporter Other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;

        if (zPos <= 0) Teleport(other.transform);
    }

    private void Teleport(Transform obj)
    {
        // ��������� ������
        Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(obj.position);
        localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
        obj.position = Other.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);

        // �������� ������
        Quaternion difference = Other.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
        obj.rotation = difference * obj.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.layer = 8;
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.layer = 7;
    }
}