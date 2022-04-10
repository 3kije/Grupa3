using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingPortal : MonoBehaviour
{

    public GameObject gameEndUI;

    // Start is called before the first frame update
    void Start()
    {
        gameEndUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("TheEnd");
            gameEndUI.gameObject.SetActive(true);
            Time.timeScale = 0;

        }
    }
}