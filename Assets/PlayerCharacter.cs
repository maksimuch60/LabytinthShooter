using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public GameObject MCamera;
    public GameObject Parent;
    public GameObject panelDead;
    private int _health = 5;
    void Start()
    {
        _health = 5;
        panelDead.SetActive(false);
    }
    public void Hurt(int damage)
    {

        _health -= damage;
        Debug.Log("Health: " + _health);
        if (_health <= 0)
        {
            panelDead.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined; ;
            MCamera.SetActive(true);
            MCamera.transform.parent = Parent.transform;
            Destroy(gameObject);
        }
    }
}