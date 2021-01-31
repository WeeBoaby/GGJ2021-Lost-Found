using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFloorSection : LevelSection
{
    public List<List<GameObject>> Layouts;

    public List<GameObject> Layout1;
    public List<GameObject> Layout2;
    public List<GameObject> Layout3;

    protected override void CustomOnAwake()
    {
        Layouts = new List<List<GameObject>>()
        {
            Layout1, Layout2, Layout3
        };

        SetLayout(Random.Range(0, Layouts.Count));
    }

    private void SetLayout(int layout)
    {
        var copyLayouts = Layouts;
        var desiredLayout = Layouts[layout];
        Layouts.RemoveAt(layout);

        copyLayouts.ForEach(badLayout =>
        {
            badLayout.ForEach(obj =>
            {
                obj.SetActive(false);
            });
        });

        desiredLayout.ForEach(obj =>
        {
            obj.SetActive(true);
        });

    }
}
