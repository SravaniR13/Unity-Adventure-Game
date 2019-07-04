using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBowScript : MonoBehaviour
{ 
    private Rigidbody myBody;
    public float speed = 30f;
    public float deactivate_Timer = 3f;
    public float damage = 50f;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody>();

    }
    void Start()
    {
        Invoke("DeactivateGameObject", deactivate_Timer);
        
    }

    public void Launch(Camera mainCamera)
    {
        myBody.velocity = mainCamera.transform.forward * speed;


        transform.LookAt(transform.position + myBody.velocity);

    }
    void DeactivateGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
       
    }

    private void OnTriggerEnter(Collider target)
    {
        //Debug.Log("Killed");
        if (target.tag == Tags.ENEMY_TAG)
        {
            gameObject.SetActive(false);
            Debug.Log("Killed enemy");
        }

    }

}

