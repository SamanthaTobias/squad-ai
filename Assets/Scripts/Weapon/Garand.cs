public class M1Garand : IWeapon
{
    private readonly int ammoMax = 5;

    public string Name => "M1 Garand";

    public void Fire()
    {
        throw new System.NotImplementedException();
    }

    public void Reload()
    {
        throw new System.NotImplementedException();
    }
}
