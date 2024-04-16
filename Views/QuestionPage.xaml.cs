using YodaMVVM.ViewModels;

namespace YodaMVVM.Views;

public partial class QuestionPage : ContentPage
{
	QuestionViewModel viewModel;
	
	public QuestionPage(QuestionViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}