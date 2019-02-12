using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform posStart;

    private void Start()
    {
        posStart = GameObject.Find("spawn").GetComponent<Transform>();
        //print(posStart.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
            this.transform.position = posStart.position;
        //Time.timeScale = 0.1f;
    }
}
