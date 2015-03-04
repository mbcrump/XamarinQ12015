using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using TelerikUI;
using CoreGraphics;
using ObjCRuntime;

namespace SideDrawer
{
   
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            this.Window = new UIWindow(UIScreen.MainScreen.Bounds);

            ViewController main = new ViewController();
            TKSideDrawerController sideDrawerController = new TKSideDrawerController(main);
            this.Window.RootViewController = sideDrawerController;

            this.Window.MakeKeyAndVisible();

            return true;

        }

        public partial class ViewController : UIViewController
        {
            private TKSideDrawerSection primarySection;
            private TKSideDrawerSection labelsSection;

            public TKSideDrawer SideDrawer
            {
                get;
                set;
            }

            public override void ViewDidLoad()
            {
                base.ViewDidLoad();

                UIImageView backgroundView = new UIImageView(this.View.Bounds);
                backgroundView.Image = new UIImage("bg.png");
                this.View.AddSubview(backgroundView);

                UINavigationBar navBar = new UINavigationBar(new CGRect(0, 0, this.View.Frame.Size.Width, 64));
                UINavigationItem navItem = new UINavigationItem("SideDrawer");
                UIBarButtonItem showSideDrawer = new UIBarButtonItem(new UIImage("menu.png"), UIBarButtonItemStyle.Plain, this, new Selector("ShowSideDrawer"));
                navItem.LeftBarButtonItem = showSideDrawer;
                navBar.Items = new UINavigationItem[] { navItem };
                this.View.AddSubview(navBar);

                primarySection = new TKSideDrawerSection("Controls");
                primarySection.AddItem("AppFeedback");
                primarySection.AddItem("Calendar");
                primarySection.AddItem("Chart");
                primarySection.AddItem("DataSource");
                primarySection.AddItem("ListView");
                primarySection.AddItem("SideDrawer");

                labelsSection = new TKSideDrawerSection("Help");
                labelsSection.AddItem("Support");
                labelsSection.AddItem("Documentation");
                labelsSection.AddItem("Feedback");

                this.SideDrawer = TKSideDrawer.FindSideDrawer(this);
                SideDrawer.AddSection(primarySection);
                SideDrawer.AddSection(labelsSection);

           }

            [Export("ShowSideDrawer")]
            public void ShowSideDrawer()
            {
                this.SideDrawer.Show();
            }

       }

    }
}