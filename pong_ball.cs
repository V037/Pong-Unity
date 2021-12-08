using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pong_ball : MonoBehaviour
{
    [SerializeField] private bool started = false;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private int space = 2;

    public Vector3 v3;

    private Vector3 ballpos1 = new Vector3(1,0,1);
    private Vector3 ballpos2 = new Vector3(-1,0,1);
    private Vector3 ballpos3 = new Vector3(1,0,-1);
    private Vector3 ballpos4 = new Vector3(-1,0,-1);
    public List<Vector3> possiblePositions;
 
    void Start()
    {
        possiblePositions.Add(ballpos1);
        possiblePositions.Add(ballpos2);
        possiblePositions.Add(ballpos3);
        possiblePositions.Add(ballpos4);
    }
 
    Vector3 ChooseRandom()
    {
        int randomPosition = Random.Range(0, possiblePositions.Count - 1);
        Vector3 positionChosen = possiblePositions[randomPosition];
        rb.AddRelativeForce(positionChosen * 2);
        return positionChosen; 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            ChooseRandom();
        }
    }

    void FixedUpdate()
    {
        if(started)
        {
            speed *= 1.0001f;
            rb.velocity = rb.velocity.normalized * speed;
            v3 = rb.velocity;
        }

        if(started && Mathf.Abs(v3.z) <  speed / space)
        {
            v3.z *= 2;
            rb.AddForce (v3 * Time.deltaTime, ForceMode.Impulse);
        }

        if(started && Mathf.Abs(v3.x) <  speed / space)
        {
            v3.x *= 2;
            rb.AddForce (v3 * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
