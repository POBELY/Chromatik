using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Material channelMixerMaterial;

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
