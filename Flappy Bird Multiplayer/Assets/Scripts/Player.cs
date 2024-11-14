using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Constante para definir a for�a do pulo
    const float jumpForce = 8;

    // Refer�ncia para o Rigidbody2D do jogador, que controla sua f�sica
    Rigidbody2D rigidbody2D;

    // Refer�ncia para o UIManager, respons�vel pela interface do usu�rio
    UIManager managerUI;

    // Array de tags de objetos que o jogador pode interagir (obst�culos ou itens de pontua��o)
    [SerializeField] string[] interactableTags = { "Obstacle", "Score" };

    // M�todo Start chamado ao iniciar o jogo
    private void Start()
    {
        // Obt�m o componente Rigidbody2D do jogador para poder modificar sua f�sica
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Encontra o UIManager na cena para atualizar a interface do usu�rio
        managerUI = FindObjectOfType<UIManager>();
    }

    // M�todo Update chamado a cada frame
    private void Update()
    {
        // Verifica se o bot�o esquerdo do mouse foi pressionado (Mouse0 � o bot�o esquerdo)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Zera a velocidade do Rigidbody2D para parar qualquer movimento anterior
            rigidbody2D.velocity = Vector3.zero;

            // Aplica uma for�a para cima no Rigidbody2D para fazer o jogador pular
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // M�todo chamado quando o jogador colide com outro objeto
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto colidido � um "Obstacle" ou "Score" usando o array de tags
        foreach (string tag in interactableTags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                // Se o objeto colidido for um obst�culo, chama o m�todo de Game Over
                if (tag == "Obstacle")
                {
                    GameOver();
                }
                // Se o objeto colidido for um item de pontua��o, aumenta a pontua��o e atualiza a UI
                else if (tag == "Score")
                {
                    GameManager.instance.Score++;
                    managerUI.UpdateScoreText();
                }
            }
        }
    }

    // M�todo chamado quando o jogador perde
    void GameOver()
    {
        // Verifica se a pontua��o do jogo atual � maior que a pontua��o de recorde
        if (PlayerPrefs.GetInt("Record") < GameManager.instance.Score)
        {
            // Atualiza o recorde com a pontua��o atual
            PlayerPrefs.SetInt("Record", GameManager.instance.Score);
        }

        // Chama o m�todo GameOver do UIManager para atualizar a interface
        managerUI.GameOver();
    }
}
