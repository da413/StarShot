
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
        minSpeedValue = 0.0001f;
        maxSpeedValue = controller.speed;
        
        upperBound = new Vector2(0,bounds.rect.height/2);
        lowerBound =  new Vector2(0,-bounds.rect.height/2);
        leftBound =  new Vector2(0,-bounds.rect.height/2);
        rightBound =  new Vector2(0,bounds.rect.height/2);

        upperThres = upperBound + Vector2.down;
        lowerThres = lowerBound + Vector2.up;
        leftThres = leftBound + Vector2.right;
        rightThres = rightBound + Vector2.left;
        
    }

    

    

    
}
