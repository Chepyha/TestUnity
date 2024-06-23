using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class main : MonoBehaviour
{
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite kr;
    public int Count;
    public GameObject canv;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject contain = gameObject;
            RectTransform Grid = contain.GetComponent<RectTransform>();
            Grid.sizeDelta = new Vector2(180 * (int)Math.Ceiling((double)Count / 3.0), 530);

            GameObject newButton = new GameObject("knopka"+i, typeof(Image), typeof(Button), typeof(LayoutElement));
            newButton.transform.SetParent(contain.transform);
            RectTransform rect = newButton.GetComponent<RectTransform>();
            Button butt = newButton.GetComponent<Button>();
            Image img = newButton.GetComponent<Image>();
            rect.localScale = new Vector3(1, 1, 1);
            int rand = UnityEngine.Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    img.sprite = sprite;

                    break;
                case 1:
                    img.sprite = sprite1;
                    break;
                case 2:
                    img.sprite = sprite2;
                    break;
                case 3:
                    img.sprite = sprite3;
                    break;
            }
            butt.onClick.AddListener(() => Click(img.sprite));
        }
    }


    void Click(Sprite s)
    {
        GameObject wind = new GameObject("Window", typeof(Image));
        RectTransform rec = wind.GetComponent<RectTransform>();
        Image im = wind.GetComponent<Image>();
        rec.localScale = new Vector3(1, 1, 1);
        im.sprite = s;
        wind.transform.SetParent(canv.transform);
        rec.sizeDelta = canv.transform.GetComponent<RectTransform>().sizeDelta;
        rec.anchoredPosition = new Vector2(0, 0);

        GameObject button = new GameObject("close", typeof(Image), typeof(Button));
        button.transform.SetParent(wind.transform);
        RectTransform rect = button.GetComponent<RectTransform>();
        Button butt = button.GetComponent<Button>();
        Image img = button.GetComponent<Image>();
        img.sprite = kr;
        rect.sizeDelta = new Vector2(130, 130);
        rect.localPosition = new Vector2(rec.rect.width/2-65, rec.rect.height/2 - 65);
        butt.onClick.AddListener(() => Disp(Wind: wind,Butt: button));
    }

    void Disp(GameObject Wind, GameObject Butt)
    {
        Destroy(Butt);
        Destroy(Wind);
    }
}
