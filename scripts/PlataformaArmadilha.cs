using UnityEngine;
using System.Collections.Generic;
using System.Collections;



public class PlataformaArmadilha : MonoBehaviour
{
    public GameObject efeitoDeExplosao;

    private Animator oAnimator;

    public float tempoParaDesligar;

    void Awake()
    {
        oAnimator = GetComponent<Animator>();
    }


    public void RodarCoroutineDesligarPlataforma()

    {
        StartCoroutine(DesligarPlataforma());
    }

    private IEnumerator DesligarPlataforma()
    {
        oAnimator.Play("animacao-da-plataforma-armadilha-parada");
        yield return new WaitForSeconds(tempoParaDesligar);
        Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
