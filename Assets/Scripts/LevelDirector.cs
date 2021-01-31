using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDirector : MonoBehaviour
{
    public List<LevelSection> LevelSections;
    public LevelSection Beginning;

    public int Sections = 4;

    void Awake()
    {
        LevelSection previousSection = Beginning;
        for (int i = 0; i < Sections; ++i)
        {
            previousSection = Instantiate(LevelSections[Random.Range(0, LevelSections.Count)], previousSection.Exit.transform.position, Quaternion.identity);
        }
    }
}
