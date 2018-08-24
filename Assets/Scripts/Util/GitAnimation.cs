using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GitAnimation : MonoBehaviour
{
    public Texture[] PlayerTexture;
    [Range(1, 60)]
    public float FPS = 24;

    private RawImage RawImage;

    private void Start()
    {
        RawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        int gifNum = (int)((Time.time * FPS) % PlayerTexture.Length);
        RawImage.texture = PlayerTexture[gifNum];
    }
}