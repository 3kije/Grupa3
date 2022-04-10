using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public int Respawn;
    int keyA = 0;
    public GameObject player;
    public GameObject key;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("destroy"))
        {
            SceneManager.LoadScene(1);
                }
        if (other.CompareTag("exit") && keyA == 1)
            
        {
            SceneManager.LoadScene(0);
        }
        if (other.CompareTag("pickup"))
        {
            Destroy(key);
            keyA = 1;
            print (keyA);
        }
    }
   
}
