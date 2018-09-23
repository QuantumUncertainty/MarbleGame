using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody rb;
    private int cubeCount, points;
    public Text countText;
    public Text winText;
    public Text pointText;

	// Use this for initialization
	void Start()
    {
        rb = GetComponent<Rigidbody>();
        cubeCount = 0;
        points = 0;
        setCountText();
        setPointText();
        winText.text = "";
        
	}
	
    //Used for physics code
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);          
            cubeCount++;
            points++;
            setCountText();
            setPointText();
        }
        else if (other.gameObject.CompareTag("2PtPickup"))
        {
            other.gameObject.SetActive(false);
            cubeCount++;
            points += 2;
            setCountText();
            setPointText();
        }
        else if (other.gameObject.CompareTag("3PtPickup"))
        {
            other.gameObject.SetActive(false);
            cubeCount++;
            points += 3;
            setCountText();
            setPointText();
        }
        else if (other.gameObject.CompareTag("KuzenPickup"))
        {
            winText.text = "Kappa";
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + cubeCount.ToString();
        if(cubeCount >= 12)
        {
            winText.text = "Fine, You Win"; 
        }
    }

    void setPointText()
    {
        pointText.text = "Points: " + points.ToString();
    }

}
