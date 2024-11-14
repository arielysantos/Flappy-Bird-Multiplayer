using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Velocidade de movimento do obst�culo, ajust�vel no Unity
    [SerializeField] float speed = 3.5f;

    // Array de tipos de obst�culos. Usado para associar diferentes tipos de obst�culos ao prefab.
    [SerializeField] GameObject[] obstaclePrefabs;

    // Refer�ncia ao Rigidbody2D do obst�culo para controlar o movimento
    Rigidbody2D rigidbody2D;

    // Vari�vel para controlar se o obst�culo foi instanciado corretamente
    GameObject selectedObstacle;

    // M�todo Start � chamado quando o script � iniciado
    private void Start()
    {
        // Obt�m a refer�ncia do Rigidbody2D no objeto atual
        rigidbody2D = GetComponent<Rigidbody2D>();

        // Se o array de prefabs de obst�culos n�o estiver vazio, escolhe aleatoriamente um obst�culo
        if (obstaclePrefabs.Length > 0)
        {
            selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            // Instancia um novo obst�culo aleat�rio do array, caso tenha mais de um tipo
            Instantiate(selectedObstacle, transform.position, Quaternion.identity);
        }
    }

    // M�todo Update � chamado a cada frame
    private void Update()
    {
        // Verifica se o obst�culo saiu da tela (baseado no valor de ScreenBounds.x)
        if (transform.position.x < -GameManager.instance.ScreenBounds.x)
        {
            // Se o obst�culo sair da tela, destr�i o objeto para n�o ocupar mem�ria
            Destroy(gameObject);
        }

        // Define a velocidade do obst�culo, movendo-o para a esquerda
        rigidbody2D.velocity = Vector2.left * speed;
    }
}

