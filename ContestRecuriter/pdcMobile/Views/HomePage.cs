using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Xamarin.Forms;


namespace pdcMobile
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
			Padding = new Thickness (0, Device.OnPlatform (0, 0, 0), 0, 0);
			Title = "Planet Technologies Prize Giveaway";

			var splashImage = new Image {
				Aspect = Aspect.Fill,
				Source = "RaffleTixImage.jpg"
				//Source = Device.OnPlatform(ImageSource.FromFile("Resources/ContestSpashScreen.png"), ImageSource.FromFile("ContestSpashScreen.png"),ImageSource.FromFile("ContestSpashScreen.png"))
			};


			var buttonEnter = new Button { 
				Text = "Enter Drawing",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.EndAndExpand
//				BorderWidth = 1,
//				BorderColor = Color.White,
//				BackgroundColor = Color.White

			};

			buttonEnter.Clicked += (sender, e) => {
				Navigation.PushAsync(new ShowPrizes());
			};

			RelativeLayout layout = new RelativeLayout ();

			layout.Children.Add (splashImage,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			layout.Children.Add (buttonEnter,
				Constraint.Constant (0),
				Constraint.Constant (0),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height;
				}));

			Content = new StackLayout {

				Children = { layout,
//					
//					new StackLayout {
//						Children = {buttonEnter}
//					}
				}
				
			};

		}
	}
}

