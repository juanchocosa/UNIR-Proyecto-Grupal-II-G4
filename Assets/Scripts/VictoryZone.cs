using UnityEngine;

public class VictoryZone : MonoBehaviour
{
    private bool playerInZone = false;

    void Update()
    {
        if (playerInZone)
        {
            bool tieneLlave = InventoryManager.instance.HasItemByName("llave");
            bool tieneMaletin = InventoryManager.instance.HasItemByName("maletin");

            if (tieneLlave && tieneMaletin)
            {
                UIManager.instance.ShowVictory();
            }
            else
            {
                UIManager.instance.ShowMissingItems(); // Aparece mensaje de que faltan objetos
            }

            playerInZone = false; // Evita que se repita el mensaje en cada frame
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}

