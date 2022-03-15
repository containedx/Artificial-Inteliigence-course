﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sealed => prevents from inheriting from it, no other class can ovethrow it
public sealed class World 
{
    private static readonly World instance = new World();
    private static GameObject[] hidingSpots;

    static World()
    {
        hidingSpots = GameObject.FindGameObjectsWithTag("hide");
    }

    private World() { }

    public static World Instance
    {
        get { return instance; }
    }

    public GameObject[] GetHidingSpots()
    {
        return hidingSpots;
    }
}
