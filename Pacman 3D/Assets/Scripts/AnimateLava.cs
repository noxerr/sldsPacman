using UnityEngine;
using System.Collections;

public class AnimateLava : MonoBehaviour {
    private Renderer rend;
    //private float time;
    private Vector2 offset;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        //time = 0;
        offset = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        //time += Time.deltaTime;
        //Sumamos offset a la textura de la lava para crear el efecto de movimiento
        offset.y += Time.deltaTime/4;
        rend.material.SetTextureOffset("_MainTex", offset); 
	}
}
