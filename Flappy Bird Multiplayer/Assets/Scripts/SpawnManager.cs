using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Vari�vel para controlar o tempo at� o pr�ximo spawn de obst�culo
    float clock;

    // Constante que define o tempo de cooldown entre os spawns de obst�culos (em segundos)
    const float cooldown = 2;

    // Array de prefabs de obst�culos que o SpawnManager pode instanciar
    // Adicione os diferentes tipos de obst�culos no Inspector do Unity
    [SerializeField] GameObject[] obstaclePrefabs;

    // M�todo Update chamado a cada frame
    private void Update()
    {
        // Se o contador de tempo (clock) chegou a zero ou abaixo, � hora de instanciar um novo obst�culo
        if (clock <= 0)
        {
            // Resetando o contador para o pr�ximo intervalo de spawn
            clock = cooldown;

            // Escolhe aleatoriamente um dos obst�culos a partir do array obstaclePrefabs
            GameObject obstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Instancia o obst�culo na posi��o � direita da tela (com base na largura da tela) 
            // e em uma posi��o aleat�ria no eixo Y (entre -2 e 2)
            Instantiate(obstacle, new Vector2(GameManager.instance.ScreenBounds.x, Random.Range(-2, 2)), Quaternion.identity);
        }
        else
        {
            // Caso o tempo ainda n�o tenha acabado, decrementa o valor de clock para contar o tempo restante
            clock -= Time.deltaTime;
        }
    }
}
