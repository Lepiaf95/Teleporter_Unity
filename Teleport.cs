using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private Transform posStart;

    public Player m_player; // Le FPSController


    private void Start()
    {
        posStart = GameObject.Find("spawn").GetComponent<Transform>();
        this.transform.position = posStart.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Teleporter")
        {
            StartCoroutine(teleportation(0.1f)); // 0.1f afin de laisser le temps aux teleporteurs de faire leurs propres effets
        }

        if (other.gameObject.tag == "Finish")
        {
            StartCoroutine(teleportation(2.0f));
        }
    }

    IEnumerator teleportation(float x)
    {
        yield return new WaitForSeconds(x);
        this.transform.position = posStart.position;
        m_player.enabled = false; // Script désActivé le temps d'enregistrer la nouvelle position du player entre 2 frames
        StartCoroutine(moveAgain());
    }

    IEnumerator moveAgain()
    {
        yield return new WaitForSeconds(0.3f);
        m_player.enabled = true; // Script reActivé
    }
}
