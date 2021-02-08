using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float money = 0f;
    [SerializeField] TMP_Text moneyText;
    [SerializeField] float growthStage = 0f;
    [SerializeField] TMP_Text growthStageText;
    [SerializeField] float seedPotential = 99f;
    [SerializeField] TMP_Text seedPotentialText;
    [Header("Input")]
    [SerializeField] float water = 75f;
    [SerializeField] float waterDecreaseFactor = 0.4f;
    [SerializeField] TMP_Text waterText;
    [SerializeField] float fertilizer = 75f;
    [SerializeField] float fertilizeDecreaseFactor = 0.6f;
    [SerializeField] TMP_Text fertilizerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GrowthStage();
        Water();
        Fertilizer();
        GameOver();
    }
    private void GrowthStage()
    {
        growthStage += Time.deltaTime;
        growthStageText.text = Mathf.FloorToInt(growthStage).ToString();
    }
    private void Water()
    {
        water -= Time.deltaTime / waterDecreaseFactor;
        waterText.text = Mathf.FloorToInt(water).ToString();
        
        if (water > 75)
        {
            seedPotential -= Time.deltaTime;
        }
        else if (water < 50 && water >= 35)
        {
            seedPotential -= Time.deltaTime / 0.5f;
        }
        else if (water < 35 && water >= 20)
        {
            seedPotential -= Time.deltaTime / 0.25f;
        }
        else if (water < 20)
        {
            seedPotential -= Time.deltaTime / 0.1f;
        }        
    }
    private void Fertilizer()
    {
        fertilizer -= Time.deltaTime / fertilizeDecreaseFactor;
        fertilizerText.text = Mathf.FloorToInt(fertilizer).ToString();

        if (fertilizer < 75)
        {
            // todo fertilizer decrease thing
        }
    }
    private void GameOver()
    {
        if(seedPotential <= 0)
        {
            print("GameOver");
        }
    }
}
