namespace infinite;

public partial class MainPage : ContentPage
{
	bool estaMorto = false;
	bool estaPulando = false;
	const int tempoEntreFrames = 25;
	    int velocidade1 = 0;
		int velocidade2 = 0;
		int velocidade3 = 0;
		int velocidade = 0;
		int larguraJanela = 0;
		int alturajanela = 0;

	protected override void OnSizeAllocated (double w, double h)
	{
		base.OnSizeAllocated (w, h);
		CorrigeTamanhoCenario (w, h);
		CalculaVelocidade(w);
	}
	void CalculaVelocidade (double w)
	{
		velocidade1 = (int) (w*0.001);
		velocidade2 = (int) (w*0.004);
		velocidade3 = (int) (w*0.008);
		velocidade = (int) (w*0.01);
	}
	void CorrigeTamanhoCenario(double w, double h)
	{
		foreach (var a in HorizontalStackLayout1.Childrew)
			(a as Image).WidthRequest = w;
		foreach (var a in HorizontalStackLayout2.Childrew)
		    (a as Image).HeightRequest = w;
		foreach (var a in HorizontalStackLayout3.Childrew)
		    (a as Image).HeightRequest = w;	
		foreach (var a in HorizontalStackLayoutChao.Childrew)
		    (a as Image).HeightRequest = w;
		
		HorizontalStackLayout1.WidthRequest = w*1.5;
		HorizontalStackLayout2.WidthRequest = w*1.5;
		HorizontalStackLayout3.WidthRequest = w*1.5;
		HorizontalStackLayoutChao.WidthRequest = w*1.5;
	}
}

