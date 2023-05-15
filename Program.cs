using System.Security.Cryptography;

List<Individuo> StartSimulation()
{
    Console.Write("Digite a quantidade de colaborativos: ");
    int ColaborativosQntd = int.Parse(Console.ReadLine());
    Console.Write("Digite a quantidade de trapaceiros: ");
    int TrapaceiroQntd = int.Parse(Console.ReadLine());
    Console.Write("Digite a quantidade de rabugentos: ");
    int RabugnetoQntd = int.Parse(Console.ReadLine());
    Console.Write("Digite a quantidade de copiadores: ");
    int CopiadorQntd = int.Parse(Console.ReadLine());
    Console.Write("Digite a quantidade de tolerantes: ");
    int Tolerante = int.Parse(Console.ReadLine());
    List<Individuo> listaIndividuos = new List<Individuo>();
    for (int i = 0; i < ColaborativosQntd; i++)
        listaIndividuos.Add(new Colaborativo());
    for (int i = 0; i < TrapaceiroQntd; i++)
        listaIndividuos.Add(new Trapaceiro());
    for (int i = 0; i < RabugnetoQntd; i++)
        listaIndividuos.Add(new Rabugento());
    for (int i = 0; i < CopiadorQntd; i++)
        listaIndividuos.Add(new Copiador());
    for (int i = 0; i < Tolerante; i++)
        listaIndividuos.Add(new Tolerante());
        
    return listaIndividuos;
}

void Misturar(ref List<Individuo> list){
    RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
    int n = list.Count;
    while (n > 1)
    {
        byte[] box = new byte[1];
        do provider.GetBytes(box);
        while (!(box[0] < n * (Byte.MaxValue / n)));
        int k = (box[0] % n);
        n--;
        Individuo value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
}

void play(ref List<Individuo> listaIndividuos)
{
    for (int i = 0; i < listaIndividuos.Count; i += 2)
    {

        if (listaIndividuos[i].Escolha() == "trapacear" && listaIndividuos[i + 1].Escolha() == "trapacear")
        {
            listaIndividuos[i].moeda -= 1;
            listaIndividuos[i + 1].moeda -= 1;
        }

        else if (listaIndividuos[i].Escolha() == "cooperar" && listaIndividuos[i + 1].Escolha() == "cooperar")
        {
            listaIndividuos[i].moeda += 1;
            listaIndividuos[i + 1].moeda += 1;
        }

        else if (listaIndividuos[i].Escolha() == "trapacear" && listaIndividuos[i + 1].Escolha() == "cooperar")
        {
            listaIndividuos[i].moeda += 3;
            listaIndividuos[i + 1].moeda -= 1;
        }

        else if (listaIndividuos[i].Escolha() == "cooperar" && listaIndividuos[i + 1].Escolha() == "trapacear")
        {
            listaIndividuos[i].moeda -= 1;
            listaIndividuos[i + 1].moeda += 3;
        }

        listaIndividuos[i].decisaoAnterior = listaIndividuos[i + 1].Escolha();
        listaIndividuos[i + 1].decisaoAnterior = listaIndividuos[i].Escolha();

    }


    foreach (Individuo item in listaIndividuos)
    {
        System.Console.WriteLine($"{item}: {item.moeda}");
    }

    System.Console.WriteLine();

}

List<Individuo> listaIndividuos = StartSimulation();
Misturar(ref listaIndividuos);
play(ref listaIndividuos);
Misturar(ref listaIndividuos);
play(ref listaIndividuos);

