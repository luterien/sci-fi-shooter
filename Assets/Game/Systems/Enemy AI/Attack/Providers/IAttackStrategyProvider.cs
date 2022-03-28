using System.Collections;
using UnityEngine;

public interface IAttackStrategyProvider
{
    IAttackStrategy Get();
}