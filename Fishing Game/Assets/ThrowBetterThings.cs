using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBetterThings : MonoBehaviour {
    public Rigidbody prefab;
    private Transform trans;
    public Rigidbody go;
    float distance = 10.0f;

    bool destroyed;

    public int bait2;



	// Use this for initialization
	void Start () {
        trans = prefab.transform;
        destroyed = true;
        bait2 = 30;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0)) {
            bait2 -= 1;

            if(destroyed == false) {
                Destroy(go.gameObject);

            }
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            position = Camera.main.ScreenToWorldPoint(position);
            go = Instantiate(prefab, trans.position, Quaternion.identity) as Rigidbody;

            go.transform.LookAt(position);

            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 5000);
            destroyed = false;
        }
	}

	private void OnCollisionEnter(Collision target) {
        if(target.gameObject.tag.Equals("fish") == true) {
            bait2 += 10;
                
        }
	}
}
