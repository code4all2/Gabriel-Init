using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject / Create Character", fileName = "char_")]
public class CharacterStats : ScriptableObject

{
    public string charName;
    public int fullLife;
    public bool invulnerable;
    public float timeBetweenDamage;

}
