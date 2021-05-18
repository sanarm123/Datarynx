using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Datarynx.Views
{
	[ExcludeFromCodeCoverage]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HeaderContentView : ContentView
	{
		public event EventHandler Clicked = delegate { };

		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(HeaderContentView), propertyChanged: CommandUpdated);

		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(HeaderContentView), propertyChanged: CommandParameterUpdated);
		private static void CommandParameterUpdated(object sender, object oldValue, object newValue)
		{
			if (sender is HeaderContentView activityButton && newValue != null)
			{
				activityButton.innerButton.CommandParameter = newValue;
			}
		}
		private static void CommandUpdated(object sender, object oldValue, object newValue)
		{
			if (sender is HeaderContentView activityButton && newValue is ICommand newCommand)
			{
				activityButton.innerButton.Command = newCommand;
			}
		}
		public ICommand Command
		{
			get => (ICommand)this.GetValue(CommandProperty);
			set => this.SetValue(CommandProperty, value);
		}

		public object CommandParameter
		{
			get => this.GetValue(CommandParameterProperty);
			set => this.SetValue(CommandParameterProperty, value);
		}
		public HeaderContentView ()
		{
			InitializeComponent ();
			this.innerButton.BindingContext = this;
			this.innerButton.Clicked += this.OnClicked;
		}

		private void OnClicked(object sender, EventArgs args)
		{
			this.Clicked?.Invoke(sender, args);

		}
	}
}