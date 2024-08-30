using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{

    public GameObject winningBoard;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        winningBoard.SetActive(true);
        GetComponent<AudioSource>().Play();
    }
}
