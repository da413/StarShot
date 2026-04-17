
using UnityEngine;

public interface IObjectPool
{
    GameObject GetFrontOfPool(); //gets the first game object in the pool
    void AppendToBackOfPool(); //stores the used game object at the end of the pool


}
