using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson; // Permet d'utiliser le type FirstPersonController - asset d'Unity

public class Teleport : MonoBehaviour
{
    private Transform posStart;

    public FirstPersonController m_player; // Le FPSController d'Unity

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
            FindObjectOfType<GameManager>().gameWin();
        }
    }

    IEnumerator teleportation(float x)
    {
        yield return new WaitForSeconds(x);
        this.transform.position = posStart.position;
        m_player.enabled = false; // Script désActivé le temps d'enregistrer la nouvelle position du player entre 2 frames
        Invoke("moveAgain", 0.3f);
    }

    private void  moveAgain()
    {
        m_player.enabled = true; // Script reActivé
    }
}
