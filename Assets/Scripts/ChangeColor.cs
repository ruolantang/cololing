﻿using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {
    static Color[] colors = { Color.blue, Color.red, Color.yellow };
    private GameObject player;
    private GameObject plane;
    private GameManager gm;
    private Skybox skybox;
    private Material plane_material;
    private Material player_material;
    private Color start_color;
    private Color end_color;
    private float duration;
    private float lerp;
    // Use this for initialization
    void Start () {
        gm = GameObject.Find("gameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        player_material = player.GetComponent<Renderer>().material;
        plane = GameObject.Find("Plane");
        var camera = GameObject.Find("Main Camera");
        skybox = camera.GetComponent<Skybox>();
        plane_material = plane.GetComponent<MeshRenderer>().material;
        start_color = Color.red;
        end_color = Color.green;
        duration = 1.0f;
        //plane.GetComponent<MeshRenderer>().material.color = new Color(0f, 0.1f,0.1f);
    }
	
	// Update is called once per frame
	void Update () {       
        lerp = Mathf.PingPong(Time.time, duration) / duration;
        //plane_material.color = Color.Lerp(start_color, end_color, lerp);
        //skybox.material.color = Color.Lerp(start_color, end_color, lerp);

        if (player.transform.position.x > gm.upper_bound && player.transform.position.x > gm.lower_bound)
        {
            if (gm.isCollided)
            {
                gm.isCollided = false;
                gm.upper_bound = 0;
                gm.lower_bound = gm.final_bound;
                var player_color = player_material.color;
                player_material.color = new Color(player_color.r + 0.1f, player_color.g + 0.1f, player_color.b + 0.1f); // 球的颜色怎么变
                // player_materal.color: Abeldo
                // Emission:
                // get: player_material.GetColor("_EmissionColor"); 
                // set: player_material.SetColor("_EmissionColor", new Color(...));
            }
            else
            {
                gm.isAlive = false;
            }
        }
        else if (player.transform.position.x >= gm.final_bound)
        {
            gm.isWinner = true;
        }       
    }
}
