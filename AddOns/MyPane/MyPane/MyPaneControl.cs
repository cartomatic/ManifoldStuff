using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System;

using M = Manifold.Interop;

namespace TestNs
{

    public partial class MyPaneControl : UserControl, Manifold.Interop.Scripts.IEventsConnection
    {

       public static M.Application mApp;

        public MyPaneControl()
        {

            InitializeComponent();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (mApp != null)

                mApp.MessageBox("The document contains " +

                    ((Manifold.Interop.Document)mApp.ActiveDocument).ComponentSet.Count +

                    " components.", "The Answer");

        }


        public void ConnectEvents(Manifold.Interop.Scripts.Events ev)
        {

            ev.DocumentClosed += new Manifold.Interop.Scripts.Events.DocumentClosedEventHandler(DocumentChanged);

            ev.DocumentCreated += new Manifold.Interop.Scripts.Events.DocumentCreatedEventHandler(DocumentChanged);

            ev.DocumentOpened += new Manifold.Interop.Scripts.Events.DocumentOpenedEventHandler(DocumentChanged);

            ev.DocumentSaved += new Manifold.Interop.Scripts.Events.DocumentSavedEventHandler(DocumentChanged);

            ev.AddinLoaded += new Manifold.Interop.Scripts.Events.AddinLoadedEventHandler(DocumentChanged);

        }


        private void DocumentChanged(System.Object sender, Manifold.Interop.Scripts.DocumentEventArgs args)
        {

            mApp = args.Document.Application;

            label1.Text = args.Document.Path;

        }       

    }
}