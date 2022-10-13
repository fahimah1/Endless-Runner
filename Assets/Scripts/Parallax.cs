using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject player;
    Renderer rend;

    float playerStarPos;
    public float speed = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rend = GetComponent<Renderer>();
        playerStarPos = player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = (player.transform.position.x - playerStarPos) * speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
    }

}
