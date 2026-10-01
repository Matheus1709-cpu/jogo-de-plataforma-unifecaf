using UnityEngine;

public class Mola : MonoBehaviour
{
    [SerializeField] private float forcaDaMola;

    private Animator animador;

    private void Awake()
    {
        animador = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if (!colisao.CompareTag("Player"))
            return;

        AtivarMola(colisao);
    }

    private void AtivarMola(Collider2D jogador)
    {
        TocarEfeito();
        ExecutarAnimacao();

        MovimentoDoJogador movimento = jogador.GetComponent<MovimentoDoJogador>();
        movimento.ImpulsionarJogador(forcaDaMola);
    }

    private void TocarEfeito()
    {
        SFXManager.instance.SomDoPulo.Play();
    }

    private void ExecutarAnimacao()
    {
        animador.Play("animacao-mola-subindo");
    }
}
