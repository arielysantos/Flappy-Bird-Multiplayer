using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    // Instância única do GameManager (padrão Singleton)
    public static GameManager instance;

    // Método Awake para garantir que a instância do GameManager seja única
    private void Awake()
    {
        if (instance == null)
        {
            // Se não houver instância, define esta como a instância do GameManager
            instance = this;
        }
        else if (instance != this)
        {
            // Se já houver uma instância, destrói este objeto para manter a unicidade
            Destroy(gameObject);
        }

        // Define as bordas da tela com base na resolução da tela
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    #endregion

    // Definição das variáveis para gerenciar a pontuação e as bordas da tela
    Vector2 screenBounds;
    int score;

    // Array para armazenar múltiplas pontuações (por exemplo, de múltiplos jogos ou jogadores)
    [SerializeField] int[] highScores;  // Um array de pontuações (high scores)

    // Propriedade para acessar as bordas da tela
    public Vector2 ScreenBounds { get => screenBounds; }

    // Propriedade para acessar e modificar a pontuação atual
    public int Score { get => score; set => score = value; }

    // Método para adicionar uma nova pontuação ao array de high scores
    public void AddHighScore(int newScore)
    {
        // Adiciona a nova pontuação ao array
        // Se houver espaço no array, adiciona a pontuação e ordena
        for (int i = 0; i < highScores.Length; i++)
        {
            if (newScore > highScores[i])
            {
                // Desloca as pontuações para baixo para dar lugar à nova pontuação
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                }
                // Insere a nova pontuação no array
                highScores[i] = newScore;
                break;
            }
        }
    }

    // Método para exibir as pontuações mais altas (high scores)
    public void DisplayHighScores()
    {
        // Exibe as pontuações mais altas no console para fins de depuração
        Debug.Log("High Scores:");
        foreach (var score in highScores)
        {
            Debug.Log(score);
        }
    }
}
