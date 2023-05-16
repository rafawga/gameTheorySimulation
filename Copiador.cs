public class Copiador : Individuo
{
    public override Individuo Duplicar()
    {
        return new Copiador();
    }
    public override bool Escolha()
    {
        
        return decisaoAnterior;
    }
}