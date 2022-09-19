
public interface IPooledObject
{
    public bool IsTaken { get; }
    public void SetActive();
    public void Dismiss();
}
