﻿namespace infinite;

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
	void GerenciaCenarios()
	{
		MoveCenario();
		GerenciaCenarios(HorizontalStackLayout1);
		GerenciaCenarios(HorizontalStackLayout2);
		GerenciaCenarios(HorizontalStackLayout3);
		GerenciaCenarios(HorizontalStackLayoutChao);
	}
	void MoveCenario()
	{
		HorizontalStackLayout1.TranslationX -= velocidade1;
		HorizontalStackLayout2.TranslationX -= velocidade2;
		HorizontalStackLayout3.TranslationX -= velocidade3;
		HorizontalStackLayoutChao.TranslationX -= velocidade;
	}
	void GerenciaCenarios(HorizontalStackLayout hsl)
	{
		var view = (hsl.Childrew.First() as Image);
		if (view.WidthRequest + hsl.TranslationX < 0)
		{
			hsl.Children.Remove(view);
			hsl.Children.Add(view);
			hsl.TranslationX = view.TranslationX;
		}
	}
	async Task Desenha()
	{
		while(!estaMorto)
		{
			GerenciaCenarios();
			await Task.Delay(tempoEntreFrames);
		}
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
		Desenha();
	}
}

