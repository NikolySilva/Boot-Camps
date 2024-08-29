using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;
    private Transform[] casas; // Refer�ncia �s casas no tabuleiro
    private int indiceAtual = 0;
    public float velocidade;
    private bool isMoving = false; // Controle de movimento

    private void Start()
    {
        casas = gameController.casas;
    }

    public bool IsMoving => isMoving; // Propriedade para verificar se o pe�o est� se movendo

    public void Mover(int passos)
    {
        int novoIndice = indiceAtual + passos;
        Debug.Log(novoIndice);

        // Garante que o �ndice n�o ultrapasse o n�mero de casas dispon�veis
        if (novoIndice >= casas.Length)
        {
            novoIndice = casas.Length - 1; // �ltima casa
        }

        if (novoIndice < 0)
        {
            novoIndice = 0;
        }

        // Atualiza o �ndice Atual
        indiceAtual = novoIndice;

        if (indiceAtual < casas.Length && indiceAtual >= 0)
        {
            StartCoroutine(MoverSuavemente(casas[indiceAtual].position));
        }
        else
        {
            Debug.LogError("Tentativa de acessar um �ndice fora dos limites: " + indiceAtual);
        }
    }

    private IEnumerator MoverSuavemente(Vector3 novaPosicao)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, novaPosicao) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, novaPosicao, velocidade * Time.deltaTime);
            yield return null;
        }
        transform.position = novaPosicao; // Garante que a posi��o final seja exata
        isMoving = false;
    }

    public int IndiceAtual()
    {
        return indiceAtual;
    }
}
