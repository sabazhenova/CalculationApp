using UnityEngine;
using UnityEngine.UI;

public class MasonryPaymet : MonoBehaviour
{
    public Dropdown MaterialType;// Бокс выбора типа материалов кладки (блоки/кирпич/Porotherm)
    public Dropdown MasonryBrickType;// Бокс выбора типа кирпичной кладки( 0,5/1/1,5/2)
    public Dropdown BrickType; // Бокс выбора типа кирпича (одинарный/полуторный/двойной)
    public Dropdown BrickMaterialsType;// Бокс выбора типа материала кирпича
    public Dropdown Block; // Бокс выбора блоков(50/75/100/150/200/300/400/ФБС/ПСКЦ/СКЦ/ПКЦ)
    public Dropdown Porotherm;// Бокс выбора Parothem (80/120)
    public InputField LengthMasonryInput;//длина кладки
    public InputField HeightMasonryInput;//ширина кладки
    public GameObject ResultImg; // Вывод подсчета
    public GameObject FailImg; // Вывод сообщения об ошибке
    public Text ResultMaterials;// Какой именно материал считался
    public Text Sum;//Итого нужно
    public Text ThermalResistance;//Итоговое термическое сопротивление
    public double result;// итоговое значение
    public double R;// Теплопроводность кладки
    public double LengthMasonry, HeightMasonry;//Переменные длины и высоты кладки








    public void OnMouseDown()
    {


        if ((HeightMasonryInput.text != "Введите высоту") & (LengthMasonryInput.text != "Введите длину"))
        {

            if (System.Convert.ToInt32(LengthMasonryInput.text) < 0)
            { LengthMasonry = System.Convert.ToInt32(LengthMasonryInput.text) * (-1); }
            else
            { LengthMasonry = System.Convert.ToInt32(LengthMasonryInput.text); }

            if (System.Convert.ToInt32(HeightMasonryInput.text) < 0)
            { HeightMasonry = System.Convert.ToInt32(HeightMasonryInput.text) * (-1); }
            else
            { HeightMasonry = System.Convert.ToInt32(HeightMasonryInput.text); }







            switch (MaterialType.value)
            {
                case 0: //в качестве типа материала выбраны блоки
                    double[] blocksthickness = new double[] { 0.05, 0.075, 0.1, 0.15, 0.2, 0.3, 0.4, 0.188, 0.188, 0.188, 0.09 }; //толщина блоков
                    double[] transcalency = new double[] { 0.58, 0.35, 0.12, 0.12 };//Теплопроводность ФБС/ПСКЦ/СКЦ/ПКЦ

                    if ((Block.value >= 0) && (Block.value <= 7))
                    {
                        result = System.Math.Ceiling((LengthMasonry * HeightMasonry) / 156250);
                        R = blocksthickness[Block.value] / 0.1 + 0.158420;
                        ResultMaterials.text = Block.options[Block.value].text;
                        ThermalResistance.text = System.Convert.ToString(System.Math.Round(R, 2));
                        Sum.text = System.Convert.ToString(result);
                        ResultImg.SetActive(true);
                    }
                    if ((Block.value >= 7) && (Block.value <= 10))
                    {
                        result = System.Math.Ceiling((LengthMasonry * HeightMasonry) / 73320);
                        R = blocksthickness[Block.value] / transcalency[Block.value - 7] + 0.158420;
                        ResultMaterials.text = Block.options[Block.value].text;
                        ThermalResistance.text = System.Convert.ToString(System.Math.Round(R, 2));
                        Sum.text = System.Convert.ToString(result);
                        ResultImg.SetActive(true);
                    }

                break;


                case 1: // в качестве материала выбран кирпич     
                    int[] MasonryBrickWidth = new int[] { 120, 250, 380, 540 };//ширина кладки
                    int[] brickheigth = new int[] { 65, 88, 138 };//высота кирпича
                    double[] transcalencyBrick = new double[] { 0.7, 0.49, 0.85 };
                    result = System.Math.Ceiling(((LengthMasonry * HeightMasonry) * MasonryBrickWidth[MasonryBrickType.value]) / (260 * 120 * (brickheigth[BrickType.value] + 10)));
                    R = ((System.Convert.ToDouble(MasonryBrickWidth[MasonryBrickType.value]) / 1000) / (transcalencyBrick[BrickMaterialsType.value]) + 0.158420);
                    ResultMaterials.text = BrickMaterialsType.options[BrickMaterialsType.value].text + " " + BrickType.options[BrickType.value].text.ToLower() + " кирпич";
                    ThermalResistance.text = System.Convert.ToString(System.Math.Round(R, 2));
                    Sum.text = System.Convert.ToString(result);
                    ResultImg.SetActive(true);
                break;



                case 2: // в качестве материала выбран Поротерм
                    double[] PorothermWidth = new double[] { 0.080, 0.120 };
                    result = System.Math.Ceiling((LengthMasonry * HeightMasonry) / (500 * 290));
                    R = PorothermWidth[Porotherm.value] / 0.148 + 0.158420;
                    ResultMaterials.text = Porotherm.options[Porotherm.value].text;
                    ThermalResistance.text = System.Convert.ToString(System.Math.Round(R, 2));
                    Sum.text = System.Convert.ToString(result);
                    ResultImg.SetActive(true);
                break;

            }

        }
        else
        { FailImg.SetActive(true);}

    }


}