public abstract class Individuo
{
    public int moeda { get; set; } = 10;
    public int trapaceado { get; set; } = 0;
    public bool decisaoAnterior { get; set; } = false;

    public abstract Individuo Duplicar();

    public virtual bool Escolha()
    {
        return false;
    }
}