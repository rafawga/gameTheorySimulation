public abstract class Individuo
{
    public int moeda { get; set; } = 10;
    public int trapaceado { get; set; } = 0;
    public string decisaoAnterior { get; set; } = "";

    public abstract Individuo Duplicar();

    public virtual string Escolha()
    {
        return "";
    }
}