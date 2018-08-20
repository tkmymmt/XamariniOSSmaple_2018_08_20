using System;
using CoreAnimation;
using UIKit;

namespace XamariniOSSample_2018_08_20
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var view = new UIView
			{
				TranslatesAutoresizingMaskIntoConstraints = false,
				BackgroundColor = UIColor.Blue
			};

			UITapGestureRecognizer tapGestureRecognizer = new UITapGestureRecognizer(() =>
			{
				UIView.Transition(view, 1.0, UIViewAnimationOptions.TransitionCurlDown, null /*() => view.BackgroundColor = (view.BackgroundColor == UIColor.Blue) ? UIColor.Red : UIColor.Blue*/, null);
				UIView.Animate(0.1, () => view.BackgroundColor = (view.BackgroundColor == UIColor.Blue) ? UIColor.Red : UIColor.Blue, null);
			});
			view.AddGestureRecognizer(tapGestureRecognizer);

			View.AddSubview(view);


			UISwipeGestureRecognizer rightSwipe = new UISwipeGestureRecognizer(
				() => UIView.Transition(view, 1.0, UIViewAnimationOptions.TransitionFlipFromLeft, null, null));
			rightSwipe.Direction = UISwipeGestureRecognizerDirection.Right;
			View.AddGestureRecognizer(rightSwipe);

			UISwipeGestureRecognizer leftSwipe = new UISwipeGestureRecognizer(
				() => UIView.Transition(view, 1.0, UIViewAnimationOptions.TransitionFlipFromRight, null, null));
			leftSwipe.Direction = UISwipeGestureRecognizerDirection.Left;
			View.AddGestureRecognizer(leftSwipe);

			UISwipeGestureRecognizer upSwipe = new UISwipeGestureRecognizer(
				() => UIView.Transition(view, 1.0, UIViewAnimationOptions.TransitionFlipFromTop, null, null));
			upSwipe.Direction = UISwipeGestureRecognizerDirection.Up;
			View.AddGestureRecognizer(upSwipe);

			UISwipeGestureRecognizer downSwipe = new UISwipeGestureRecognizer(
				() => UIView.Transition(view, 1.0, UIViewAnimationOptions.TransitionFlipFromBottom, null, null));
			downSwipe.Direction = UISwipeGestureRecognizerDirection.Down;
			View.AddGestureRecognizer(downSwipe);


			view.LeftAnchor.ConstraintEqualTo(View.LeftAnchor, 100).Active = true;
			view.RightAnchor.ConstraintEqualTo(View.RightAnchor, -100).Active = true;
			view.HeightAnchor.ConstraintEqualTo(view.WidthAnchor).Active = true;
			view.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
