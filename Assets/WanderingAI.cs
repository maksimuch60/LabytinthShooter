using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    [SerializeField] private GameObject fireballPrefab;
    private GameObject _fireball;

    private bool _alive; //Ћогическа€ переменна€ дл€ слежени€ за состо€нием персонажа.
    void Start()
    {
        _alive = true; //»нициализаци€ этой переменной.
    }
    void Update()
    {
        if (_alive)
        { //ƒвижение начинаетс€ только в случае живого персонажа.
            transform.Translate(0, 0, speed * Time.deltaTime);
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (_fireball == null)
                    {
                        _fireball = Instantiate(fireballPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }
    public void SetAlive(bool alive)
    { //ќткрытый метод, позвол€ющий внешнему коду воздействовать на Ђживоеї состо€ние.
        _alive = alive;
    }
}
