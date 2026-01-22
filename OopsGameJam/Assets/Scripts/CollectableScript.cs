using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CollectableScript : MonoBehaviour
{
    private int collectableScore = 0;
    public TMP_Text scoreText;
    public GameObject collector;

    public void Start()
    {
        string score = collectableScore.ToString();
    }

    public void Update()
    {
        scoreText.SetText("" + collectableScore);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectableScore++;
            Destroy(collector);
        }
    }
}
