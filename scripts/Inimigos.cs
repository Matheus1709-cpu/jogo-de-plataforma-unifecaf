using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Inimigos : MonoBehaviour
{
  
    [Header("Caminho do inimigo")]

    public Transform[] pontosDoCaminho;

    public int pontoAtual;

    [Header("Movimento do Inimigo")]
    public float velocidadeDoInimigo;
    public float ultimaPosicaoX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pontoAtual = 0;
        transform.position = pontosDoCaminho[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoverInimigo();
        EspelharInimigo();
    }
    private void MoverInimigo()
    {
        //Move inimigo para o proximo ponto da array 
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDoInimigo * Time.deltaTime); 

        // Verifica se o inimigo chegou no ponto certo 
        if(transform.position == pontosDoCaminho[pontoAtual].position)
        {
            //Troca o proximo ponto 
            pontoAtual += 1;
           
           //Armazena a posição x 
            ultimaPosicaoX = transform.localPosition.x;

            //Verifica se o proximo ponto existe array 
            if(pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    
        
    }

    private void EspelharInimigo()
{

    // Espelha o sprite do inimigo dependendo da sua direção 
    if(transform.localPosition.x < ultimaPosicaoX)
    {
        GetComponent<SpriteRenderer>().flipX = false;
    }
    else if(transform.localPosition.x > ultimaPosicaoX)
    {
        GetComponent<SpriteRenderer>().flipX = true;
    }
}
}
