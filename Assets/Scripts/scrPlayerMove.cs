using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerMove : MonoBehaviour
{
    public GameObject player;  // Refer�ncia ao objeto do player
    public Transform[] casas;  // Array de casas no tabuleiro (posi��es para mover o player)
    private int indiceAtual = 0; // �ndice atual da casa do player

    public void OpcaoCorreta()
    {
        // Mover o player em 10 posi��es � frente
        indiceAtual++;

        // Garante que o �ndice n�o ultrapasse o n�mero de casas dispon�veis
        if (indiceAtual >= casas.Length)
        {
            indiceAtual = casas.Length - 1; // �ltima casa
        }

        // Move o player para a nova posi��o
        player.transform.position = casas[indiceAtual].position;
    }

    public void OpcaoIncorreta()
    {
        // Aqui voc� pode adicionar o que deve acontecer quando a op��o for incorreta
        Debug.Log("Op��o Incorreta! Nenhum movimento.");
    }
}
