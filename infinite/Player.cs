namespace infinite;
public delegate void Callback();
public class Player : Animation
{
    public Player (Image a) : base (a)
    {
        for (int i = 1; i<=24;++i)
             Animation.Add ($"lobo{i.ToString("D2")}.png");
        for (int i =1; i <=27;++i)
             Animation.Add($"lobomorre{i.ToString("D2")}.png");

             SetAnimacaoAtiva(1);
    }
     
                public void Die ()
                {
                    loop=false;
                    SetAnimacaoAtiva(2);
                }

                public void Run()
                {
                    loop=true;
                    SetAnimacaoAtiva(1);
                    Player();
                }

             
}