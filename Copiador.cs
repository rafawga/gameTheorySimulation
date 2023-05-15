public class Copiador : Individuo
{
    public override string Escolha()
    {
        if (decisaoAnterior == "")
        {
            decisaoAnterior = "cooperar";
        }
        
        return decisaoAnterior;
    }
}