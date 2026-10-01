using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class VidaDoJogador : MonoBehaviour
{
    [Header("Referências")]
    
    public GameObject efeitoDeExplosao;
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;
    
    
    [Header("Valores")]
    public float tempoParaDestruirOJogador;




    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MachucarJogador()
    {

        SFXManager.instance.somDeDano.Play();
        FindAnyObjectByType<MovimentoDoJogador>().JogadorEstavivo = false;
        
        oRigidbody2D.linearVelocity = Vector2.zero;
        oAnimator.Play("jogador-levando-dano");

        StartCoroutine(DestruirJogador());



        
    }

    private IEnumerator DestruirJogador()
    {
        
        yield return new WaitForSeconds(tempoParaDestruirOJogador);
        FindObjectOfType<GameManager>().GameOver();
        Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
