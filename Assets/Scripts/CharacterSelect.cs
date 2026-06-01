using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    [Header("Nome da cena do jogo")]
    public string nomeDaCena = "Mapa";

    public void EscolherPersonagemP1()
    {
        GameManager.Instance.player1Choice = 0;
        GameManager.Instance.player2Choice = 1;

        SceneManager.LoadScene(nomeDaCena);
    }

    public void EscolherPersonagemP2()
    {
        GameManager.Instance.player1Choice = 1;
        GameManager.Instance.player2Choice = 0;

        SceneManager.LoadScene(nomeDaCena);
    }
}