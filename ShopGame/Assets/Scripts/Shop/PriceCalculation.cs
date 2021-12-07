using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Game.Shop
{
    public class PriceCalculation : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_SellPriceText;
        [SerializeField] private TextMeshProUGUI m_PricePercentageText;

        [SerializeField] private int m_BuyPriceValue;
        [SerializeField] private int m_SellPriceValue;
        [SerializeField] private float m_PricePercentageValue;

        private int m_SellPrice;
        private int m_BuyPrice;


        void Update()
        {
            if (m_SellPriceValue != m_SellPrice || m_BuyPriceValue != m_BuyPrice)
            {
                CalculatePrice();
            }
            m_SellPrice = m_SellPriceValue;
            m_BuyPrice = m_BuyPriceValue;
        }

        private void CalculatePrice()
        {
            m_PricePercentageValue = 100f / m_BuyPriceValue * m_SellPriceValue;
            m_PricePercentageText.text = $"{m_PricePercentageValue.ToString("F1")}%";
            m_SellPriceText.text = $"${m_SellPriceValue}";
        }
    }
}
