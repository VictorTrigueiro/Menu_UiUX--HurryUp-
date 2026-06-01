using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int player1Choice = -1;
    public int player2Choice = -1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}