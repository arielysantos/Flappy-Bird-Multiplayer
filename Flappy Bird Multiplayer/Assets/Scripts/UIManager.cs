using System.Collections;
using System.Collections.Generic;
using TMPro; // Biblioteca para trabalhar com TextMeshPro (UI de texto avan�ada)
using UnityEngine;
using UnityEngine.SceneManagement; // Para gerenciar cenas (carregar/recarregar)

public class UIManager : MonoBehaviour
{
    // Refer�ncias para os elementos da UI
    [SerializeField] TextMeshProUGUI scoreText, finalScoreText, recordText; // Para mostrar a pontua��o, a pontua��o final e o recorde
    [SerializeField] GameObject gameOverWindow; // Janela do Game Over

    // Array de janelas de UI (ex: menus, game over, etc) para maior flexibilidade
    [SerializeField] GameObject[] uiWindows; // Um array para armazenar diferentes janelas de UI (ex: tela de Game Over, tela de in�cio, etc)

    // Atualiza a pontua��o atual na interface (UI)
    public void UpdateScoreText()
    {
        // Atualiza o texto da pontua��o com o valor atual armazenado no GameManager
        scoreText.text = GameManager.instance.Score.ToString();
    }

    // Exibe a tela de Game Over
    public void GameOver()
    {
        // Exibe a pontua��o final do jogador na tela de Game Over
        finalScoreText.text = GameManager.instance.Score.ToString();

        // Exibe o recorde atual armazenado nos PlayerPrefs
        recordText.text = PlayerPrefs.GetInt("Record").ToString();

        // Ativa a janela de Game Over
        gameOverWindow.SetActive(true);

        // Pausa o jogo (reduz o tempo para 0)
        Time.timeScale = 0;
    }

    // Reinicia o jogo, carregando a cena atual
    public void Restart()
    {
        // Restaura o tempo para o valor normal
        Time.timeScale = 1;

        // Carrega a cena atual (reinicia o jogo)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fun��o para alternar entre diferentes janelas da UI, �til para telas de Menu e Game Over
    public void SwitchUIWindow(int index)
    {
        // Desativa todas as janelas da UI
        foreach (var window in uiWindows)
        {
            window.SetActive(false);
        }

        // Ativa a janela de UI no �ndice especificado
        if (index >= 0 && index < uiWindows.Length)
        {
            uiWindows[index].SetActive(true);
        }
        else
        {
            Debug.LogWarning("�ndice inv�lido para a janela de UI!");
        }
    }
}

