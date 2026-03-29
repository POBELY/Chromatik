using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum LIFE { ON, OFF, LOCK };

public class HeartHUD : MonoBehaviour
{

    public GameObject fullHeart;
    public GameObject emptyHeart;
    private LIFE life = LIFE.LOCK;

    // Start is called before the first frame update
    void Start()
    {
        fullHeart.gameObject.SetActive(false);
        emptyHeart.gameObject.SetActive(false);
    }

    public void Unlock()
    {
        life = LIFE.OFF;
        Off();
    }

    public void On()
    {
        if (life != LIFE.LOCK)
        {
            fullHeart.gameObject.SetActive(true);
            emptyHeart.gameObject.SetActive(false);
        }
    }

    public void Off()
    {
        if (life != LIFE.LOCK)
        {
            fullHeart.gameObject.SetActive(false);
            emptyHeart.gameObject.SetActive(true);
        }
    }
}
