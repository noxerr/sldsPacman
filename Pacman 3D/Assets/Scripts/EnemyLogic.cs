﻿using UnityEngine;
using System.Collections;

public class EnemyLogic : MonoBehaviour {
    public bool canBeEaten;
    public float canBeEatenTime = 7.0f;
    public float spawnTime;
    public Transform SpawnLoc;
    public MonoBehaviour regularIA;
    private MonoBehaviour fleeIA;
    private float timeSinceLastEaten;
    private float timeLastDeath = -80.0f;
    private bool dead;
	// Use this for initialization
	void Start () {
        canBeEaten = false;
        fleeIA = gameObject.GetComponent<IAFlee>();
        fleeIA.enabled = false;
        timeSinceLastEaten = 0.0f;
        dead = false;
    }
    public void startEatenTimer() {
        timeSinceLastEaten = Time.time;
    }

    public void startDeathTimer() {
        timeLastDeath = Time.time;
    }

    public void killGhost() {
        //Al matar el fantasma lo desactivamos y empezamos el contador
        //No eliminamos el gameobject para que mantenga la IA
        timeLastDeath = Time.time;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        MeshRenderer rend = gameObject.GetComponentInChildren<MeshRenderer>();
        rend.enabled = false;
        regularIA.enabled = false;
        fleeIA.enabled = false;
        dead = true;
    }

    public void spawnGhost() {
        //Pasado el tiempo hacemos que reaparezca
        transform.position = SpawnLoc.transform.position;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;

        gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        MeshRenderer rend = gameObject.GetComponentInChildren<MeshRenderer>();
        rend.enabled = true;
        dead = false;
    }

	// Update is called once per frame
	void Update () {
        float d2 = Time.time;
        if (d2 - timeSinceLastEaten > canBeEatenTime) canBeEaten = false;
        if (dead && d2 - timeLastDeath > spawnTime) spawnGhost();
        if (!dead)
        {
            //Segun si tenemos powerup o no, activamos que el fantasma pueda ser comido
            if (canBeEaten)
            {
                regularIA.enabled = false;
                fleeIA.enabled = true;
            }
            else {
                regularIA.enabled = true;
                fleeIA.enabled = false;
            }
        }
    }
}
