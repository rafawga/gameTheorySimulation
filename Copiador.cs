public class Copiador : Individuo
{
    public override Individuo Duplicar()
    {
        return new Copiador();
    }
    public override string Escolha()
    {
        if (decisaoAnterior == "")
        {
            decisaoAnterior = "cooperar";
        }

        return decisaoAnterior;
    }
}