
public struct DamageTaken
{
    public Health health;
    public Damage damage;

    public float hpLoss;
    public bool isKillingBlow;

    public DamageTaken(Health health, Damage damage, float hpLoss, bool isKillingBlow)
    {
        this.health = health;
        this.damage = damage;
        this.hpLoss = hpLoss;
        this.isKillingBlow = isKillingBlow;
    }
}