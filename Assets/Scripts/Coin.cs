using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IVRInteractible
{
    public int score = 1;
    public void OnReady()

    {
        GameController.instance.ChangeScore(1);
        Destroy(gameObject);
    }
}	