using UnityEngine;
using System.Collections.Generic;
using System.Collections;




public class VerificadorDeArmadilha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlataformaArmadilha>())
        {
            other.gameObject.GetComponent<PlataformaArmadilha>().RodarCoroutineDesligarPlataforma();
        }
    }
}
