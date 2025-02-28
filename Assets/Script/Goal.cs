using UnityEngine;

public class Goal : MonoBehaviour
{
    //Check if that jawn reached the goal
    private void Start()
    {
        //Added tag so it can be found by collider
        gameObject.tag = "Goal";
    }
}
