using UnityEngine;

[CreateAssetMenu(menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    //Initalize Variables
    public float health;
    public float maxHealth;
    public float speed;
    public float jumpForce;
    public float gravity;
}
