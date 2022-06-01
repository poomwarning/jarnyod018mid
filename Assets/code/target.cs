
public class target 
{
    
    float Hp;
    float Speed;
    float Damage;
    public target(float newHp,float newSpeed,float newDamage)
    {
        
        HP = newHp;
        SPEED = newSpeed;
        DAMAGE = newDamage;
        
    }
  
    public float HP { get => Hp; set => Hp = value; }
    public float SPEED { get => Speed; set => Speed = value; }
    public float DAMAGE { get => Damage; set => Damage = value; }

}
