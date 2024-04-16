using YodaMVVM.ViewModels;

namespace YodaMVVM.Views;

public partial class AnswerPage : ContentPage
{
	AnswerViewModel viewModel;
	
	public AnswerPage(AnswerViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}