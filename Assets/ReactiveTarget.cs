using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        { //Проверяем, присоединен ли к персонажу сценарий WanderingAI; он может и отсутствовать.
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Die()
    {
        for (int i = 0; i < 3; i++)
        {
            this.transform.Rotate(0, 0, 11);
            yield return new WaitForSeconds(0.05f);
        }
        rigidbody.freezeRotation = false;
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject); //Объект может уничтожать сам себя точно так же, как любой другой объект.
    }
}
