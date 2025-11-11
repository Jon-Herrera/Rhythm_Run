using System;
using UnityEngine;
public class KillPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform respawn;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = respawn.position;
        }
    }


}
