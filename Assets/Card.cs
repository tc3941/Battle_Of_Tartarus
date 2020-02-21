using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public string name;
    public bool flipped = false;
    public bool selected,placed;
    public int num;
    public int flipNum;
    public float health,damage,magic, healthMod, damageMod, magicMod;
    public string weakenedStat, className,target;
    public bool effectActivated;
    public Card targetCard;
    public GameObject playField,cardPreview;
    // Start is called before the first frame update
    void Start()
    {
        name = this.gameObject.name;
        selected = false;
        placed = false;
        effectActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!flipped)
        {
            flipNum = 1;
        }
        else
        {
            flipNum = -1;
        }
        flipCheck();
    }
    public float TotalHealth()
    {
        return health + healthMod;
    }
    public float TotalDamage()
    {
        return damage + damageMod;
    }
    public float TotalMagic()
    {
        return magic + magicMod;
    }

    public void flipCheck()
    {
        this.transform.eulerAngles = new Vector3(flipNum*90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    }

    public void ActivateRonin(string stat)
    {
        if(stat == "Health")
            healthMod += 5;

        if (stat == "Damage")
            damageMod += 5;


        if (stat == "Magic")
            magicMod += 5;

        effectActivated = true;
    }
    public void ActivateLionel(Card target,Card target2, string nameOfCardPlayed)//This is gonna suck to program
    {
        ActivateDarkLord(target, target2);

        effectActivated = true;
    }
    public void ActivateLionel(string stat, string nameOfCardPlayed)
    {
        if (nameOfCardPlayed == "Ronin")
        {
            ActivateRonin(stat);
        }
    }
    public void ActivateLionel(Card target, string stat, string nameOfCardPlayed)//This is gonna suck to program
    {
        
        if (nameOfCardPlayed == "Assassin")
        {
            ActivateAssassin(target, stat);
        }
        else if(nameOfCardPlayed == "Shaggy"&&(stat == "X"||stat == "x"||stat == "O"||stat == "o"))
        {
            ActivateShaggy(target, stat);
        }  
        else if (nameOfCardPlayed == "Blacksmith" && (stat == "X" || stat == "x" || stat == "O" || stat == "o"))
        {
            ActivateBlackSmith(target, stat);
        }

        effectActivated = true;

    }
    public void ActivateLionel(Card target, string nameOfCardPlayed)//This is gonna suck to program
        {
        
        if(nameOfCardPlayed == "Grog")
        {
            ActivateGrog(target);
        }
        else if (nameOfCardPlayed == "Monk")
        {
            ActivateMonk(target);
        }
        effectActivated = true;
    }
    public void ActivateLionel(Card target, string incStat, string decStat, string nameOfCardPlayed)
    {
        ActivateDante(target, incStat, decStat);

        effectActivated = true;
    }

    public void ActivateAssassin(Card target, string stat)//
    {
        if (stat == "Health")
            target.healthMod += 4;

        if (stat == "Damage")
            target.damageMod += 4;

        if (stat == "Magic")
            target.magicMod += 4;

        effectActivated = true;
    }

    public void ActivateDante(Card target,string incStat, string decStat)//
    {
        if (incStat == "Health")
            target.healthMod += 5;

        if (incStat == "Damage")
            target.damageMod += 5;

        if (incStat == "Magic")
            target.magicMod += 5;

        if (decStat == "Health")
            target.healthMod -= 6;

        if (decStat == "Damage")
            target.damageMod -= 6;

        if (decStat == "Magic")
            target.magicMod -= 6;

        effectActivated = true;
    }

    public void ActivateShaggy(Card target, string XorO)//
    {
        if(XorO == "X"||XorO == "x")
        {
            target.magicMod = (2*target.magicMod) + target.magic;
            target.damageMod = (2 * target.damageMod) + target.damage;
            target.healthMod = (2 * target.healthMod) + target.health;
        }
        else
        {
            target.magicMod = (target.magicMod /2) - (target.magic /2);
            target.damageMod = (target.damageMod / 2) - (target.damage / 2);
            target.healthMod = (target.healthMod / 2) - (target.health / 2);
        }

        effectActivated = true;
    }

    public void ActivateDarkLord(Card target1, Card target2)//
    {
        Vector3 temp1 = target1.gameObject.transform.position;
        Vector3 temp2 = target2.gameObject.transform.position;
        target1.gameObject.transform.position = temp2;
        target2.gameObject.transform.position = temp1;

        effectActivated = true;
    }

    public void ActivateBlackSmith(Card target ,string XorO)
    {
        if((XorO == "X"||XorO == "x")&&target.className == "Assassin")
        {
            target.damageMod += 3;
        }
        else if ((XorO == "o" || XorO == "O") && target.className == "Fighter")
        {
            target.healthMod += 3;
        }
        effectActivated = true;
    }
    public void ActivateGrog(Card target)//
    {
        float num2 = (target.health - 1);
        num2 = num2 * -1;
        //target.healthMod = 0;
       // target.healthMod =(target.health - 1);
        target.healthMod = num2;
        effectActivated = true;
    }
    public void ActivateMonk(Card target)//
    {
        target.magicMod = 0;
        target.damageMod = 0;
        target.healthMod = 0;
        effectActivated = true;
    }
}
