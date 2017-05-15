using UnityEngine;
using System.Collections;

public class AnimationPiernas : MonoBehaviour {
    private Transform[] childs;
    private float elapsedTime;

	// Use this for initialization
	void Start () {
        childs = GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {

        elapsedTime += 2*Time.deltaTime;
        //cojo las piernas izquierdas/derechas y las roto haciendo elipses para simular el movimiento de las piernas humanas
        childs[1].localPosition = new Vector3(0, 0, Mathf.Cos(elapsedTime * 8) * 1.2f);
        childs[5].localPosition = new Vector3(0, 0, Mathf.Cos(elapsedTime * 8) * 1.2f);
        childs[22].localPosition = new Vector3(0, 0, Mathf.Cos(elapsedTime * 8) * 1.2f);

        //la resta del mathf pi es para restarle medio semicirculo para que las piernas no vayan paralelas
        childs[2].localPosition = new Vector3(0, 0, Mathf.Cos(elapsedTime * 8 - Mathf.PI) * 1.2f);
        childs[6].localPosition = new Vector3(0, 0, Mathf.Cos(elapsedTime * 8 - Mathf.PI) * 1.2f);
        childs[23].localPosition = new Vector3(0, 0, Mathf.Cos(elapsedTime * 8 - Mathf.PI) * 1.2f);


	}
}
