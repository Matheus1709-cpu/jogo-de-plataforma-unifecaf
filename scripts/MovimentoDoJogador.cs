using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimentoDoJogador : MonoBehaviour
{
    [Header("Referências")]
    private Rigidbody2D oRigidbody2D;

    private Animator oAnimator;

    [Header("Movimento Horizontal")]

    public float velocidadeDoJogador;
    public bool IndoParaDireita;

    [Header ("Pulo")]
    
    public bool estanoChao;

    public float alturadoPulo;

    public float  tamanhoDoRaioDeVerificacao;

    public Transform verificadorDeChao;

    public LayerMask layerDoChao;

    [Header("Wall Jump")]
    public bool estaNaParede;

    public bool estaPulandoNaParede;

    public float forcaXDoWallJump;

    public float forcaYDoWallJump;

    public Transform verficadorDeParede;

    [Header("Verificações")]
    public bool JogadorEstavivo;

    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        JogadorEstavivo = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(JogadorEstavivo == true)
        {
            MovimentarJogador();
            Pular();
            WallJump();
        }
    }

    private void MovimentarJogador()
    {
        // Movimento Horizontal do jogador 
        float movimentoHorizontal = Input.GetAxis("Horizontal");

        oRigidbody2D.linearVelocity = new Vector2(movimentoHorizontal * velocidadeDoJogador, oRigidbody2D.linearVelocity.y);

        
         // Espelhemento de jogador de acordo com a direção
        if(movimentoHorizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            IndoParaDireita = true;
        }
        else if(movimentoHorizontal < 0 )
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            IndoParaDireita = false;

        }

         // Animações do jogador parado e andando
        if(movimentoHorizontal == 0 && estanoChao == true)
        {
            oAnimator.Play("idle-jogador");
        }
        else if(movimentoHorizontal != 0 && estanoChao == true && estaNaParede == false)
        {
            oAnimator.Play("jogador-andando");

        }
    }

    private void Pular()
    {
        // Verifica o se player encosta o chão 
        estanoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoRaioDeVerificacao, layerDoChao);

        if(Input.GetButtonDown("Jump") && estanoChao == true)
        {
            SFXManager.instance.SomDoPulo.Play();     
            oRigidbody2D.AddForce(new Vector2(0f, alturadoPulo), ForceMode2D.Impulse);
        }

        // A animação do jogador pulando
        if(estanoChao == false && estaNaParede == false)
        {
            oAnimator.Play("jogador-pulando");

        }
    }

    private void WallJump()
    {
        // Verifica se o jogador esta encostando na parede 
        estaNaParede = Physics2D.OverlapCircle(verficadorDeParede.position, tamanhoDoRaioDeVerificacao, layerDoChao);

         //Animação do jogador Deslizando na parede 
        if (estaNaParede == true && estanoChao == false)
        {
            oAnimator.Play("jogador-deslizando-na-parede");

        }

            // Diz que o jogador está na parede e pulando      
            if(Input.GetButtonDown("Jump") && estaNaParede == true && estanoChao == false)
            {
                estaPulandoNaParede = true;
            }

            // Faz o jogador pular na parede e na direção oposta 
            if(estaPulandoNaParede == true)
            {
                if(IndoParaDireita == true)
                {
                    oRigidbody2D.linearVelocity = new Vector2(-forcaXDoWallJump, forcaYDoWallJump);
                }
                else
                {
                    oRigidbody2D.linearVelocity = new Vector2(forcaXDoWallJump, forcaYDoWallJump);
                }

                //Diz para unity que o jogador saiu da parede
                Invoke(nameof(DeixarEstarPulandoNaParedeComoFalso), 0.1f);


            }
        
    }

    private void DeixarEstarPulandoNaParedeComoFalso()
    {
        estaPulandoNaParede = false;
    }

    public void ImpulsionarJogador(float forcaDoImpulso)
{
    oRigidbody2D.linearVelocity = new Vector2(oRigidbody2D.linearVelocity.x, 0f);
    oRigidbody2D.AddForce(new Vector2(0f, forcaDoImpulso), ForceMode2D.Impulse);
}

}
