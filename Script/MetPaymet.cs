using System;
using UnityEngine;
using UnityEngine.UI;

public class MetPaymet : MonoBehaviour
{
    public GameObject Button; // кнопка рассчета
    public GameObject LenghtObj;
    public GameObject WidthObj;
    public GameObject Fail;//проверка на дурака
    public GameObject Summ; // Слой с рассчетом
    public InputField Length; // Длина
    public Text text6; //Текст ввода количества 6 волновых листов
    public Text text3; //Текст ввода количества 3 волновых листов
    public Text text1; //Текст ввода количества 1 волновых листов
    public InputField Width; // Ширина
    public Toggle Tog; // Рассчитывать на 1 скат
    double balance1 = 0; // Остаток 1
    double balance2 = 0; // Остаток 2
    double w1 = 0; // Количество листов 1 волна
    double w3 = 0; // Количество листов 3 волны
    double w6 = 0; // Количество листов 6 волны
    bool calculOver=false;
    public void Start()
    {
        Summ.SetActive(false);
        Length.text = "";
        Width.text = "";
        Button.GetComponent<BoxCollider2D>().enabled = true;

    }

    public void OnMouseDown()
    {
       
        if ((Length.text != "") & (Width.text != ""))
        {
                double length_ = Convert.ToDouble(Length.text);// Длина
                double width_ = Convert.ToDouble(Width.text);// Ширина
              if (length_ < 0) 
              {
                length_ *= -1;
              }

              if (width_<0)
              {
                width_ *= -1;
              }

          if ((width_ <= 2250)& (width_ > 1170))
          {
                w6=1;
                calculOver = true;
          }
          if  ((width_ <= 1170) & (width_ > 470))
          {
                w3=1;
                calculOver = true;
          }
          if (width_ <= 470)
          {
                w1=1;
                calculOver = true;
          }


                double qt_w = Math.Ceiling(width_ / 350);  // Количество волн
                double qt_s = Math.Ceiling(length_ / 1060);
                if (Tog.GetComponent<Toggle>().isOn == false)
                {
                qt_s *= 2;
                }
            if (calculOver == false)
            {
                if (qt_w >= 6)
                {
                    w6 = Math.Floor(qt_w / 6); // Сколько листов 6 волн нужно на ширину ската
                    balance1 = qt_w - (w6 * 6); // осталость непокрытой длины
                }
                else
                {
                    balance1 = qt_w;
                }
                if (balance1 >= 3)
                {
                    w3 = Math.Floor(balance1 / 3); // Сколько листов 3 волны нужно на оставшуюся ширину ската
                    balance2 = balance1 - (w3 * 3); // осталось непокрытой длины
                }
                else
                {
                    w1 = balance1 / 1; // Сколько листов 1 волна нужно на оставшуюся ширину ската
                }

                if (balance2 > 0)
                {
                    w1 = Math.Ceiling(balance2);
                }
            }
                w1 *= qt_s;
                w3 *= qt_s;
                w6 *= qt_s;
            print("6 волн " + w6);
                print("3 волны " + w3);
                print("1 волна " + w1);
            
                Summ.SetActive(true);
                Button.GetComponent<BoxCollider2D>().enabled = false;
                text6.text = Convert.ToString(w6);
                text3.text = Convert.ToString(w3);
                text1.text = Convert.ToString(w1);
                Length.text = "";
                Width.text = "";
                Tog.GetComponent<Toggle>().isOn = false;
            }
              else { Fail.SetActive(true); }

            }
}

