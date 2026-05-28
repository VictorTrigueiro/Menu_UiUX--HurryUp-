using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    [Header("Botões")]
    public Button playButton;   // Botão que será desabilitado
    public Button backButton;   // Botão de voltar

    [Header("Tempo para reabilitar")]
    public float enableDelay = 0.20f;

    // Chame isso no botão Play
    public void OnPlayPressed()
    {
        playButton.interactable = false;
    }

    // Chame isso no botão Voltar
    public void OnBackPressed()
    {
        StartCoroutine(EnableButtonAfterDelay());
    }

    private IEnumerator EnableButtonAfterDelay()
    {
        yield return new WaitForSeconds(enableDelay);

        playButton.interactable = true;
    }
}