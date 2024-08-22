using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPlayerMove : MonoBehaviour
{
    public GameObject player;  // Referência ao objeto do player
    public Transform[] casas;  // Array de casas no tabuleiro (posições para mover o player)
    private int indiceAtual = 0; // Índice atual da casa do player

    public void OpcaoCorreta()
    {
        // Mover o player em 10 posições à frente
        indiceAtual++;

        // Garante que o índice não ultrapasse o número de casas disponíveis
        if (indiceAtual >= casas.Length)
        {
            indiceAtual = casas.Length - 1; // Última casa
        }

        // Move o player para a nova posição
        player.transform.position = casas[indiceAtual].position;
    }

    public void OpcaoIncorreta()
    {
        // Aqui você pode adicionar o que deve acontecer quando a opção for incorreta
        Debug.Log("Opção Incorreta! Nenhum movimento.");
    }
}
