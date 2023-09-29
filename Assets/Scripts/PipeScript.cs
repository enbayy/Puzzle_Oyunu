using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{

    float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField]
    bool isPlaced = false;

    int PossibleRots = 1;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start()
    {
        PossibleRots = correctRotation.Length;
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (PossibleRots > 1)
        {
            if (transform.eulerAngles.z == correctRotation[0] || transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                gameManager.correctMove();
            }
        }
    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));
        Vector3 currentRotation = transform.eulerAngles;


        if (PossibleRots > 1)
        {
            if (AreRotationsClose(currentRotation, new Vector3(0, 0, correctRotation[0])) || AreRotationsClose(currentRotation, new Vector3(0, 0, correctRotation[1])) && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
        else
        {
            if (AreRotationsClose(currentRotation, new Vector3(0, 0, correctRotation[0])) && isPlaced == false)
            {
                isPlaced = true;
                gameManager.correctMove();
            }
            else if (isPlaced == true)
            {
                isPlaced = false;
                gameManager.wrongMove();
            }
        }
    }
    private bool AreRotationsClose(Vector3 a, Vector3 b, float tolerance = 1e-3f)
    {
        return Mathf.Abs(a.x - b.x) < tolerance &&
               Mathf.Abs(a.y - b.y) < tolerance &&
               Mathf.Abs(a.z - b.z) < tolerance;
    }
}
