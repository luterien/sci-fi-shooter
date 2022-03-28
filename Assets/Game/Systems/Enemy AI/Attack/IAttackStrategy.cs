
public interface IAttackStrategy
{
    public bool IsComplete { get; set; }

    void OnEnter();
    void Tick(float deltaTime);
    void OnExit();
}