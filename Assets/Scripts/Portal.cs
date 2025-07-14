using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //ссылки на другой портал и камеру внутри портала
    public Portal Other;
    public Camera PortalView;

    // Start is called before the first frame update
    void Start()
    {
        Other.PortalView.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponentInChildren<MeshRenderer>().sharedMaterial.mainTexture = Other.PortalView.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        //связь перемещения камеры игрока и камеры портала
        Vector3 lookerPosition = Other.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);
        PortalView.transform.localPosition = lookerPosition;

        //связь вращения камеры игрока и камеры портала
        Quaternion difference = transform.rotation * Quaternion.Inverse(Other.transform.rotation * Quaternion.Euler(0,180,0));
        PortalView.transform.rotation = difference * Camera.main.transform.rotation;

        // минимальное расстояние, на котором видит камера
        PortalView.nearClipPlane = lookerPosition.magnitude;
    }
}
