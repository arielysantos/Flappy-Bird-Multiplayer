using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    // Inst�ncia �nica do GameManager (padr�o Singleton)
    public static GameManager instance;

    // M�todo Awake para garantir que a inst�ncia do GameManager seja �nica
    private void Awake()
    {
        if (instance == null)
        {
            // Se n�o houver inst�ncia, define esta como a inst�ncia do GameManager
            instance = this;
        }
        else if (instance != this)
        {
            // Se j� houver uma inst�ncia, destr�i este objeto para manter a unicidade
            Destroy(gameObject);
        }

        // Define as bordas da tela com base na resolu��o da tela
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
    #endregion

    // Defini��o das vari�veis para gerenciar a pontua��o e as bordas da tela
    Vector2 screenBounds;
    int score;

    // Array para armazenar m�ltiplas pontua��es (por exemplo, de m�ltiplos jogos ou jogadores)
    [SerializeField] int[] highScores;  // Um array de pontua��es (high scores)

    // Propriedade para acessar as bordas da tela
    public Vector2 ScreenBounds { get => screenBounds; }

    // Propriedade para acessar e modificar a pontua��o atual
    public int Score { get => score; set => score = value; }

    // M�todo para adicionar uma nova pontua��o ao array de high scores
    public void AddHighScore(int newScore)
    {
        // Adiciona a nova pontua��o ao array
        // Se houver espa�o no array, adiciona a pontua��o e ordena
        for (int i = 0; i < highScores.Length; i++)
        {
            if (newScore > highScores[i])
            {
                // Desloca as pontua��es para baixo para dar lugar � nova pontua��o
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                }
                // Insere a nova pontua��o no array
                highScores[i] = newScore;
                break;
            }
        }
    }

    // M�todo para exibir as pontua��es mais altas (high scores)
    public void DisplayHighScores()
    {
        // Exibe as pontua��es mais altas no console para fins de depura��o
        Debug.Log("High Scores:");
        foreach (var score in highScores)
        {
            Debug.Log(score);
        }
    }
}
