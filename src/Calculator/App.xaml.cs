﻿namespace Calculator;

public partial class App : Application
{
    public static HistoryViewModel vm;
    public App()
	{
		InitializeComponent();

		//MainPage = new MainPage();
		vm =	new HistoryViewModel();	
	}
}
