using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasonryPaymet : MonoBehaviour
{
    public Dropdown MaterialType;// Бокс выбора типа материалов кладки (блоки/кирпич/Porotherm)
    public Dropdown MasonryBrickType;// Бокс выбора типа кирпичной кладки( 0,5/1/1,5/2)
    public Dropdown BrickType; // Бокс выбора типа кирпича (одинарный/полуторный/двойной)
    public Dropdown Block; // Бокс выбора блоков(50/75/100/150/200/300/400/ФБС/ПСКЦ/СКЦ/ПКЦ)
    public Dropdown Porotherm;// Бокс выбора Parothem (80/120)
    public InputField LengthMasonry;//длина кладки
    public InputField WidthMasonry;//ширина кладки
    public double result;// итоговое значение
    public double R;// Теплопроводность кладки
    public bool made = false;
    public double[] blocksthickness = new double[] { 0.05, 0.075, 0.1, 0.15, 0.2, 0.3, 0.4, 0.188, 0.188, 0.188, 0.09 };



    public void OnMouseDown()
    {
        switch (MaterialType.value)
        {
            case 0: //в качестве типа материала выбраны блоки
                int i = 0;
                made = false;
                if ((Block.value >= 0) && (Block.value <= 7))
                {
                    result = System.Math.Ceiling(System.Convert.ToDouble(LengthMasonry.text) * System.Convert.ToDouble(WidthMasonry.text) / 156250);

                    do
                    {
                        if (Block.value == i)
                        {
                            R = blocksthickness[i] / 0.099 + 0.158420;
                            made = true;
                        }
                        i = i + 1;

                    }
                    while (made == false);
                    print (R);
                 
                }
                if   ((Block.value >= 7) && (Block.value <= 10))
                {
                    result = System.Math.Ceiling(System.Convert.ToDouble(LengthMasonry.text) * System.Convert.ToDouble(WidthMasonry.text) / 73320);
                    i = 7;
                    do
                    {
                        if (Block.value == i)
                        {
                            R = blocksthickness[i] / 0.099 + 0.158420;
                            made = true;
                        }

                        i = i + 1;

                    }
                    while (made == false);
                    print(R);
                }
                       
                
             break;
        }
    }

}