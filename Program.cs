List<Individuo> listaIndividuos = Mundo.criarClass();
bool game = true;
int days = 0;
while (game)
{
    
    for (int i = 0; i < listaIndividuos.Count; i++)
    {
        if (listaIndividuos.Count < 2)
            game = false;
    }
    Mundo.Simular(listaIndividuos);
}

System.Console.WriteLine($"{listaIndividuos[0]} venceu o battle royale!");
System.Console.WriteLine($"Dias Passados: {days}");