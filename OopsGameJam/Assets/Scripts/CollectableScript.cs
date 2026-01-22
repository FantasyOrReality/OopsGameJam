using UnityEngine;
using UnityEngine.UI;

public class CollectableScript : MonoBehaviour
{
    private int collectableScore = 0;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectableScore = collectableScore + 1;
        }
    }
}
