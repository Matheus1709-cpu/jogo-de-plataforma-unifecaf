using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesMenuInicial : MonoBehaviour
{
    [Header("Painéis da Interface")]
    public GameObject painelDoMenuInicial;
    public GameObject painelDaTelaDeCreditos;

    [Header("Cena Inicial")]
    public string nomeDaPrimeiraFase;

    public void CarregarJogo()
    {
        SceneManager.LoadScene(nomeDaPrimeiraFase);
    }

    public void AtivarPainelDoMenuInicial()
    {
        AlterarPaineis(true);
    }

    public void AtivarPainelDaTelaDeCreditos()
    {
        AlterarPaineis(false);
    }

    private void AlterarPaineis(bool mostrarMenu)
    {
        painelDoMenuInicial.SetActive(mostrarMenu);
        painelDaTelaDeCreditos.SetActive(!mostrarMenu);
    }

    public void SairDoJogo()
    {
        Debug.Log("Quitou do jogo");
        Application.Quit();
    }
}
