using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    // HUD
    public HealthPoints healthPoints;

    // Single Gameobjects
    public Player player;


    // Get player by gameManager

    public Material channelMixerMaterial;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (channelMixerMaterial == null)
        {
            Debug.LogError("Shader Graph Material Asset not assigned! Please assign it in the Inspector.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public void setRed()
    {
        channelMixerMaterial.SetFloat("_Red", channelMixerMaterial.GetFloat("_Red") == 0f ? 1.0f : 0.0f);
    }
    public void setGreen()
    {
        channelMixerMaterial.SetFloat("_Green", channelMixerMaterial.GetFloat("_Green") == 0f ? 1.0f : 0.0f);
    }
    public void setBlue()
    {
        channelMixerMaterial.SetFloat("_Blue", channelMixerMaterial.GetFloat("_Blue") == 0f ? 1.0f : 0.0f);
    }
}
