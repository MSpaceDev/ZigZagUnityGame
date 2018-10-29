using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour {

    public GameObject effect;
    GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        gameManager.IncrementScore();
        Destroy(gameObject);
    }
}
