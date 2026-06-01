using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject personagemP1Prefab;
    public GameObject personagemP2Prefab;

    public Transform spawnJogador1;
    public Transform spawnJogador2;

    private void Start()
    {
        SpawnPersonagem(
            GameManager.Instance.player1Choice,
            spawnJogador1.position);

        SpawnPersonagem(
            GameManager.Instance.player2Choice,
            spawnJogador2.position);
    }

    void SpawnPersonagem(int escolha, Vector3 posicao)
    {
        GameObject prefab;

        if (escolha == 0)
            prefab = personagemP1Prefab;
        else
            prefab = personagemP2Prefab;

        Instantiate(prefab, posicao, Quaternion.identity);
    }
}