using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide_sprite_stair : MonoBehaviour
{

    public SpriteRenderer[] spriteRenderers;

    // Start is called before the first frame update
    void Start()
    {
        foreach(var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.enabled = false;
        }
    }
}
