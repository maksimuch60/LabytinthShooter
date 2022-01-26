using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked; //�������� ��������� ����
        Cursor.visible = false; //� ������ ������.
    }

    void Update()
    { //��� ������� �� ������� ����� �������� �������� ��� ��� �������� ���� �� �������� 3.1.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(
            _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject; //�������� ������, � ������� ����� ���.
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit(); //����� ������ ��� ������ ������ ��������� ����������� ���������.
}
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    private IEnumerator SphereIndicator(Vector3 pos)
    { //����������� ���������� ��������� IEnumerator.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1); //�������� ����� yield ��������� �����������,
                                            //����� ������� ������������.
        Destroy(sphere); //������� ���� GameObject � ������� ������.
    }
}
