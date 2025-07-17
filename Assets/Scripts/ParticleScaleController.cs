using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScaleController : MonoBehaviour
{
    private ParticleSystem MyParticleSystem;

    void Start()
    {
        // Получаем компонент ParticleSystem
        MyParticleSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Получаем вектор направления объекта
        Vector3 forward = transform.forward;

        // Определяем угол между вектором направления и нормалью плоскостей
        float angleYZ = Vector3.Angle(forward, Vector3.right); // Плоскость YZ
        float angleXZ = Vector3.Angle(forward, Vector3.forward); // Плоскость XZ

        // Переменная для хранения нового масштаба
        Vector3 newScale = Vector3.one;

        // Проверяем параллельность с плоскостями и изменяем масштаб
        if (angleYZ < 1e-5) // Плоскость YZ
        {
            newScale = new Vector3(1, 1, 0.56f);
        }
        else
        {
            newScale = new Vector3(0.56f, 1, 1);
        }
        
        if (angleXZ < 1e-5) // Плоскость XZ
        {
            newScale = new Vector3(0.56f, 1, 1);
        }
        else
        {
            newScale = new Vector3(0.56f, 1, 0.56f);
        }

        // Устанавливаем новый масштаб в ParticleSystem
        MyParticleSystem.transform.localScale = newScale;
    }
}
