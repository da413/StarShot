
using System.Collections;
using UnityEngine;

public class PlayerCameraBounded : MonoBehaviour
{
    [SerializeField] RectTransform bounds;

    float minSpeedValue;
    float maxSpeedValue;
    private PlayerController controller;

    //Values for storing the bounds of the camera
    Vector2 upperBound;
    Vector2 lowerBound;
    Vector2 leftBound;
    Vector2 rightBound;

    //Values storing the thresholds to begin decreasing speed

    Vector2 upperThres;
    Vector2 lowerThres;
    Vector2 leftThres;
    Vector2 rightThres;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        minSpeedValue = 0.01f;
        if (controller)
        {
            maxSpeedValue = controller.speed;
        }
        
        
        upperBound = new Vector2(0,bounds.rect.height/2) + Vector2.down;
        lowerBound =  new Vector2(0,-bounds.rect.height/2) + Vector2.up;
        leftBound =  new Vector2(0,-bounds.rect.height/2) + Vector2.right;
        rightBound =  new Vector2(0,bounds.rect.height/2) + Vector2.left;

        //upperThres = upperBound + Vector2.down;
       // lowerThres = lowerBound + Vector2.up;
        //leftThres = leftBound + Vector2.right;
       // rightThres = rightBound + Vector2.left;

        
        
    }

   
    
    void Update()
    {
        //if the distance between the player's position is above the upperThres, start a function that slows the player down until they reach the upperbound
        if(gameObject.transform.position.y >= upperBound.y)
        {
            Debug.Log("The player's position is above the Threshold");
            controller.speed = minSpeedValue;

        }
        else
        {
            controller.speed = maxSpeedValue;
        }
    }

   
    

    

}
