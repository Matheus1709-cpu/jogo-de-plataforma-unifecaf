using UnityEngine;

public class Trofeufinaldafase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            FindObjectOfType<GameManager>().RodarCoroutinePassarDeFase();
        }
        
        
        
    }
}
