public class Individuo
{
    public int moeda {get; set;} = 10;
    public int trapaceado = 0;
    public string decisaoAnterior {get; set;} = "";
    public virtual string Escolha()
    {
        return "";
    }
}