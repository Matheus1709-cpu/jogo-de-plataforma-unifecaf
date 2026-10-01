using UnityEngine;

public class ObjetoLetal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (!EhJogador(colisao))
            return;

        AplicarDano(colisao);
    }

    private bool EhJogador(Collider2D colisao)
    {
        return colisao.CompareTag("Player");
    }

    private void AplicarDano(Collider2D colisao)
    {
        VidaDoJogador vida = colisao.GetComponent<VidaDoJogador>();
        vida.MachucarJogador();
    }
}
