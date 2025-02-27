using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    //Initalize Variables
    public float health = 100f;
    public float maxHealth = 100f;
    public float speed = 5f;
    public float jumpForce = 15f;
    public float gravity = -30;
}
