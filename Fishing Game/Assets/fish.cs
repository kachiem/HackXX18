using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fish : MonoBehaviour {

    MeshRenderer thisRenderer;

    public Color drugColor;

    private float speed = 1.0f;

    private Vector3 vect;

    private float xDir;
    private float zDir;

    public float counter;
    public float dist;

    private bool caught;

    public int numCaught;

    public int bait = 30;

    public Text scoreboard;

    private int xMin = 264;
    private int xMax = 307;

    private int zMin = 164;
    private int zMax = 175;

	// Use this for initialization
	void Start () {
        thisRenderer = GetComponent<MeshRenderer>();
        drugColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        Material newMaterial = new Material(thisRenderer.material);
        newMaterial.SetColor("_Color", drugColor);
        thisRenderer.material = newMaterial;

        vect = new Vector3(0.0f, 0.0f, 0.0f);

        counter = 0.0f;
        dist = 15.0f;

        caught = false;
        numCaught = 0;
        bait = 30;

        scoreboard.text = "Fish Caught: " + numCaught + "\nBait: " + bait;

		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            bait -= 1;
        }
        if (bait <= 0) {
            Destroy(gameObject);
        }

        scoreboard.text = "Fish Caught: " + numCaught + "\nBait: " + bait;
        if (thisRenderer.transform.position.y < 30){//} || thisRenderer.transform.position.y > 70) {
            thisRenderer.transform.position = new Vector3(286, 40, 170);
        }
	}

    void FixedUpdate() {
        if (caught == true) {
            caught = false;
            thisRenderer.transform.position = new Vector3(286, 40, 170);

        }

        counter = counter + 0.2f;
        if(counter >= 2) {
            counter = 0.0f;
            int i = Random.Range(0, 10);
            if (i < 2) {
                xDir = Random.Range(-1.0f, 1.0f);
                zDir = Random.Range(-1.0f, 1.0f);
            }

            vect = new Vector3(xDir, 0, zDir);

            int jump = Random.Range(0, 1000);
            if(jump < 200){// && transform.position.y < 2.5) {
                vect = new Vector3(xDir, 7.0f, zDir);
            }
            thisRenderer.transform.Translate(vect * dist * Time.deltaTime);
        }
        thisRenderer.transform.Translate(vect * speed * Time.deltaTime);
    }

	private void OnCollisionEnter(Collision target) {
        if(target.gameObject.tag.Equals ("hook") == true) {
            numCaught += 1;
            dist += 5.0f;
            bait += 10;


            drugColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
            Material newMaterial = new Material(thisRenderer.material);
            newMaterial.SetColor("_Color", drugColor);
            thisRenderer.material = newMaterial;

            Vector3 v1 = new Vector3(0.2f, 0.2f, 0.2f);
            thisRenderer.gameObject.transform.localScale -= v1;
        }
		
	}
}
