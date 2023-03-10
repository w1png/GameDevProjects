using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
            PlayerManager.lives--;
        }
    }
}
