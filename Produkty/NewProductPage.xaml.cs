using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Microsoft.Maui.Controls.Shapes;
using Produkty;
using System.Globalization;

namespace Produkty;

public partial class NewProductPage : ContentPage
{
	private List<Produkt> _produkty;

	public NewProductPage()
	{
		InitializeComponent();

		_produkty = new List<Produkt>();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		string nazwa = NazwaEntry.Text;

        double cena = double.Parse(Cena.Text, CultureInfo.InvariantCulture);

		string kategoria = KategoriaPicker.SelectedItem.ToString();

		_produkty.Add(new Produkt(nazwa, cena, kategoria));

		RysujProdukty();
		WyczyscPola();
    }

	private void WyczyscPola()
	{
		NazwaEntry.Text = "";
		Cena.Text = "";
        KategoriaPicker.SelectedIndex = -1;
    }

	private void RysujProdukty()
	{
        WrapperProduktuw.Children.Clear();

		if(_produkty.Count > 0)
		{
			foreach(Produkt p in _produkty)
			{
                HorizontalStackLayout myContainer = new HorizontalStackLayout
                {
                    Spacing = 20,
                    Padding = 10,
                };

                Label nazwa = new Label
				{
					Text = $"Nazwa: {p.Nazwa},",
				};
                myContainer.Children.Add(nazwa);

                Label cena = new Label
                {
                    Text = $"Cena: {p.Cena},",
                };
                myContainer.Children.Add(cena);

                Label kategoria = new Label
                {
                    Text = $"Kategoria: {p.Kategoria},",
                };
                myContainer.Children.Add(kategoria);


                Border zaokroglag = new Border
                {
                    Stroke = Color.FromArgb("#cccccc"),
                    StrokeThickness = 1,
                    StrokeShape = new RoundRectangle
                    {
                        CornerRadius = new CornerRadius(5)
                    },
                    Content = myContainer
                };


                WrapperProduktuw.Children.Add(zaokroglag);
            }
        }
    }
}