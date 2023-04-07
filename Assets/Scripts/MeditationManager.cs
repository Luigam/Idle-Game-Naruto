using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Contains all information related to the Meditation screen
/// </summary>
/// 

public class MeditationManager : MonoBehaviour
{
    [Header("Chakra")]
    [SerializeField] private float chakraAmount;
    [SerializeField] private float chakraPerClick;
    [SerializeField] private TextMeshProUGUI chakraAmountText;
    [SerializeField] private TextMeshProUGUI chakraClickButtonText;


    [Header("AutoClicker")]
    [SerializeField] private int autoClickLvl;

    [SerializeField] List<int> autoClickLvlChakraCost; //lista de costo de chakra para lvl el autoclick
    [SerializeField] List<int> autoClickChakraPerSec; //lista cuanto es el chakra por segundo dependiendo del lvl del autoclick

    [SerializeField] private TextMeshProUGUI autoClickLvlText;
    [SerializeField] private TextMeshProUGUI autoClickChakraPerSecText;


    // Start is called before the first frame update
    void Start()
    {
        UpdateAutoClickerText();
        chakraClickButtonText.text = "Click (+" + chakraPerClick + " Chakra)";
    }

    // Update is called once per frame
    void Update()
    {
        chakraAmount += autoClickChakraPerSec[autoClickLvl] * Time.deltaTime;
        UpdateChakraText();
    }

    public void GainChakraButton()
    {
        chakraAmount += chakraPerClick;
    }

    private void UpdateChakraText()
    {
        chakraAmountText.text = "Chakra: " + chakraAmount;
    }

    public void LevelUpAutoClickerButton()
    {
        if (chakraAmount >= autoClickLvlChakraCost[autoClickLvl] && autoClickLvl < autoClickLvlChakraCost.Count - 1) //suficiente chakra y menor que el lvl maximo?
        {
            chakraAmount -= autoClickLvlChakraCost[autoClickLvl];
            autoClickLvl += 1;
            UpdateAutoClickerText();
        }
    }

    public void UpdateAutoClickerText()
    {
        if (autoClickLvl == autoClickLvlChakraCost.Count - 1) //Max lvl?
        {
            autoClickLvlText.text = "Autoclicker Lvl Max";
            autoClickChakraPerSecText.text = "Chakra/sec: +" + autoClickChakraPerSec[autoClickLvl];
        }
        else
        {
            autoClickLvlText.text = "Autoclicker Lvl " + autoClickLvl + " (" + autoClickLvlChakraCost[autoClickLvl] + " Chakra to Lvl " + (autoClickLvl + 1) + ")";
            autoClickChakraPerSecText.text = "Chakra/sec: +" + autoClickChakraPerSec[autoClickLvl];
        }
        

    }
}
