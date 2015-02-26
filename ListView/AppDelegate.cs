using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using TelerikUI;
using CoreGraphics;
using ObjCRuntime;

namespace ListView
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
            this.Window.RootViewController = main;

            this.Window.MakeKeyAndVisible();

            return true;

        }

        public partial class ViewController : UIViewController
        {
            //Sample 1 
            TKListView listView = new TKListView();

            #region Sample 2
            //Sample 2
            //public TKDataSource Photos
            //{
            //    get;
            //    set;
            //}
            //public TKDataSource Names
            //{
            //    get;
            //    set;
            //}
            #endregion

            public override void ViewDidLoad()
            {
                base.ViewDidLoad();

                NSString[] simpleArrayOfStrings = new NSString[] { 
                new NSString("Brian Rinaldi"),
                new NSString("Burke Holland"),
                new NSString("Cody Lindley"),
                new NSString("Ed Charbeneau"),
                new NSString("John Bristowe"), 
                new NSString("Jen Looper"), 
                new NSString("Lohith G N"), 
                new NSString("Michael Crump"),
                new NSString("Sam Basu"), 
                new NSString("Sebastian Witalec"), 
                new NSString("TJ VanToll")
            };
                TKDataSource dataSource = new TKDataSource(simpleArrayOfStrings);
                listView.Frame = this.View.Bounds;
                this.listView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
                this.listView.WeakDataSource = dataSource;
                this.listView.AllowsMultipleSelection = true;
                this.listView.AllowsCellReorder = true;
                this.View.AddSubview(this.listView);

                #region Sample 2
                //    this.Photos = new TKDataSource("PhotosWithNames", "json", "photos");
            //    this.Names = new TKDataSource("PhotosWithNames", "json", "names");

            //    TKListView listView = new TKListView(this.View.Bounds);
            //    listView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            //    listView.DataSource = new ListViewDataSource(this);
            //    this.View.AddSubview(listView);
            //    listView.RegisterClassForCell(new Class(typeof(ImageWithTextListViewCell)), "cell");

            //    TKListViewColumnsLayout layout = (TKListViewColumnsLayout)listView.Layout;
            //    layout.CellAlignment = TKListViewCellAlignment.Center;
            //    layout.ColumnsCount = 2;
            //    layout.ItemSize = new CGSize(150, 200);
            //    layout.MinimumLineSpacing = 60;
            //    layout.MinimumInteritemSpacing = 10;

            //    listView.Fill = TKLinearGradientFill.WithColors(new UIColor[] { 
            //    new UIColor (0.35f, 0.68f, 0.89f, 0.89f), 
            //    new UIColor (0.35f, 0.68f, 1.0f, 1.0f), 
            //    new UIColor (0.85f, 0.8f, 0.2f, 0.8f)
                //});
                #endregion

            }

            #region Sample 2
            //class ListViewDataSource : TKListViewDataSource
            //{
            //    ViewController owner;

            //    public ListViewDataSource(ViewController owner)
            //    {
            //        this.owner = owner;
            //    }

            //    public override int NumberOfItemsInSection(TKListView listView, int section)
            //    {
            //        return this.owner.Names.Items.Length;
            //    }

            //    public override TKListViewCell CellForItem(TKListView listView, NSIndexPath indexPath)
            //    {
            //        TKListViewCell cell = (TKListViewCell)listView.DequeueReusableCell("cell", indexPath);
            //        NSString imageName = (NSString)this.owner.Photos.Items[indexPath.Row];
            //        cell.ImageView.Image = new UIImage(imageName);
            //        cell.TextLabel.Text = (NSString)this.owner.Names.Items[indexPath.Row];
            //        return cell;
            //    }
            //}
            #endregion 
        }

    }
}
      