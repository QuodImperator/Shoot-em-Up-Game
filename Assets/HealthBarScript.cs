using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Image healthBarImage;
    public List<Sprite> healthBarSprites;
    public Logic_script logic;

    void Start()
    {

    }

    void Update()
    {
        if (logic.playerHealth == 1)
        {
            healthBarImage.sprite = healthBarSprites[1];
        }
        else if (logic.playerHealth == 0)
        {
            healthBarImage.sprite = healthBarSprites[2];
        }
        else if (logic.playerHealth == -1)
        {
            healthBarImage.sprite = healthBarSprites[3];
        }
    }
}