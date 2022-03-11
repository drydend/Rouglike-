﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Permanent character upgrade")]
public class CharacterPermanentStatsUpgrade : ScriptableObject
{
    [SerializeField]
    private CharacterType _characterType;
    [SerializeField]
    private UpgradeType _upgradeType;
    [SerializeField]
    private StatType _statType;
    [SerializeField]
    private float _value = 0f;

    public float Value => _value;
    public CharacterType CharacterType => _characterType;
    public UpgradeType UpgradeType => _upgradeType;
    public StatType StatType => _statType;
}

