using YodaMVVM.ViewModels;

namespace YodaMVVM.Views;

public partial class FactPage : ContentPage
{
	FactPageViewModel _viewModel;
	
	public FactPage(FactPageViewModel view)
	{
		_viewModel = view;
		InitializeComponent();
		BindingContext = _viewModel;
	}
}