using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    [SerializeField] PlayerStats bigVegasStats;
    [SerializeField] Image healthBarImage;

    // Update is called once per frame
    void Update()
    {
        healthBarImage.fillAmount = bigVegasStats.health / bigVegasStats.maxHealth;
    }
}
