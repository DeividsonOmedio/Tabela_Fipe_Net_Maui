using Maui_Tabela_Fipe.Models;
using Maui_Tabela_Fipe.Repositorios;

namespace Maui_Tabela_Fipe;

public partial class MainPage : ContentPage
{
	private static string sTipoVeiculo;
	private static string codiModelo;
	private static string AnoCarro;
    private static string AnoSelPesquisado;

    public MainPage()
	{
		InitializeComponent();
		CarregarTipos();
	}

	public void CarregarTipos()
	{
		pickerTipo.Title = "Selecione um Tipo de Veiculo";
		pickerTipo.ItemsSource = VeiculoRepositorio.ListarVeiculos();
		pickerTipo.ItemDisplayBinding = new Binding("Tipo");
	}

	void SelTipo(object sender, EventArgs e)
	{
		var pickerTipo = (Picker)sender;
		int selectedIndex = pickerTipo.SelectedIndex;

		if (selectedIndex != -1)
		{
			Veiculos veiculos = (Veiculos)pickerTipo.ItemsSource[selectedIndex];
			sTipoVeiculo = veiculos.Tipo;

			CarregarFabricantes(sTipoVeiculo);
		}
	}

	private void CarregarFabricantes(string tipoVeiculos)
	{
		pickerFabricantes.Title = "Selecione um Fabricante";
		pickerFabricantes.ItemsSource = FabricanteRepositorio.ListarFabricantes(tipoVeiculos);
		pickerFabricantes.ItemDisplayBinding = new Binding("nome");
	}

	void SelFabricante(object sender, EventArgs e)
	{
		var pickerFabricante = (Picker)sender;
		int selectedIndex = pickerFabricante.SelectedIndex;

		if (selectedIndex != -1)
		{
			Fabricantes fabricantes = (Fabricantes)pickerFabricantes.ItemsSource[selectedIndex];
			codiModelo = fabricantes.codigo;

			CarregarModelos(codiModelo);
		}
	}

	private void CarregarModelos(string codigo)
	{
		pickerModelo.Title = "selecione um modelo de Carro";
		pickerModelo.ItemsSource = ModeloRepositorio.ListarModelos(codigo, sTipoVeiculo);
		pickerModelo.ItemDisplayBinding = new Binding("nome");

	}

	void SelModelos(object sender, EventArgs e)
	{
		var pickerModelo = (Picker)sender;
		int selectedIndex = pickerModelo.SelectedIndex;

		if (selectedIndex != -1)
		{
			modelos ano = (modelos)pickerModelo.ItemsSource[selectedIndex];
			AnoCarro = ano.codigo;

			CarregarAnos(AnoCarro);
		}
	}
	private void CarregarAnos(string CodAno)
	{
		pickerAno.Title = "Selecione o ano do Veiculo";
		pickerAno.ItemsSource = AnoRepositorio.ListarAnos(codiModelo, sTipoVeiculo, CodAno);
		pickerAno.ItemDisplayBinding = new Binding("nome");

    }

    void SelAnoPesquisado(object sender, EventArgs e)
    {
        var pickerAnoCarro = (Picker)sender;
        int selectedIndex = pickerAnoCarro.SelectedIndex;

        if (selectedIndex != -1)
        {
            Ano pAno = (Ano)pickerAnoCarro.ItemsSource[selectedIndex];
            AnoSelPesquisado = pAno.codigo;

            
        }
        
            btnPesquisa.IsEnabled = true;
        
    }

	private async void CarregaDadosPesquisados(object sender, EventArgs e)
	{
		
		
        try
		{
			lblPreco.Text = PesquisaRepositorio.RetornaDadosCarro(codiModelo, sTipoVeiculo, AnoCarro, AnoSelPesquisado).Valor;
            btnPesquisa.IsEnabled = false;
			
        }
		catch(Exception)
		{
			await DisplayAlert("Atenção", "Erro ao tentar fazer a busca", "Fechar");
			return;
        }

	}

	
}

