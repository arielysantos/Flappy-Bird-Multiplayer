using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constante para definir a força do pulo
    const float jumpForce = 8;

    // Referência para o Rigidbody2D do jogador, que controla sua física
    Rigidbody2D rigidbody2D;

    // Referência para o UIManager, responsável pela interface do usuário
    UIManager managerUI;

    // Array de tags de objetos que o jogador pode interagir (obstáculos ou itens de pontuação)
    [SerializeField] string[] interactableTags = { "Obstacle", "Score" };

    // Método Start chamado ao iniciar o jogo
    private void Start()
    {
        // Obtém o componente Rigidbody2D do jogador para poder modificar sua física
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Encontra o UIManager na cena para atualizar a interface do usuário
        managerUI = FindObjectOfType<UIManager>();
    }

    // Método Update chamado a cada frame
    private void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado (Mouse0 é o botão esquerdo)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Zera a velocidade do Rigidbody2D para parar qualquer movimento anterior
            rigidbody2D.velocity = Vector3.zero;

            // Aplica uma força para cima no Rigidbody2D para fazer o jogador pular
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Método chamado quando o jogador colide com outro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido é um "Obstacle" ou "Score" usando o array de tags
        foreach (string tag in interactableTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                // Se o objeto colidido for um obstáculo, chama o método de Game Over
                if (tag == "Obstacle")
                {
                    GameOver();
                }
                // Se o objeto colidido for um item de pontuação, aumenta a pontuação e atualiza a UI
                else if (tag == "Score")
                {
                    GameManager.instance.Score++;
                    managerUI.UpdateScoreText();
                }
            }
        }
    }

    // Método chamado quando o jogador perde
    void GameOver()
    {
        // Verifica se a pontuação do jogo atual é maior que a pontuação de recorde
        if (PlayerPrefs.GetInt("Record") < GameManager.instance.Score)
        {
            // Atualiza o recorde com a pontuação atual
            PlayerPrefs.SetInt("Record", GameManager.instance.Score);
        }

        // Chama o método GameOver do UIManager para atualizar a interface
        managerUI.GameOver();
    }
}
