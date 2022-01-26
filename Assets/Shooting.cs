using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; //Скрываем указатель мыши
        Cursor.visible = false; //в центре экрана.
    }

    void Update()
    { //Эта функция по большей части содержит знакомый нам код бросания луча из листинга 3.1.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject; //Получаем объект, в который попал луч.
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit(); //Вызов метода для мишени вместо генерации отладочного сообщения.
}
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    { //Сопрограммы пользуются функциями IEnumerator.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1); //Ключевое слово yield указывает сопрограмме,
                                            //когда следует остановиться.
        Destroy(sphere); //Удаляем этот GameObject и очищаем память.
    }
}
