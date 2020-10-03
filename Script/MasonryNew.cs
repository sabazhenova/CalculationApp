using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MasonryNew : MonoBehaviour
{
    public Dropdown ChoiceMaterials; //бокс выбора материала кладки
    public GameObject BrickImg; // кирпичная кладка
    public GameObject PorothermImg; // блоки Porotherm
    
    public void Update() //Изменение интерфейса в зависимости от выбора материала кладки
    {
        if (ChoiceMaterials.value == 0) //Если выбраны блоки
        {
            BrickImg.SetActive(false);
            PorothermImg.SetActive(false);
        }

        if (ChoiceMaterials.value == 1) //Если выбран кирпич
        {
               BrickImg.SetActive(true);
               PorothermImg.SetActive(false);
        }
        if (ChoiceMaterials.value == 2) //Если выбран поротерм
        {
            PorothermImg.SetActive(true);
            BrickImg.SetActive(false);
        }
    }
   

}
