using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Velocidade de movimento do obstáculo, ajustável no Unity
    [SerializeField] float speed = 3.5f;

    // Array de tipos de obstáculos. Usado para associar diferentes tipos de obstáculos ao prefab.
    [SerializeField] GameObject[] obstaclePrefabs;

    // Referência ao Rigidbody2D do obstáculo para controlar o movimento
    Rigidbody2D rigidbody2D;

    // Variável para controlar se o obstáculo foi instanciado corretamente
    GameObject selectedObstacle;

    // Método Start é chamado quando o script é iniciado
    private void Start()
    {
        // Obtém a referência do Rigidbody2D no objeto atual
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Se o array de prefabs de obstáculos não estiver vazio, escolhe aleatoriamente um obstáculo
        if (obstaclePrefabs.Length > 0)
        {
            selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            // Instancia um novo obstáculo aleatório do array, caso tenha mais de um tipo
            Instantiate(selectedObstacle, transform.position, Quaternion.identity);
        }
    }

    // Método Update é chamado a cada frame
    private void Update()
    {
        // Verifica se o obstáculo saiu da tela (baseado no valor de ScreenBounds.x)
        if (transform.position.x < -GameManager.instance.ScreenBounds.x)
        {
            // Se o obstáculo sair da tela, destrói o objeto para não ocupar memória
            Destroy(gameObject);
        }

        // Define a velocidade do obstáculo, movendo-o para a esquerda
        rigidbody2D.velocity = Vector2.left * speed;
    }
}

