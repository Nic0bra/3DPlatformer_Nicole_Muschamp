using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    //Initialize variables
    [SerializeField] PlayerStats bigVegasStats;
    [SerializeField] Image healthBarImage;

    // Update is called once per frame
    void Update()
    {
        //Update the health bar view on Game Canvas
        healthBarImage.fillAmount = bigVegasStats.health / bigVegasStats.maxHealth;
    }
}
