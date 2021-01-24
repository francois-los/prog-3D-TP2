using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private Material TriggeredTarget;

    void Update()
    {
        StartCoroutine(DestroyIn3Second());
    }

    private IEnumerator DestroyIn3Second()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enter OnTriggerEnter");
        other.GetComponent<Renderer>().material = TriggeredTarget;
    }
}
