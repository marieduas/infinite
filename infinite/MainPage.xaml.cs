using Microsoft.UI.Xaml.Controls;

namespace infinite;

public partial class MainPage : ContentPage
{
	

	bool estamorto = false;
	bool estaPulando = false;
	const int tempoEntreFrame = 25;
	int velocidade1 = 0;
	int velocidade2 = 0;
	int velocidade3 = 0;
	int velecidade = 0;
	int alturadajanela = 0;
	int larguradajanela = 0;
	const int forcaGravidade = 6;
	bool estaNoChao = true;
	bool estaNoAr = false;
	int tempoPulando = 0;
	int tempoNoAr = 0;
	const int forcaPulo = 8;
	const int maxTempoPulando = 6;
	const int maxTempoNoAr = 4;


	public MainPage()
	{
		InitializeComponent();
		Player = new Player(lobo);
		Player.Run();
	}


	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		CorrigeTamanhoCenario(w, h);
		CalculaVelocidade(w);
		Inimigos=new Inimigos(-w);
		Inimigos.Add(new Inimigo(inimigo1));
		Inimigos.Add(new Inimigo(inimigo2));
		Inimigos.Add(new Inimigo(inimigo3));
		Inimigos.Add(new Inimigo(inimigo4));
	}
	void CalculaVelocidade(double w)
	{
		velocidade1 = (int)(w * 0.001);
		velocidade2 = (int)(w * 0.004);
		velocidade3 = (int)(w * 0.008);
		velocidade = (int)(w * 0.001);
	}

	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var A in primeiraimg.Children)
			(A as inimigo1).WidthRequest = w;
		foreach (var A in segundaimg.Children)
			(A as inimigo2).WidthRequest = w;
		foreach (var A in terceiraimg.Children)
			(A as inimigo3).WidthRequest = w;
		foreach (var A in quartaimg.Children)
			(A as inimigo4).WidthRequest = w;

		primeiraimg.WidthRequest = w * 1.5;
		segundaimg.WidthRequest = w * 1.5;
		terceiraimg.WidthRequest = w * 1.5;
		quartaimg.WidthRequest = w * 1.5;;
	}
	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(primeiraimg);
		GerenciaCenarios(segundaimg);
		GerenciaCenarios(terceiraimg);
		GerenciaCenarios(quartaimg);

	}
	void MoveCenario()
	{
		primeiraimg.TranslationX -= velocidade1;
		segundaimg.TranslationX -= velocidade2;
		terceiraimg.TranslationX -=velocidade3;
		quartaimg.TranslationX -= velocidade;
	}
	void GerenciaCenarios(HorizontalStackLayout HSL)
	{
		var view = (HSL.Children.First() as Image);
		if (view.WidthRequest + HSL.TranslationX < 0)
		{
			HSL.Children.Remove(view);
			HSL.Children.Add(view);
			HSL.TranslationX = view.TranslationX;
		}
	}
	async Task Desenha()
	{
		while (!estamorto)
		{
			GerenciaCenarios();
			await Task.Delay(tempoEntreFrame);
			Player.Desenha;
			while(!estamorto)
			{
				GerenciaCenarios();
				if (Inimigos!=null)
				    Inimigos.Desenha(velocidade);
				if (!estaPulando && !estaNoAr)
				{
					AplicaGravidade();
					PlayerDesenha();
				}
				else
					AplicaPulo();
					await Task.Delay(tempoEntreFrame);
			}
		}
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		Desenha();
    }
	void AplicaGravidade()
	{
		if (Player.GetY()<0)
			player.MoveY(forcaGravidade);
		else if (Player.GetY()>0)
		{
			Player.SetY(0);
			estaNoChao = true;
		}
	}
	void AplicaPulo()
	{
		estaNoChao = false;
		if (estaPulando && tempoPulando>=maxTempoPulando)
		{
			estaPulando = false;
			estaNoAr = true;
			tempoNoAr = 0;
		}
		else if (estaNoAr && tempoNoAr>=maxTempoNoAr)
		{
			estaPulando = false;
			tempoPulando = 0;
			estaNoAr = false;
			tempoNoAr = 0;
		}
		else if (estaPulando && tempoPulando<maxTempoPulando)
		{
			Player.MoveY (-forcaPulo);
			tempoPulando++;
		}
		else if (estaNoAr)
			tempoNoAr++;
	}

}