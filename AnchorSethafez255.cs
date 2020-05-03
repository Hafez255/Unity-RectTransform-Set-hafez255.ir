using UnityEngine;
using UnityEditor;


//1- Create Editor Folder
//2- Put AnchorSethafez255 in Editor Folder
//3- Select Object in Scene And Press Button "H" To Automatically Set RectTransform
//4- Contact Us: hafez255.ir@gmail.com

[InitializeOnLoad]
public static class AnchorSethafez255
{
    static AnchorSethafez255()
    {

        SceneView.duringSceneGui += view =>
        {
            var e = Event.current;
            if (e != null && e.keyCode != KeyCode.None)
            {

                if (e.keyCode == KeyCode.H && e.type == EventType.KeyDown)
                {
                    Transform mytransform = Selection.activeTransform;
                    if (mytransform.parent != null)
                    {
                        float screenwidth = mytransform.parent.GetComponent<RectTransform>().rect.size.x;
                        float screenheigth = mytransform.parent.GetComponent<RectTransform>().rect.size.y;
                        float mytransformPosx = mytransform.GetComponent<RectTransform>().localPosition.x;
                        float mytransformPosY = mytransform.GetComponent<RectTransform>().localPosition.y;

                        float mytransformwidht = mytransform.GetComponent<RectTransform>().rect.size.x;
                        float mytransformheight = mytransform.GetComponent<RectTransform>().rect.size.y;
                        float minvaluex = (mytransformPosx - (mytransformwidht / 2)) / screenwidth;
                        float maxvaluex = (mytransformPosx + (mytransformwidht / 2)) / screenwidth;

                        float minvaluey = (mytransformPosY - (mytransformheight / 2)) / screenheigth;
                        float maxvaluey = (mytransformPosY + (mytransformheight / 2)) / screenheigth;

                        mytransform.GetComponent<RectTransform>().anchorMin = new Vector2(.5f + minvaluex, .5f + minvaluey);
                        mytransform.GetComponent<RectTransform>().anchorMax = new Vector2(.5f + maxvaluex, .5f + maxvaluey);
                        mytransform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;
                        mytransform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    }
                }

            }
        };
    }
}
