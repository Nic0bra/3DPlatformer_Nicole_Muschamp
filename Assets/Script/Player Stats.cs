using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    //Initalize Variables
    public float health = 100;
    public float speed = 5;
    public float jumpForce = 15;
    public float gravity = -30;
}
