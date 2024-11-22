using FFImageLoading.Maui;
namespace infinite;
public class Inimigos
{
    List<Inimigo> inimigo=new List<Inimigo>();
    Inimigo atual=null;
    double minX=0;
    public Inimigos(double a)
    {
        minX=a;
    }
    public void Add (Inimigo a)
    {
        inimigo.Add(a);
        if (atual==null)
            atual=a;
        Iniciar();
    }
    public void Iniciar()
    {
        foreach(var e in inimigos)
            e.Reset();
    }
}