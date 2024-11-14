using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variável para controlar o tempo até o próximo spawn de obstáculo
    float clock;

    // Constante que define o tempo de cooldown entre os spawns de obstáculos (em segundos)
    const float cooldown = 2;

    // Array de prefabs de obstáculos que o SpawnManager pode instanciar
    // Adicione os diferentes tipos de obstáculos no Inspector do Unity
    [SerializeField] GameObject[] obstaclePrefabs;

    // Método Update chamado a cada frame
    private void Update()
    {
        // Se o contador de tempo (clock) chegou a zero ou abaixo, é hora de instanciar um novo obstáculo
        if (clock <= 0)
        {
            // Resetando o contador para o próximo intervalo de spawn
            clock = cooldown;

            // Escolhe aleatoriamente um dos obstáculos a partir do array obstaclePrefabs
            GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Instancia o obstáculo na posição à direita da tela (com base na largura da tela) 
            // e em uma posição aleatória no eixo Y (entre -2 e 2)
            Instantiate(obstacle, new Vector2(GameManager.instance.ScreenBounds.x, Random.Range(-2, 2)), Quaternion.identity);
        }
        else
        {
            // Caso o tempo ainda não tenha acabado, decrementa o valor de clock para contar o tempo restante
            clock -= Time.deltaTime;
        }
    }
}
