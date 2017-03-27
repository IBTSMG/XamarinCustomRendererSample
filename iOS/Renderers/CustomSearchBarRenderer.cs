using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinCustomRendererSamples.iOS;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace XamarinCustomRendererSamples.iOS
{
	public class CustomSearchBarRenderer : SearchBarRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
		{
			base.OnElementChanged(e);

			try
			{
				if (Control != null)
				{
					Control.OnEditingStarted += (sender, evt) =>
					{
						try
						{
							if (Control != null)
							{
								Control.ShowsCancelButton = true;
								SetCancelButtonText();
							}
						}
						catch (Exception)
						{ }
					};

					Control.OnEditingStopped += (sender, evt) =>
					{
						try
						{
							if (Control != null)
							{
								Control.ShowsCancelButton = false;
							}
						}
						catch (Exception)
						{ }
					};

					Control.EnablesReturnKeyAutomatically = true;

					Control.TextChanged += (sender, evt) =>
					{
						try
						{
							Control.ShowsCancelButton = true;
							SetCancelButtonText();
						}
						catch (Exception)
						{

						}
					};
				}
			}
			catch (Exception)
			{ }
		}

		void SetCancelButtonText()
		{
			if (Control.Subviews != null && Control.Subviews.Length > 0)
			{
				var view = Control.Subviews[0] as UIView;
				if (view != null && view.Subviews != null)
				{
					foreach (var v in view.Subviews)
					{
						if (v != null && v is UIButton)
						{
							UIButton btnCancel = v as UIButton;
							btnCancel.SetTitle("Cancel", UIControlState.Normal);
							btnCancel.SetTitleColor(UIColor.Red, UIControlState.Normal);
						}
					}
				}
			}
		}
	}
}
